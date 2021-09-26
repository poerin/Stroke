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
    public static class Stroke
    {
        private static IntPtr Handle;
        private static Rectangle Bounds;
        private static Draw draw;
        private static bool stroking = false;
        private static bool stroked = false;
        private static bool special = false;
        private static bool abolish = false;
        private static bool filtering = false;
        private static Point lastPoint = new Point(0, 0);
        private static List<Point> drwaingPoints = new List<Point>();
        private static readonly int threshold = 80;
        private static int mark = 0;
        public static IntPtr CurrentWindow { private set; get; }
        public static string CurrentProcessImagePath { private set; get; }
        public static Point KeyPoint { private set; get; }


        private static IntPtr WindowProcedure(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam)
        {
            switch (uMsg)
            {
                case (uint)API.WindowMessages.WM_CREATE:
                    Script.CompileScript();
                    MouseHook.StartHook();
                    break;
                case (uint)API.WindowMessages.WM_CLOSE:
                    API.DestroyWindow(hWnd);
                    break;
                case (uint)API.WindowMessages.WM_DESTROY:
                    MouseHook.StopHook();
                    draw.Dispose();
                    API.PostQuitMessage(0);
                    break;
            }

            return API.DefWindowProc(hWnd, uMsg, wParam, lParam);
        }

        [STAThread]
        static void Main()
        {
            try
            {
                if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
                {
                    return;
                }
                Settings.ReadSettings();
            }
            catch
            {
                return;
            }

            Bounds = SystemInformation.VirtualScreen;

            uint LWA_COLORKEY = 0x1;
            uint LWA_ALPHA = 0x2;

            API.WNDCLASSEX WindowClass = new API.WNDCLASSEX();
            WindowClass.cbSize = (uint)Marshal.SizeOf(typeof(API.WNDCLASSEX));
            WindowClass.style = API.CS.VREDRAW | API.CS.HREDRAW;
            WindowClass.lpfnWndProc = WindowProcedure;
            WindowClass.cbClsExtra = 0;
            WindowClass.cbWndExtra = 0;
            WindowClass.hInstance = API.GetModuleHandle(null);
            WindowClass.hIcon = IntPtr.Zero;
            WindowClass.hCursor = IntPtr.Zero;
            WindowClass.hbrBackground = API.CreateSolidBrush(new API.COLORREF(0, 0, 0));
            WindowClass.lpszMenuName = "";
            WindowClass.lpszClassName = "Stroke";
            WindowClass.hIconSm = IntPtr.Zero;

            if (API.RegisterClassEx(ref WindowClass) == 0)
            {
                return;
            }

            Handle = API.CreateWindowEx(API.WS_EX.TRANSPARENT | API.WS_EX.NOACTIVATE | API.WS_EX.LAYERED | API.WS_EX.TOPMOST, WindowClass.lpszClassName, null, API.WS.CLIPCHILDREN | API.WS.CLIPSIBLINGS | API.WS.POPUP, Bounds.Left, Bounds.Top, Bounds.Width, Bounds.Height, IntPtr.Zero, IntPtr.Zero, WindowClass.hInstance, IntPtr.Zero);
            if (Handle == IntPtr.Zero)
            {
                return;
            }

            API.SetLayeredWindowAttributes(Handle, new API.COLORREF(0, 0, 0), (byte)(255 * Settings.Pen.Opacity), LWA_COLORKEY | LWA_ALPHA);

            draw = new Draw(Handle, API.CreatePen(API.PS.SOLID, Settings.Pen.Thickness, new API.COLORREF(Settings.Pen.Color.R, Settings.Pen.Color.G, Settings.Pen.Color.B)));
            MouseHook.MouseAction += MouseHook_MouseAction;
            Settings.Pen.PenChanged += Pen_PenChanged;

            API.ShowWindow(Handle, API.SW.NORMAL);
            API.UpdateWindow(Handle);

            API.MSG message = new API.MSG();
            while (API.GetMessage(out message, IntPtr.Zero, 0, 0))
            {
                API.TranslateMessage(ref message);
                API.DispatchMessage(ref message);
            }
        }

        private static void Pen_PenChanged()
        {
            draw.Dispose();
            GC.Collect();
            draw = new Draw(Handle, API.CreatePen(API.PS.SOLID, Settings.Pen.Thickness, new API.COLORREF(Settings.Pen.Color.R, Settings.Pen.Color.G, Settings.Pen.Color.B)));
        }

        private static bool MouseHook_MouseAction(MouseHook.MouseActionArgs args)
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

                    lastPoint = args.Location;
                    drwaingPoints.Add(args.Location);
                    return true;
                }
                else if (args.MouseButtonState == MouseHook.MouseButtonStates.Up)
                {
                    stroking = false;
                    draw.Clear();

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
                                    draw.Clear();
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
