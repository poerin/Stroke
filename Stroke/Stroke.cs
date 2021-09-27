using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stroke
{
    public class Stroke : Form
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

        public static IntPtr CurrentWindow { private set; get; }
        public static string CurrentProcessImagePath { private set; get; }
        public static Point KeyPoint { private set; get; }


        private void InitializeComponent()
        {
            SuspendLayout();
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.Black;
            Bounds = SystemInformation.VirtualScreen;
            ControlBox = false;
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Stroke";
            Opacity = Settings.Pen.Opacity;
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.Manual;
            TransparencyKey = Color.Black;
            ResumeLayout(false);
        }

        public Stroke()
        {
            API.SetWindowLong(Handle, API.GWL.EXSTYLE, API.GetWindowLong(Handle, API.GWL.EXSTYLE) | (int)(API.WS_EX.TRANSPARENT | API.WS_EX.LAYERED | API.WS_EX.NOACTIVATE));
            InitializeComponent();

            draw = new Draw(Handle, API.CreatePen(API.PS.SOLID, Settings.Pen.Thickness, new API.COLORREF(Settings.Pen.Color.R, Settings.Pen.Color.G, Settings.Pen.Color.B)));
            MouseHook.MouseAction += MouseHook_MouseAction;
            Settings.Pen.PenChanged += Pen_PenChanged;
        }


        private void Pen_PenChanged()
        {
            draw.Dispose();
            GC.Collect();
            draw = new Draw(Handle, API.CreatePen(API.PS.SOLID, Settings.Pen.Thickness, new API.COLORREF(Settings.Pen.Color.R, Settings.Pen.Color.G, Settings.Pen.Color.B)));
        }

        private bool MouseHook_MouseAction(MouseHook.MouseActionArgs args)
        {
            if (args.MouseButton == Settings.StrokeButton)
            {
                if (args.MouseButtonState == MouseHook.MouseButtonStates.Down)
                {
                    KeyPoint = args.Location;
                    CurrentWindow = API.GetAncestor(API.WindowFromPoint(new API.POINT(KeyPoint.X, KeyPoint.Y)), API.GA.ROOT);
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
                    API.SetWindowPos(Handle, API.IA.TOPMOST, 0, 0, 0, 0, API.SWP.NOSIZE | API.SWP.NOMOVE | API.SWP.NOACTIVATE);
                    API.ShowWindow(Handle, API.SW.SHOWNOACTIVATE);
                    lastPoint = args.Location;
                    drwaingPoints.Add(args.Location);
                    return true;
                }
                else if (args.MouseButtonState == MouseHook.MouseButtonStates.Up)
                {
                    stroking = false;
                    draw.Clear();
                    Refresh();
                    API.ShowWindow(Handle, API.SW.HIDE);
                    API.SetWindowPos(Handle, API.IA.NOTOPMOST, 0, 0, 0, 0, API.SWP.NOSIZE | API.SWP.NOMOVE | API.SWP.NOACTIVATE);

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
                                    Refresh();
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
            Task.Run(() =>
            {
                API.INPUT input = new API.INPUT();
                input.type = API.INPUTTYPE.MOUSE;
                input.mi.dx = 0;
                input.mi.dy = 0;
                input.mi.mouseData = 0;
                input.mi.time = 0u;
                input.mi.dwExtraInfo = (UIntPtr)0x7FuL;

                switch (Settings.StrokeButton)
                {
                    case MouseButtons.Left:
                        if (API.GetSystemMetrics(API.SM.SWAPBUTTON) == 0)
                        {
                            input.mi.dwFlags = (API.MOUSEEVENTF.LEFTDOWN | API.MOUSEEVENTF.LEFTUP);
                        }
                        else
                        {
                            input.mi.dwFlags = (API.MOUSEEVENTF.RIGHTDOWN | API.MOUSEEVENTF.RIGHTUP);
                        }
                        break;
                    case MouseButtons.Right:
                        if (API.GetSystemMetrics(API.SM.SWAPBUTTON) == 0)
                        {
                            input.mi.dwFlags = (API.MOUSEEVENTF.RIGHTDOWN | API.MOUSEEVENTF.RIGHTUP);
                        }
                        else
                        {
                            input.mi.dwFlags = (API.MOUSEEVENTF.LEFTDOWN | API.MOUSEEVENTF.LEFTUP);
                        }
                        break;
                    case MouseButtons.Middle:
                        input.mi.dwFlags = (API.MOUSEEVENTF.MIDDLEDOWN | API.MOUSEEVENTF.MIDDLEUP);
                        break;
                    case MouseButtons.XButton1:
                        input.mi.dwFlags = (API.MOUSEEVENTF.XDOWN | API.MOUSEEVENTF.XUP);
                        input.mi.mouseData = 0x0001;
                        break;
                    case MouseButtons.XButton2:
                        input.mi.dwFlags = (API.MOUSEEVENTF.XDOWN | API.MOUSEEVENTF.XUP);
                        input.mi.mouseData = 0x0002;
                        break;
                }

                API.SendInput(1u, ref input, Marshal.SizeOf(typeof(API.INPUT)));
            });
        }

    }
}
