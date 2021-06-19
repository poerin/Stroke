using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stroke
{
    public partial class Stroke : Form
    {
        private Draw draw;
        private bool stroking = false;
        private bool stroked = false;
        private bool special = false;
        private bool abolish = false;
        private bool filtering = false;
        private Point lastPoint = new Point(0, 0);
        private List<Point> drwaingPoints = new List<Point>();
        private readonly int threshold = 80;
        private int mark = 0;
        public static IntPtr CurrentWindow;
        public static string CurrentProcessImagePath;
        public static Point KeyPoint;

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.AutoScaleDimensions = new SizeF(96F, 96F);
            this.AutoScaleMode = AutoScaleMode.Dpi;
            this.BackColor = Color.Black;
            this.Bounds = SystemInformation.VirtualScreen;
            this.ControlBox = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Stroke";
            this.Opacity = Settings.Pen.Opacity;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.Manual;
            this.TransparencyKey = Color.Black;
            this.ResumeLayout(false);
        }

        public Stroke()
        {
            InitializeComponent();

            draw = new Draw(this.Handle, API.CreatePen(API.PenStyle.PS_SOLID, Settings.Pen.Thickness, new API.COLORREF(Settings.Pen.Color.R, Settings.Pen.Color.G, Settings.Pen.Color.B)));
            this.Shown += Stroke_Shown;
            this.FormClosing += Stroke_FormClosing;
            MouseHook.MouseAction += MouseHook_MouseAction;
            Settings.Pen.PenChanged += Pen_PenChanged;
            API.AllowSetForegroundWindow((uint)Process.GetCurrentProcess().Id);
        }

        private void Pen_PenChanged()
        {
            draw.Dispose();
            GC.Collect();
            draw = new Draw(this.Handle, API.CreatePen(API.PenStyle.PS_SOLID, Settings.Pen.Thickness, new API.COLORREF(Settings.Pen.Color.R, Settings.Pen.Color.G, Settings.Pen.Color.B)));
        }

        private void Stroke_Shown(object sender, EventArgs e)
        {
            API.SetWindowLong(this.Handle, API.WindowLong.GWL_EXSTYLE, API.GetWindowLong(this.Handle, API.WindowLong.GWL_EXSTYLE) | (int)(API.WindowStylesExtended.WS_EX_TRANSPARENT | API.WindowStylesExtended.WS_EX_LAYERED | API.WindowStylesExtended.WS_EX_NOACTIVATE));
        }

        private void Stroke_FormClosing(object sender, FormClosingEventArgs e)
        {
            draw.Dispose();
        }

        private bool MouseHook_MouseAction(MouseHook.MouseActionArgs args)
        {
            if (args.MouseButton == Settings.StrokeButton)
            {
                if (args.MouseButtonState == MouseHook.MouseButtonStates.Down)
                {
                    KeyPoint = args.Location;
                    CurrentWindow = API.GetAncestor(API.WindowFromPoint(new API.POINT(KeyPoint.X, KeyPoint.Y)), API.GetAncestorFlags.GA_ROOT);
                    API.GetWindowThreadProcessId(CurrentWindow, out uint pid);
                    IntPtr hProcess = API.OpenProcess(API.AccessRights.PROCESS_QUERY_INFORMATION, false, pid);
                    StringBuilder path = new StringBuilder(1024);
                    uint size = (uint)path.Capacity + 1;
                    API.QueryFullProcessImageName(hProcess, 0, path, ref size);
                    CurrentProcessImagePath = path.ToString();
                    foreach (string filtration in Settings.Filtrations)
                    {
                        if (Regex.IsMatch(CurrentProcessImagePath, filtration))
                        {
                            filtering = true;
                            return false;
                        }
                    }
                    stroking = true;
                    this.TopMost = true;
                    lastPoint = args.Location;
                    drwaingPoints.Add(args.Location);
                    return true;
                }
                else if (args.MouseButtonState == MouseHook.MouseButtonStates.Up)
                {
                    stroking = false;
                    this.TopMost = false;

                    if (filtering)
                    {
                        filtering = false;
                        return false;
                    }

                    if (abolish)
                    {
                        mark = 0;
                        stroked = false;
                        abolish = false;
                        return true;
                    }

                    this.Refresh();
                    if (stroked)
                    {
                        Gesture gesture = new Gesture("", drwaingPoints);
                        int similarity = 0, index = 0;
                        for (int i = 0; i < Settings.Gestures.Count; i++)
                        {
                            if (Settings.Gestures[i].Vectors == null)
                            {
                                continue;
                            }

                            int temp = gesture.Similarity(Settings.Gestures[i]);
                            if (temp > similarity)
                            {
                                similarity = temp;
                                index = i;
                            }
                        }

                        if (similarity > threshold)
                        {
                            for (int i = Settings.ActionPackages.Count - 1; i > -1; i--)
                            {
                                bool match = false;
                                foreach (string pattern in Settings.ActionPackages[i].Code.Replace("\r", "").Split('\n'))
                                {
                                    if (pattern != "" && Regex.IsMatch(CurrentProcessImagePath, pattern))
                                    {
                                        match = true;
                                        break;
                                    }
                                }

                                if (match)
                                {
                                    foreach (Action action in Settings.ActionPackages[i].Actions)
                                    {
                                        if (action.Gesture == Settings.Gestures[index].Name)
                                        {
                                            Script.RunScript($"{Settings.ActionPackages[i].Name}.{action.Name}", mark);
                                            mark = 0;
                                            stroked = false;
                                            drwaingPoints.Clear();
                                            return true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        ClickStrokeButton();
                    }

                    mark = 0;
                    stroked = false;
                    drwaingPoints.Clear();
                    return true;
                }
            }
            else if (stroking)
            {
                string gesture = "#";

                if (args.MouseButtonState == MouseHook.MouseButtonStates.Down)
                {
                    special = false;

                    switch (args.MouseButton)
                    {
                        case MouseButtons.Left:
                            mark |= 0x00000001;
                            break;
                        case MouseButtons.Right:
                            mark |= 0x00000002;
                            break;
                        case MouseButtons.XButton1:
                            mark |= 0x00000004;
                            break;
                        case MouseButtons.XButton2:
                            mark |= 0x00000008;
                            break;
                        case MouseButtons.Middle:
                            mark |= 0x00000010;
                            break;
                    }
                    return true;
                }
                else if (args.MouseButtonState == MouseHook.MouseButtonStates.Up && !stroked && !special)
                {
                    special = true;

                    switch (args.MouseButton)
                    {
                        case MouseButtons.Middle:
                            gesture = gesture + (int)(SpecialGesture.MiddleClick);
                            break;
                        case MouseButtons.Left:
                            gesture = gesture + (int)(SpecialGesture.LeftClick);
                            break;
                        case MouseButtons.Right:
                            gesture = gesture + (int)(SpecialGesture.RightClick);
                            break;
                        case MouseButtons.XButton1:
                            gesture = gesture + (int)(SpecialGesture.X1Click);
                            break;
                        case MouseButtons.XButton2:
                            gesture = gesture + (int)(SpecialGesture.X2Click);
                            break;
                    }
                }
                else if (args.MouseButtonState == MouseHook.MouseButtonStates.Wheel)
                {
                    special = true;

                    if (args.WheelDelta > 0)
                    {
                        gesture = gesture + (int)(SpecialGesture.WheelUp);
                    }
                    else
                    {
                        gesture = gesture + (int)(SpecialGesture.WheelDown);
                    }
                }

                if (gesture != "#")
                {
                    for (int i = Settings.ActionPackages.Count - 1; i > -1; i--)
                    {
                        bool match = false;
                        foreach (string pattern in Settings.ActionPackages[i].Code.Replace("\r", "").Split('\n'))
                        {
                            if (pattern != "" && Regex.IsMatch(CurrentProcessImagePath, pattern))
                            {
                                match = true;
                                break;
                            }
                        }

                        if (match)
                        {
                            foreach (Action action in Settings.ActionPackages[i].Actions)
                            {
                                if (action.Gesture == gesture)
                                {
                                    abolish = true;
                                    this.Refresh();
                                    drwaingPoints.Clear();
                                    Script.RunScript($"{Settings.ActionPackages[i].Name}.{action.Name}", mark);
                                    return true;
                                }
                            }
                        }
                    }
                    return true;
                }
            }

            if (args.MouseButtonState == MouseHook.MouseButtonStates.Move && stroking && !abolish)
            {
                if (!stroked)
                {
                    if (Math.Pow(lastPoint.X - KeyPoint.X, 2) + Math.Pow(lastPoint.Y - KeyPoint.Y, 2) > 512)
                    {
                        stroked = true;
                    }
                }

                if (Settings.Pen.Opacity != 0 && Settings.Pen.Thickness != 0)
                {
                    draw.DrawPath(lastPoint, args.Location);
                }
                lastPoint = args.Location;
                drwaingPoints.Add(args.Location);
            }

            return false;
        }

        private static void ClickStrokeButton()
        {
            var task = Task.Run(() =>
            {
                MouseHook.StopHook();
                API.INPUT imput = new API.INPUT();
                imput.type = API.INPUTTYPE.MOUSE;
                imput.mi.dx = 0;
                imput.mi.dy = 0;
                imput.mi.mouseData = 0;
                imput.mi.time = 0u;
                imput.mi.dwExtraInfo = (UIntPtr)0uL;

                switch (Settings.StrokeButton)
                {
                    case MouseButtons.Left:
                        if (API.GetSystemMetrics(API.SystemMetrics.SM_SWAPBUTTON) == 0)
                        {
                            imput.mi.dwFlags = (API.MOUSEEVENTF.LEFTDOWN | API.MOUSEEVENTF.LEFTUP);
                        }
                        else
                        {
                            imput.mi.dwFlags = (API.MOUSEEVENTF.RIGHTDOWN | API.MOUSEEVENTF.RIGHTUP);
                        }
                        break;
                    case MouseButtons.Right:
                        if (API.GetSystemMetrics(API.SystemMetrics.SM_SWAPBUTTON) == 0)
                        {
                            imput.mi.dwFlags = (API.MOUSEEVENTF.RIGHTDOWN | API.MOUSEEVENTF.RIGHTUP);
                        }
                        else
                        {
                            imput.mi.dwFlags = (API.MOUSEEVENTF.LEFTDOWN | API.MOUSEEVENTF.LEFTUP);
                        }
                        break;
                    case MouseButtons.Middle:
                        imput.mi.dwFlags = (API.MOUSEEVENTF.MIDDLEDOWN | API.MOUSEEVENTF.MIDDLEUP);
                        break;
                    case MouseButtons.XButton1:
                        imput.mi.dwFlags = (API.MOUSEEVENTF.XDOWN | API.MOUSEEVENTF.XUP);
                        imput.mi.mouseData = 0x0001;
                        break;
                    case MouseButtons.XButton2:
                        imput.mi.dwFlags = (API.MOUSEEVENTF.XDOWN | API.MOUSEEVENTF.XUP);
                        imput.mi.mouseData = 0x0002;
                        break;
                }

                API.SendInput(1u, ref imput, Marshal.SizeOf(typeof(API.INPUT)));
            });
            task.GetAwaiter().OnCompleted(() =>
            {
                MouseHook.StartHook();
            });
        }

    }
}
