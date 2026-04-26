using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Stroke
{
    public class Base
    {
        private class Help : API
        {
            public const uint WM_SYSCOMMAND = 0x0112;

            public enum SC : int
            {
                SIZE = 0xF000,
                MOVE = 0xF010,
                MINIMIZE = 0xF020,
                MAXIMIZE = 0xF030,
                NEXTWINDOW = 0xF040,
                PREVWINDOW = 0xF050,
                CLOSE = 0xF060,
                VSCROLL = 0xF070,
                HSCROLL = 0xF080,
                MOUSEMENU = 0xF090,
                KEYMENU = 0xF100,
                RESTORE = 0xF120,
                TASKLIST = 0xF130,
                SCREENSAVE = 0xF140,
                HOTKEY = 0xF150,
                DEFAULT = 0xF160,
                MONITORPOWER = 0xF170,
                CONTEXTHELP = 0xF180
            }

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern int GetClassName(IntPtr hWnd, System.Text.StringBuilder lpClassName, int nMaxCount);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern short GetKeyState(int nVirtKey);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern int GetWindowText(IntPtr hWnd, System.Text.StringBuilder lpClassName, int nMaxCount);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool IsIconic(IntPtr hWnd);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool IsWindow(IntPtr hWnd);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool IsZoomed(IntPtr hWnd);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool SetForegroundWindow(IntPtr hWnd);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, SWP uFlags);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool GetCursorPos(out POINT lpPoint);


        }

        public static class KeyboardHook
        {
            public enum KeyStates
            {
                None,
                Down,
                Up
            }

            public class KeyboardActionArgs
            {
                public readonly Keys Key;
                public readonly KeyStates KeyState;

                public KeyboardActionArgs(Keys key, KeyStates keyState)
                {
                    Key = key;
                    KeyState = keyState;
                }
            }

            private static API.HOOKPROC procedure = HookCallback;
            private static IntPtr hook = IntPtr.Zero;
            public delegate bool KeyboardActionHandler(KeyboardActionArgs args);
            public static event KeyboardActionHandler KeyboardAction;
            public static bool Enable { private set; get; } = false;

            public static void StartHook()
            {
                if (Enable == false)
                {
                    using (ProcessModule module = Process.GetCurrentProcess().MainModule)
                    {
                        hook = API.SetWindowsHookEx(API.WH.KEYBOARD_LL, procedure, API.GetModuleHandle(module.ModuleName), 0);
                    }
                    Enable = true;
                }
            }

            public static void StopHook()
            {
                if (Enable == true)
                {
                    API.UnhookWindowsHookEx(hook);
                    Enable = false;
                }
            }

            private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
            {
                if (nCode >= 0)
                {
                    API.KBDLLHOOKSTRUCT hookStruct = (API.KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(API.KBDLLHOOKSTRUCT));

                    if (hookStruct.dwExtraInfo == (UIntPtr)0x7FuL)
                    {
                        return API.CallNextHookEx(hook, nCode, wParam, lParam);
                    }

                    Keys key = (Keys)hookStruct.vkCode;
                    KeyStates keyState = KeyStates.None;

                    switch ((API.KeyboardMessages)wParam)
                    {
                        case API.KeyboardMessages.WM_KEYDOWN:
                            {
                                keyState = KeyStates.Down;
                            }
                            break;
                        case API.KeyboardMessages.WM_KEYUP:
                            {
                                keyState = KeyStates.Up;
                            }
                            break;
                    }


                    if (KeyboardAction?.Invoke(new KeyboardActionArgs(key, keyState)) == true)
                    {
                        return (IntPtr)1;
                    }
                }
                return API.CallNextHookEx(hook, nCode, wParam, lParam);
            }

        }


        public static Dictionary<string, object> Data = new Dictionary<string, object>();

        public static Point KeyPoint { get => Stroke.KeyPoint; }

        public static Color PenColor { get => Settings.Pen.Color; set => Settings.Pen.Color = value; }
        public static double PenOpacity { get => Settings.Pen.Opacity; set => Settings.Pen.Opacity = value; }
        public static byte PenThickness { get => Settings.Pen.Thickness; set => Settings.Pen.Thickness = value; }


        public static void KeyDown(Keys key)
        {
            API.INPUT input = new API.INPUT();
            input.type = API.INPUTTYPE.KEYBOARD;
            input.ki.time = 0;
            input.ki.wVk = (API.VK)key;
            input.ki.dwExtraInfo = (UIntPtr)0x7FuL;
            input.ki.dwFlags = API.KEYEVENTF.EXTENDEDKEY | 0;
            input.ki.wScan = 0;
            API.SendInput(1u, ref input, Marshal.SizeOf(typeof(API.INPUT)));
        }

        public static void KeyUp(Keys key)
        {
            API.INPUT input = new API.INPUT();
            input.type = API.INPUTTYPE.KEYBOARD;
            input.ki.time = 0;
            input.ki.wVk = (API.VK)key;
            input.ki.dwExtraInfo = (UIntPtr)0x7FuL;
            input.ki.dwFlags = API.KEYEVENTF.EXTENDEDKEY | API.KEYEVENTF.KEYUP;
            input.ki.wScan = 0;
            API.SendInput(1u, ref input, Marshal.SizeOf(typeof(API.INPUT)));
        }

        public static void PressKey(Keys key)
        {
            KeyDown(key);
            KeyUp(key);
        }

        public static void PressKeys(string keys)
        {
            keys = keys.ToUpper();

            int i = 0;
            while (i < keys.Length)
            {
                char current = keys[i];
                if (current == '/' && i + 1 < keys.Length)
                {
                    i++;
                    char code = keys[i];
                    switch (code)
                    {
                        case 'T': PressKey(Keys.Tab); break;
                        case 'R': PressKey(Keys.Return); break;
                        case 'E': PressKey(Keys.Escape); break;
                        case 'S': PressKey(Keys.Space); break;
                        case 'B': PressKey(Keys.Back); break;
                        case 'I': PressKey(Keys.Insert); break;
                        case 'D': PressKey(Keys.Delete); break;
                        default: break;
                    }
                    i++;
                    continue;
                }

                if (current == '#' && i + 2 < keys.Length)
                {
                    string hex = keys.Substring(i + 1, 2);
                    if (int.TryParse(hex, NumberStyles.HexNumber, null, out int keyCode))
                    {
                        PressKey((Keys)keyCode);
                    }
                    i += 3;
                    continue;
                }

                switch (current)
                {
                    case '(': KeyDown(Keys.ControlKey); i++; continue;
                    case ')': KeyUp(Keys.ControlKey); i++; continue;
                    case '[': KeyDown(Keys.ShiftKey); i++; continue;
                    case ']': KeyUp(Keys.ShiftKey); i++; continue;
                    case '{': KeyDown(Keys.Menu); i++; continue;
                    case '}': KeyUp(Keys.Menu); i++; continue;
                    case '<': KeyDown(Keys.LWin); i++; continue;
                    case '>': KeyUp(Keys.LWin); i++; continue;
                }

                if ((current >= '0' && current <= '9') || (current >= 'A' && current <= 'Z'))
                {
                    PressKey((Keys)current);
                }

                i++;
            }
        }

        public static bool IsKeyDown(Keys key)
        {
            return (Help.GetKeyState((int)key) & 0x8000) == 0x8000;
        }

        public static bool IsKeyToggled(Keys key)
        {
            return (Help.GetKeyState((int)key) & 0x0001) == 0x0001;
        }


        public static Point GetMousePosition()
        {
            Help.GetCursorPos(out API.POINT cursorPoint);
            return new Point(cursorPoint.X, cursorPoint.Y);
        }

        public static void MouseMove(int x, int y)
        {
            int screenWidth = API.GetSystemMetrics(API.SM.CXVIRTUALSCREEN);
            int screenHeight = API.GetSystemMetrics(API.SM.CYVIRTUALSCREEN);
            int screenLeft = API.GetSystemMetrics(API.SM.XVIRTUALSCREEN);
            int screenTop = API.GetSystemMetrics(API.SM.YVIRTUALSCREEN);

            int normalizedX = (int)((x - screenLeft) * 65535.0 / screenWidth);
            int normalizedY = (int)((y - screenTop) * 65535.0 / screenHeight);

            API.INPUT input = new API.INPUT();
            input.type = API.INPUTTYPE.MOUSE;
            input.mi.dx = normalizedX;
            input.mi.dy = normalizedY;
            input.mi.mouseData = 0;
            input.mi.time = 0u;
            input.mi.dwExtraInfo = (UIntPtr)0x7FuL;
            input.mi.dwFlags = API.MOUSEEVENTF.MOVE | API.MOUSEEVENTF.ABSOLUTE | API.MOUSEEVENTF.VIRTUALDESK;
            API.SendInput(1u, ref input, Marshal.SizeOf(typeof(API.INPUT)));
        }

        public static void MouseMoveRelative(int offsetX, int offsetY)
        {
            API.INPUT input = new API.INPUT();
            input.type = API.INPUTTYPE.MOUSE;
            input.mi.dx = offsetX;
            input.mi.dy = offsetY;
            input.mi.mouseData = 0;
            input.mi.time = 0u;
            input.mi.dwExtraInfo = (UIntPtr)0x7FuL;
            input.mi.dwFlags = API.MOUSEEVENTF.MOVE;
            API.SendInput(1u, ref input, Marshal.SizeOf(typeof(API.INPUT)));
        }

        public static void MouseDown(MouseButtons button)
        {
            API.INPUT input = new API.INPUT();
            input.type = API.INPUTTYPE.MOUSE;
            input.mi.dx = 0;
            input.mi.dy = 0;
            input.mi.mouseData = 0;
            input.mi.time = 0u;
            input.mi.dwExtraInfo = (UIntPtr)0x7FuL;

            switch (button)
            {
                case MouseButtons.Left:
                    input.mi.dwFlags = API.GetSystemMetrics(API.SM.SWAPBUTTON) == 0
                        ? API.MOUSEEVENTF.LEFTDOWN : API.MOUSEEVENTF.RIGHTDOWN;
                    break;
                case MouseButtons.Right:
                    input.mi.dwFlags = API.GetSystemMetrics(API.SM.SWAPBUTTON) == 0
                        ? API.MOUSEEVENTF.RIGHTDOWN : API.MOUSEEVENTF.LEFTDOWN;
                    break;
                case MouseButtons.Middle:
                    input.mi.dwFlags = API.MOUSEEVENTF.MIDDLEDOWN;
                    break;
                case MouseButtons.XButton1:
                    input.mi.dwFlags = API.MOUSEEVENTF.XDOWN;
                    input.mi.mouseData = 0x0001;
                    break;
                case MouseButtons.XButton2:
                    input.mi.dwFlags = API.MOUSEEVENTF.XDOWN;
                    input.mi.mouseData = 0x0002;
                    break;
                default:
                    return;
            }

            API.SendInput(1u, ref input, Marshal.SizeOf(typeof(API.INPUT)));
        }

        public static void MouseUp(MouseButtons button)
        {
            API.INPUT input = new API.INPUT();
            input.type = API.INPUTTYPE.MOUSE;
            input.mi.dx = 0;
            input.mi.dy = 0;
            input.mi.mouseData = 0;
            input.mi.time = 0u;
            input.mi.dwExtraInfo = (UIntPtr)0x7FuL;

            switch (button)
            {
                case MouseButtons.Left:
                    input.mi.dwFlags = API.GetSystemMetrics(API.SM.SWAPBUTTON) == 0
                        ? API.MOUSEEVENTF.LEFTUP : API.MOUSEEVENTF.RIGHTUP;
                    break;
                case MouseButtons.Right:
                    input.mi.dwFlags = API.GetSystemMetrics(API.SM.SWAPBUTTON) == 0
                        ? API.MOUSEEVENTF.RIGHTUP : API.MOUSEEVENTF.LEFTUP;
                    break;
                case MouseButtons.Middle:
                    input.mi.dwFlags = API.MOUSEEVENTF.MIDDLEUP;
                    break;
                case MouseButtons.XButton1:
                    input.mi.dwFlags = API.MOUSEEVENTF.XUP;
                    input.mi.mouseData = 0x0001;
                    break;
                case MouseButtons.XButton2:
                    input.mi.dwFlags = API.MOUSEEVENTF.XUP;
                    input.mi.mouseData = 0x0002;
                    break;
                default:
                    return;
            }

            API.SendInput(1u, ref input, Marshal.SizeOf(typeof(API.INPUT)));
        }

        public static void MouseClick(MouseButtons button)
        {
            MouseDown(button);
            MouseUp(button);
        }

        public static void MouseDoubleClick(MouseButtons button)
        {
            MouseClick(button);
            MouseClick(button);
        }

        public static void MouseWheel(int delta)
        {
            API.INPUT input = new API.INPUT();
            input.type = API.INPUTTYPE.MOUSE;
            input.mi.dx = 0;
            input.mi.dy = 0;
            input.mi.mouseData = (uint)delta;
            input.mi.time = 0u;
            input.mi.dwExtraInfo = (UIntPtr)0x7FuL;
            input.mi.dwFlags = API.MOUSEEVENTF.WHEEL;
            API.SendInput(1u, ref input, Marshal.SizeOf(typeof(API.INPUT)));
        }

        public static void MouseHorizontalWheel(int delta)
        {
            API.INPUT input = new API.INPUT();
            input.type = API.INPUTTYPE.MOUSE;
            input.mi.dx = 0;
            input.mi.dy = 0;
            input.mi.mouseData = (uint)delta;
            input.mi.time = 0u;
            input.mi.dwExtraInfo = (UIntPtr)0x7FuL;
            input.mi.dwFlags = API.MOUSEEVENTF.HWHEEL;
            API.SendInput(1u, ref input, Marshal.SizeOf(typeof(API.INPUT)));
        }


        public static void Activate(IntPtr handle = default)
        {
            if (handle == default)
            {
                handle = Stroke.CurrentWindow;
            }

            if (Help.IsWindow(handle))
            {
                Help.SetForegroundWindow(handle);
            }
        }

        public enum WindowState
        {
            Normal,
            Minimize,
            Maximize,
            Close
        }

        public static void SetWindowState(WindowState state, IntPtr handle = default)
        {
            if (handle == default)
            {
                handle = Stroke.CurrentWindow;
            }

            if (!Help.IsWindow(handle))
            {
                return;
            }

            if (GetWindowClassName(handle) == "WorkerW")
            {
                return;
            }

            switch (state)
            {
                case WindowState.Normal:
                    Help.PostMessage(handle, Help.WM_SYSCOMMAND, (int)Help.SC.RESTORE, 0);
                    break;
                case WindowState.Minimize:
                    Help.PostMessage(handle, Help.WM_SYSCOMMAND, (int)Help.SC.MINIMIZE, 0);
                    break;
                case WindowState.Maximize:
                    Help.PostMessage(handle, Help.WM_SYSCOMMAND, (int)Help.SC.MAXIMIZE, 0);
                    break;
                case WindowState.Close:
                    Help.PostMessage(handle, Help.WM_SYSCOMMAND, (int)Help.SC.CLOSE, 0);
                    break;
            }
        }

        public static WindowState GetWindowState(IntPtr handle = default)
        {
            if (handle == default)
            {
                handle = Stroke.CurrentWindow;
            }

            if (!Help.IsWindow(handle))
            {
                return WindowState.Close;
            }

            if (Help.IsIconic(handle))
            {
                return WindowState.Minimize;
            }
            else if (Help.IsZoomed(handle))
            {
                return WindowState.Maximize;
            }
            else
            {
                return WindowState.Normal;
            }
        }

        public static string GetWindowClassName(IntPtr handle = default)
        {
            if (handle == default)
            {
                handle = Stroke.CurrentWindow;
            }

            if (!Help.IsWindow(handle))
            {
                return "";
            }

            System.Text.StringBuilder windowClassName = new System.Text.StringBuilder(256);
            Help.GetClassName(handle, windowClassName, windowClassName.Capacity + 1);

            return windowClassName.ToString();
        }

        public static string GetWindowText(IntPtr handle = default)
        {
            if (handle == default)
            {
                handle = Stroke.CurrentWindow;
            }

            if (!Help.IsWindow(handle))
            {
                return "";
            }

            System.Text.StringBuilder windowText = new System.Text.StringBuilder(256);
            Help.GetWindowText(handle, windowText, windowText.Capacity + 1);

            return windowText.ToString();
        }

        public static uint GetWindowProcessId(IntPtr handle = default)
        {
            if (handle == default)
            {
                handle = Stroke.CurrentWindow;
            }

            if (!Help.IsWindow(handle))
            {
                return 0;
            }

            uint ProcessId;
            API.GetWindowThreadProcessId(handle, out ProcessId);
            return ProcessId;
        }

        public static bool IsTopmost(IntPtr handle = default)
        {
            if (handle == default)
            {
                handle = Stroke.CurrentWindow;
            }

            if (!Help.IsWindow(handle))
            {
                return false;
            }

            if ((API.GetWindowLong(handle, API.GWL.EXSTYLE) & (uint)API.WS_EX.TOPMOST) == (uint)API.WS_EX.TOPMOST)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void TopmostOn(IntPtr handle = default)
        {
            if (handle == default)
            {
                handle = Stroke.CurrentWindow;
            }

            if (Help.IsWindow(handle))
            {
                Help.SetWindowPos(handle, (IntPtr)API.IA.TOPMOST, 0, 0, 0, 0, API.SWP.NOSIZE | API.SWP.NOMOVE);
            }
        }

        public static void TopmostOff(IntPtr handle = default)
        {
            if (handle == default)
            {
                handle = Stroke.CurrentWindow;
            }

            if (Help.IsWindow(handle))
            {
                Help.SetWindowPos(handle, (IntPtr)API.IA.NOTOPMOST, 0, 0, 0, 0, API.SWP.NOSIZE | API.SWP.NOMOVE);
            }
        }

        public static void Run(string fileName, string arguments = "", string workingDirectory = "")
        {
            using (Process process = new Process())
            {
                process.StartInfo.FileName = fileName;
                process.StartInfo.Arguments = arguments;

                if (workingDirectory == "" && File.Exists(fileName))
                {
                    int lastSlash = fileName.LastIndexOf('\\');
                    if (lastSlash >= 0)
                        process.StartInfo.WorkingDirectory = fileName.Substring(0, lastSlash);
                }
                else
                {
                    process.StartInfo.WorkingDirectory = workingDirectory;
                }

                process.Start();
            }
        }

    }
}
