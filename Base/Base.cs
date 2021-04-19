using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Stroke
{
    public class Base
    {
        private static class API
        {
            public enum VirtualKeyCodes : ushort
            {
                VK_LBUTTON = 0x01,
                VK_RBUTTON = 0x02,
                VK_CANCEL = 0x03,
                VK_MBUTTON = 0x04,
                VK_XBUTTON1 = 0x05,
                VK_XBUTTON2 = 0x06,
                VK_BACK = 0x08,
                VK_TAB = 0x09,
                VK_CLEAR = 0x0C,
                VK_RETURN = 0x0D,
                VK_SHIFT = 0x10,
                VK_CONTROL = 0x11,
                VK_MENU = 0x12,
                VK_PAUSE = 0x13,
                VK_CAPITAL = 0x14,
                VK_KANA = 0x15,
                VK_HANGUEL = 0x15,
                VK_HANGUL = 0x15,
                VK_IME_ON = 0x16,
                VK_JUNJA = 0x17,
                VK_FINAL = 0x18,
                VK_HANJA = 0x19,
                VK_KANJI = 0x19,
                VK_IME_OFF = 0x1A,
                VK_ESCAPE = 0x1B,
                VK_CONVERT = 0x1C,
                VK_NONCONVERT = 0x1D,
                VK_ACCEPT = 0x1E,
                VK_MODECHANGE = 0x1F,
                VK_SPACE = 0x20,
                VK_PRIOR = 0x21,
                VK_NEXT = 0x22,
                VK_END = 0x23,
                VK_HOME = 0x24,
                VK_LEFT = 0x25,
                VK_UP = 0x26,
                VK_RIGHT = 0x27,
                VK_DOWN = 0x28,
                VK_SELECT = 0x29,
                VK_PRINT = 0x2A,
                VK_EXECUTE = 0x2B,
                VK_SNAPSHOT = 0x2C,
                VK_INSERT = 0x2D,
                VK_DELETE = 0x2E,
                VK_HELP = 0x2F,
                VK_0 = 0x30,
                VK_1 = 0x31,
                VK_2 = 0x32,
                VK_3 = 0x33,
                VK_4 = 0x34,
                VK_5 = 0x35,
                VK_6 = 0x36,
                VK_7 = 0x37,
                VK_8 = 0x38,
                VK_9 = 0x39,
                VK_A = 0x41,
                VK_B = 0x42,
                VK_C = 0x43,
                VK_D = 0x44,
                VK_E = 0x45,
                VK_F = 0x46,
                VK_G = 0x47,
                VK_H = 0x48,
                VK_I = 0x49,
                VK_J = 0x4A,
                VK_K = 0x4B,
                VK_L = 0x4C,
                VK_M = 0x4D,
                VK_N = 0x4E,
                VK_O = 0x4F,
                VK_P = 0x50,
                VK_Q = 0x51,
                VK_R = 0x52,
                VK_S = 0x53,
                VK_T = 0x54,
                VK_U = 0x55,
                VK_V = 0x56,
                VK_W = 0x57,
                VK_X = 0x58,
                VK_Y = 0x59,
                VK_Z = 0x5A,
                VK_LWIN = 0x5B,
                VK_RWIN = 0x5C,
                VK_APPS = 0x5D,
                VK_SLEEP = 0x5F,
                VK_NUMPAD0 = 0x60,
                VK_NUMPAD1 = 0x61,
                VK_NUMPAD2 = 0x62,
                VK_NUMPAD3 = 0x63,
                VK_NUMPAD4 = 0x64,
                VK_NUMPAD5 = 0x65,
                VK_NUMPAD6 = 0x66,
                VK_NUMPAD7 = 0x67,
                VK_NUMPAD8 = 0x68,
                VK_NUMPAD9 = 0x69,
                VK_MULTIPLY = 0x6A,
                VK_ADD = 0x6B,
                VK_SEPARATOR = 0x6C,
                VK_SUBTRACT = 0x6D,
                VK_DECIMAL = 0x6E,
                VK_DIVIDE = 0x6F,
                VK_F1 = 0x70,
                VK_F2 = 0x71,
                VK_F3 = 0x72,
                VK_F4 = 0x73,
                VK_F5 = 0x74,
                VK_F6 = 0x75,
                VK_F7 = 0x76,
                VK_F8 = 0x77,
                VK_F9 = 0x78,
                VK_F10 = 0x79,
                VK_F11 = 0x7A,
                VK_F12 = 0x7B,
                VK_F13 = 0x7C,
                VK_F14 = 0x7D,
                VK_F15 = 0x7E,
                VK_F16 = 0x7F,
                VK_F17 = 0x80,
                VK_F18 = 0x81,
                VK_F19 = 0x82,
                VK_F20 = 0x83,
                VK_F21 = 0x84,
                VK_F22 = 0x85,
                VK_F23 = 0x86,
                VK_F24 = 0x87,
                VK_NUMLOCK = 0x90,
                VK_SCROLL = 0x91,
                VK_LSHIFT = 0xA0,
                VK_RSHIFT = 0xA1,
                VK_LCONTROL = 0xA2,
                VK_RCONTROL = 0xA3,
                VK_LMENU = 0xA4,
                VK_RMENU = 0xA5,
                VK_BROWSER_BACK = 0xA6,
                VK_BROWSER_FORWARD = 0xA7,
                VK_BROWSER_REFRESH = 0xA8,
                VK_BROWSER_STOP = 0xA9,
                VK_BROWSER_SEARCH = 0xAA,
                VK_BROWSER_FAVORITES = 0xAB,
                VK_BROWSER_HOME = 0xAC,
                VK_VOLUME_MUTE = 0xAD,
                VK_VOLUME_DOWN = 0xAE,
                VK_VOLUME_UP = 0xAF,
                VK_MEDIA_NEXT_TRACK = 0xB0,
                VK_MEDIA_PREV_TRACK = 0xB1,
                VK_MEDIA_STOP = 0xB2,
                VK_MEDIA_PLAY_PAUSE = 0xB3,
                VK_LAUNCH_MAIL = 0xB4,
                VK_LAUNCH_MEDIA_SELECT = 0xB5,
                VK_LAUNCH_APP1 = 0xB6,
                VK_LAUNCH_APP2 = 0xB7,
                VK_OEM_1 = 0xBA,
                VK_OEM_PLUS = 0xBB,
                VK_OEM_COMMA = 0xBC,
                VK_OEM_MINUS = 0xBD,
                VK_OEM_PERIOD = 0xBE,
                VK_OEM_2 = 0xBF,
                VK_OEM_3 = 0xC0,
                VK_OEM_4 = 0xDB,
                VK_OEM_5 = 0xDC,
                VK_OEM_6 = 0xDD,
                VK_OEM_7 = 0xDE,
                VK_OEM_8 = 0xDF,
                VK_OEM_102 = 0xE2,
                VK_PROCESSKEY = 0xE5,
                VK_PACKET = 0xE7,
                VK_ATTN = 0xF6,
                VK_CRSEL = 0xF7,
                VK_EXSEL = 0xF8,
                VK_EREOF = 0xF9,
                VK_PLAY = 0xFA,
                VK_ZOOM = 0xFB,
                VK_NONAME = 0xFC,
                VK_PA1 = 0xFD,
                VK_OEM_CLEAR = 0xFE
            }

            [StructLayout(LayoutKind.Explicit)]
            public struct INPUT
            {
                [FieldOffset(0)]
                public INPUTTYPE type;

                [FieldOffset(4)]
                public MOUSEINPUT mi;

                [FieldOffset(4)]
                public KEYBDINPUT ki;

                [FieldOffset(4)]
                public HARDWAREINPUT hi;
            }

            public enum INPUTTYPE : uint
            {
                MOUSE,
                KEYBOARD,
                HARDWARE
            }

            public struct MOUSEINPUT
            {
                public int dx;
                public int dy;
                public uint mouseData;
                public MOUSEEVENTF dwFlags;
                public uint time;
                public UIntPtr dwExtraInfo;
            }

            public struct KEYBDINPUT
            {
                public VirtualKeyCodes wVk;
                public ushort wScan;
                public KEYEVENTF dwFlags;
                public uint time;
                public UIntPtr dwExtraInfo;
            }

            public struct HARDWAREINPUT
            {
                public uint uMsg;
                public ushort wParamL;
                public ushort wParamH;
            }

            [Flags]
            public enum MOUSEEVENTF : uint
            {
                MOVE = 0x0001,
                LEFTDOWN = 0x0002,
                LEFTUP = 0x0004,
                RIGHTDOWN = 0x0008,
                RIGHTUP = 0x0010,
                MIDDLEDOWN = 0x0020,
                MIDDLEUP = 0x0040,
                XDOWN = 0x0080,
                XUP = 0x0100,
                WHEEL = 0x0800,
                HWHEEL = 0x01000,
                MOVE_NOCOALESCE = 0x2000,
                VIRTUALDESK = 0x4000,
                ABSOLUTE = 0x8000
            }

            [Flags]
            public enum KEYEVENTF : uint
            {
                EXTENDEDKEY = 0x0001,
                KEYUP = 0x0002,
                UNICODE = 0x0004,
                SCANCODE = 0x0008
            }

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern uint SendInput(uint cInputs, ref INPUT pInput, int cbSize);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern short GetKeyState(int nVirtKey);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern IntPtr GetForegroundWindow();

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool SetForegroundWindow(IntPtr hWnd);

            public enum WindowLong : int
            {
                GWL_WNDPROC = -4,
                GWL_HINSTANCE = -6,
                GWL_ID = -12,
                GWL_STYLE = -16,
                GWL_EXSTYLE = -20,
                GWL_USERDATA = -21
            }

            [Flags]
            public enum WindowStyles : uint
            {
                WS_OVERLAPPED = 0x00000000,
                WS_TILED = 0x00000000,
                WS_MAXIMIZEBOX = 0x00010000,
                WS_TABSTOP = 0x00010000,
                WS_GROUP = 0x00020000,
                WS_MINIMIZEBOX = 0x00020000,
                WS_SIZEBOX = 0x00040000,
                WS_THICKFRAME = 0x00040000,
                WS_SYSMENU = 0x00080000,
                WS_HSCROLL = 0x00100000,
                WS_VSCROLL = 0x00200000,
                WS_DLGFRAME = 0x00400000,
                WS_BORDER = 0x00800000,
                WS_CAPTION = 0x00C00000,
                WS_MAXIMIZE = 0x01000000,
                WS_CLIPCHILDREN = 0x02000000,
                WS_CLIPSIBLINGS = 0x04000000,
                WS_DISABLED = 0x08000000,
                WS_VISIBLE = 0x10000000,
                WS_ICONIC = 0x20000000,
                WS_MINIMIZE = 0x20000000,
                WS_CHILD = 0x40000000,
                WS_CHILDWINDOW = 0x40000000,
                WS_POPUP = 0x80000000,
                WS_POPUPWINDOW = (WS_POPUP | WS_BORDER | WS_SYSMENU),
                WS_OVERLAPPEDWINDOW = (WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX),
                WS_TILEDWINDOW = (WS_OVERLAPPED | WS_CAPTION | WS_SYSMENU | WS_THICKFRAME | WS_MINIMIZEBOX | WS_MAXIMIZEBOX)
            }

            [Flags]
            public enum WindowStylesExtended : uint
            {
                WS_EX_LEFT = 0x00000000,
                WS_EX_LTRREADING = 0x00000000,
                WS_EX_RIGHTSCROLLBAR = 0x00000000,
                WS_EX_DLGMODALFRAME = 0x00000001,
                WS_EX_NOPARENTNOTIFY = 0x00000004,
                WS_EX_TOPMOST = 0x00000008,
                WS_EX_ACCEPTFILES = 0x00000010,
                WS_EX_TRANSPARENT = 0x00000020,
                WS_EX_MDICHILD = 0x00000040,
                WS_EX_TOOLWINDOW = 0x00000080,
                WS_EX_WINDOWEDGE = 0x00000100,
                WS_EX_CLIENTEDGE = 0x00000200,
                WS_EX_CONTEXTHELP = 0x00000400,
                WS_EX_RIGHT = 0x00001000,
                WS_EX_RTLREADING = 0x00002000,
                WS_EX_LEFTSCROLLBAR = 0x00004000,
                WS_EX_CONTROLPARENT = 0x00010000,
                WS_EX_STATICEDGE = 0x00020000,
                WS_EX_APPWINDOW = 0x00040000,
                WS_EX_LAYERED = 0x00080000,
                WS_EX_NOINHERITLAYOUT = 0x00100000,
                WS_EX_NOREDIRECTIONBITMAP = 0x00200000,
                WS_EX_LAYOUTRTL = 0x00400000,
                WS_EX_COMPOSITED = 0x02000000,
                WS_EX_NOACTIVATE = 0x08000000,
                WS_EX_OVERLAPPEDWINDOW = (WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE),
                WS_EX_PALETTEWINDOW = (WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST)
            }

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public extern static int GetWindowLong(IntPtr hWnd, WindowLong nIndex);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public extern static int SetWindowLong(IntPtr hWnd, WindowLong nIndex, int dwNewLong);

            public const int HWND_TOPMOST = -1;
            public const int HWND_NOTOPMOST = -2;
            public const int HWND_TOP = 0;
            public const int HWND_BOTTOM = 1;

            [Flags]
            public enum SWP : uint
            {
                NOSIZE = 0x0001,
                NOMOVE = 0x0002,
                NOZORDER = 0x0004,
                NOREDRAW = 0x0008,
                NOACTIVATE = 0x0010,
                DRAWFRAME = 0x0020,
                FRAMECHANGED = 0x0020,
                SHOWWINDOW = 0x0040,
                HIDEWINDOW = 0x0080,
                NOCOPYBITS = 0x0100,
                NOREPOSITION = 0x0200,
                NOOWNERZORDER = 0x0200,
                NOSENDCHANGING = 0x0400,
                DEFERERASE = 0x2000,
                ASYNCWINDOWPOS = 0x4000
            }

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, SWP uFlags);

            public const uint WM_SYSCOMMAND = 0x0112;

            public enum SystemCommand : int
            {
                SC_SIZE = 0xF000,
                SC_MOVE = 0xF010,
                SC_MINIMIZE = 0xF020,
                SC_MAXIMIZE = 0xF030,
                SC_NEXTWINDOW = 0xF040,
                SC_PREVWINDOW = 0xF050,
                SC_CLOSE = 0xF060,
                SC_VSCROLL = 0xF070,
                SC_HSCROLL = 0xF080,
                SC_MOUSEMENU = 0xF090,
                SC_KEYMENU = 0xF100,
                SC_RESTORE = 0xF120,
                SC_TASKLIST = 0xF130,
                SC_SCREENSAVE = 0xF140,
                SC_HOTKEY = 0xF150,
                SC_DEFAULT = 0xF160,
                SC_MONITORPOWER = 0xF170,
                SC_CONTEXTHELP = 0xF180,
                SCF_ISSECURE = 0x00000001
            }

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool IsWindow(IntPtr hWnd);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool IsZoomed(IntPtr hWnd);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool IsIconic(IntPtr hWnd);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern int GetClassName(IntPtr hWnd, System.Text.StringBuilder lpClassName, int nMaxCount);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern int GetWindowText(IntPtr hWnd, System.Text.StringBuilder lpClassName, int nMaxCount);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

            public const int WH_KEYBOARD_LL = 13;

            [StructLayout(LayoutKind.Sequential)]
            public struct KBDLLHOOKSTRUCT
            {
                public uint vkCode;
                public uint scanCode;
                public uint flags;
                public uint time;
                public UIntPtr dwExtraInfo;
            }

            public enum KeyboardMessages
            {
                WM_ACTIVATE = 0x0006,
                WM_SETFOCUS = 0x0007,
                WM_KILLFOCUS = 0x0008,

                WM_KEYDOWN = 0x0100,
                WM_KEYUP = 0x0101,

                WM_CHAR = 0x0102,
                WM_DEADCHAR = 0x0103,

                WM_SYSKEYDOWN = 0x0104,
                WM_SYSKEYUP = 0x0105,

                WM_SYSDEADCHAR = 0x0107,

                WM_UNICHAR = 0x0109,

                WM_HOTKEY = 0x0312,

                WM_APPCOMMAND = 0x0319
            }

            public delegate IntPtr HOOKPROC(int nCode, IntPtr wParam, IntPtr lParam);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern IntPtr SetWindowsHookEx(int idHook, HOOKPROC lpfn, IntPtr hMod, uint dwThreadId);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool UnhookWindowsHookEx(IntPtr hhk);

            [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

            [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern IntPtr GetModuleHandle(string lpModuleName);

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

            public delegate bool KeyboardActionHandler(KeyboardActionArgs args);
            public static event KeyboardActionHandler KeyboardAction;
            public static bool Enable = false;

            private static API.HOOKPROC _proc = HookCallback;
            private static IntPtr _hookID = IntPtr.Zero;

            public static void StartHook()
            {
                _hookID = SetHook(_proc);
                Enable = true;
            }

            public static void StopHook()
            {
                API.UnhookWindowsHookEx(_hookID);
                Enable = false;
            }

            private static IntPtr SetHook(API.HOOKPROC proc)
            {
                using (ProcessModule module = Process.GetCurrentProcess().MainModule)
                {
                    return API.SetWindowsHookEx(API.WH_KEYBOARD_LL, proc, API.GetModuleHandle(module.ModuleName), 0);
                }
            }

            private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
            {
                if (nCode < 0 || Enable == false)
                {
                    return API.CallNextHookEx(_hookID, nCode, wParam, lParam);
                }

                API.KBDLLHOOKSTRUCT hookStruct = (API.KBDLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(API.KBDLLHOOKSTRUCT));

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

                if (KeyboardAction(new KeyboardActionArgs(key, keyState)))
                {
                    return (IntPtr)1;
                }

                return API.CallNextHookEx(_hookID, nCode, wParam, lParam);
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
            input.ki.wVk = (API.VirtualKeyCodes)key;
            input.ki.dwExtraInfo = (UIntPtr)0;
            input.ki.dwFlags = 0;
            input.ki.wScan = 0;
            API.SendInput(1u, ref input, Marshal.SizeOf(typeof(API.INPUT)));
        }

        public static void KeyUp(Keys key)
        {
            API.INPUT input = new API.INPUT();
            input.type = API.INPUTTYPE.KEYBOARD;
            input.ki.time = 0;
            input.ki.wVk = (API.VirtualKeyCodes)key;
            input.ki.dwExtraInfo = (UIntPtr)0;
            input.ki.dwFlags = API.KEYEVENTF.KEYUP;
            input.ki.wScan = 0;
            API.SendInput(1u, ref input, Marshal.SizeOf(typeof(API.INPUT)));
        }

        public static void PressKeys(string keys)
        {
            keys = keys.ToUpper();

            for (int i = 0; i < keys.Length; i++)
            {
                if (keys[i] == '/')
                {
                    i++;
                    switch (keys[i])
                    {
                        case 'T':
                            KeyDown(Keys.Tab);
                            KeyUp(Keys.Tab);
                            break;
                        case 'R':
                            KeyDown(Keys.Return);
                            KeyUp(Keys.Return);
                            break;
                        case 'E':
                            KeyDown(Keys.Escape);
                            KeyUp(Keys.Escape);
                            break;
                        case 'S':
                            KeyDown(Keys.Space);
                            KeyUp(Keys.Space);
                            break;
                        case 'B':
                            KeyDown(Keys.Back);
                            KeyUp(Keys.Back);
                            break;
                        case 'I':
                            KeyDown(Keys.Insert);
                            KeyUp(Keys.Insert);
                            break;
                        case 'D':
                            KeyDown(Keys.Delete);
                            KeyUp(Keys.Delete);
                            break;
                    }
                }
                else if (keys[i] == '#')
                {
                    i++;
                    try
                    {
                        int keyCode = int.Parse(keys.Substring(i, 2), System.Globalization.NumberStyles.HexNumber);
                        KeyDown((Keys)keyCode);
                        KeyUp((Keys)keyCode);
                    }
                    finally
                    {
                        i++;
                    }
                }
                else
                {
                    switch (keys[i])
                    {
                        case '(':
                            KeyDown(Keys.ControlKey);
                            break;
                        case ')':
                            KeyUp(Keys.ControlKey);
                            break;
                        case '[':
                            KeyDown(Keys.ShiftKey);
                            break;
                        case ']':
                            KeyUp(Keys.ShiftKey);
                            break;
                        case '{':
                            KeyDown(Keys.Menu);
                            break;
                        case '}':
                            KeyUp(Keys.Menu);
                            break;
                        case '<':
                            KeyDown(Keys.LWin);
                            break;
                        case '>':
                            KeyUp(Keys.LWin);
                            break;
                    }

                    if ((keys[i] >= 0x30 && keys[i] < 0x40) || (keys[i] >= 65 && keys[i] <= 90))
                    {
                        KeyDown((Keys)keys[i]);
                        KeyUp((Keys)keys[i]);
                    }
                }
            }

        }

        public static bool IsKeyDown(Keys key)
        {
            return (API.GetKeyState((int)key) & 0x8000) == 0x8000;
        }

        public static bool IsKeyToggled(Keys key)
        {
            return (API.GetKeyState((int)key) & 0x0001) == 0x0001;
        }

        public static void Activate(IntPtr handle = default)
        {
            if (handle == default)
            {
                handle = Stroke.CurrentWindow;
            }

            if (API.IsWindow(handle))
            {
                API.SetForegroundWindow(handle);
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

            if (!API.IsWindow(handle))
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
                    API.PostMessage(handle, API.WM_SYSCOMMAND, (int)API.SystemCommand.SC_RESTORE, 0);
                    break;
                case WindowState.Minimize:
                    API.PostMessage(handle, API.WM_SYSCOMMAND, (int)API.SystemCommand.SC_MINIMIZE, 0);
                    break;
                case WindowState.Maximize:
                    API.PostMessage(handle, API.WM_SYSCOMMAND, (int)API.SystemCommand.SC_MAXIMIZE, 0);
                    break;
                case WindowState.Close:
                    API.PostMessage(handle, API.WM_SYSCOMMAND, (int)API.SystemCommand.SC_CLOSE, 0);
                    break;
            }
        }

        public static WindowState GetWindowState(IntPtr handle = default)
        {
            if (handle == default)
            {
                handle = Stroke.CurrentWindow;
            }

            if (!API.IsWindow(handle))
            {
                return WindowState.Close;
            }

            if (API.IsIconic(handle))
            {
                return WindowState.Minimize;
            }
            else if (API.IsZoomed(handle))
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

            if (!API.IsWindow(handle))
            {
                return "";
            }

            System.Text.StringBuilder windowClassName = new System.Text.StringBuilder(256);
            API.GetClassName(handle, windowClassName, windowClassName.Capacity + 1);

            return windowClassName.ToString();
        }

        public static string GetWindowText(IntPtr handle = default)
        {
            if (handle == default)
            {
                handle = Stroke.CurrentWindow;
            }

            if (!API.IsWindow(handle))
            {
                return "";
            }

            System.Text.StringBuilder windowText = new System.Text.StringBuilder(256);
            API.GetWindowText(handle, windowText, windowText.Capacity + 1);

            return windowText.ToString();
        }

        public static uint GetWindowProcessId(IntPtr handle = default)
        {
            if (handle == default)
            {
                handle = Stroke.CurrentWindow;
            }

            if (!API.IsWindow(handle))
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

            if (!API.IsWindow(handle))
            {
                return false;
            }

            if ((API.GetWindowLong(handle, API.WindowLong.GWL_EXSTYLE) & (uint)API.WindowStylesExtended.WS_EX_TOPMOST) == (uint)API.WindowStylesExtended.WS_EX_TOPMOST)
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

            if (API.IsWindow(handle))
            {
                API.SetWindowPos(handle, (IntPtr)API.HWND_TOPMOST, 0, 0, 0, 0, API.SWP.NOSIZE | API.SWP.NOMOVE);
            }
        }

        public static void TopmostOff(IntPtr handle = default)
        {
            if (handle == default)
            {
                handle = Stroke.CurrentWindow;
            }

            if (API.IsWindow(handle))
            {
                API.SetWindowPos(handle, (IntPtr)API.HWND_NOTOPMOST, 0, 0, 0, 0, API.SWP.NOSIZE | API.SWP.NOMOVE);
            }
        }

        public static void Run(string fileName, string arguments = "", string workingDirectory = "")
        {
            Process process = new Process();
            process.StartInfo.FileName = fileName;
            process.StartInfo.Arguments = arguments;

            if (workingDirectory == "" && File.Exists(fileName))
            {
                process.StartInfo.WorkingDirectory = fileName.Substring(0, fileName.LastIndexOf('\\'));
            }
            else
            {
                process.StartInfo.WorkingDirectory = workingDirectory;
            }

            process.Start();
        }

    }
}
