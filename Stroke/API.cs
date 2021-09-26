using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Stroke
{
    public class API
    {
        public enum AccessRights : uint
        {
            PROCESS_TERMINATE = 0x0001,
            PROCESS_CREATE_THREAD = 0x0002,
            PROCESS_VM_OPERATION = 0x0008,
            PROCESS_VM_READ = 0x0010,
            PROCESS_VM_WRITE = 0x0020,
            PROCESS_DUP_HANDLE = 0x0040,
            PROCESS_CREATE_PROCESS = 0x0080,
            PROCESS_SET_QUOTA = 0x0100,
            PROCESS_SET_INFORMATION = 0x0200,
            PROCESS_QUERY_INFORMATION = 0x0400,
            PROCESS_SUSPEND_RESUME = 0x0800,
            PROCESS_QUERY_LIMITED_INFORMATION = 0x1000,
            SYNCHRONIZE = 0x00100000
        }

        // Window Class Styles
        [Flags]
        public enum CS : uint
        {
            VREDRAW = 0x0001,
            HREDRAW = 0x0002,
            DBLCLKS = 0x0008,
            OWNDC = 0x0020,
            CLASSDC = 0x0040,
            PARENTDC = 0x0080,
            NOCLOSE = 0x0200,
            SAVEBITS = 0x0800,
            BYTEALIGNCLIENT = 0x1000,
            BYTEALIGNWINDOW = 0x2000,
            GLOBALCLASS = 0x4000,
            DROPSHADOW = 0x00020000
        }

        // GetAncestor
        public enum GA : uint
        {
            PARENT = 1,
            ROOT = 2,
            ROOTOWNER = 3
        }

        // GetWindowLong
        public enum GWL : int
        {
            WNDPROC = -4,
            HINSTANCE = -6,
            ID = -12,
            STYLE = -16,
            EXSTYLE = -20,
            USERDATA = -21
        }

        // InsertAfter
        public enum IA : int
        {
            TOPMOST = -1,
            NOTOPMOST = -2,
            TOP = 0,
            BOTTOM = 1
        }

        public enum INPUTTYPE : uint
        {
            MOUSE,
            KEYBOARD,
            HARDWARE
        }

        [Flags]
        public enum KEYEVENTF : uint
        {
            EXTENDEDKEY = 0x0001,
            KEYUP = 0x0002,
            UNICODE = 0x0004,
            SCANCODE = 0x0008
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

        // Pen Styles
        public enum PS : int
        {
            SOLID = 0x00000000,
            DASH = 0x00000001,
            DOT = 0x00000002,
            DASHDOT = 0x00000003,
            DASHDOTDOT = 0x00000004,
            NULL = 0x00000005,
            INSIDEFRAME = 0x00000006,
            USERSTYLE = 0x00000007,
            ALTERNATE = 0x00000008,
            STYLE_MASK = 0x0000000F,
            ENDCAP_ROUND = 0x00000000,
            ENDCAP_SQUARE = 0x00000100,
            ENDCAP_FLAT = 0x00000200,
            ENDCAP_MASK = 0x00000F00,
            JOIN_ROUND = 0x00000000,
            JOIN_BEVEL = 0x00001000,
            JOIN_MITER = 0x00002000,
            JOIN_MASK = 0x0000F000,
            COSMETIC = 0x00000000,
            GEOMETRIC = 0x00010000,
            TYPE_MASK = 0x000F0000
        }

        // System Metrics
        public enum SM : int
        {
            CXSCREEN = 0,
            CYSCREEN = 1,
            CXVSCROLL = 2,
            CYHSCROLL = 3,
            CYCAPTION = 4,
            CXBORDER = 5,
            CYBORDER = 6,
            CXDLGFRAME = 7,
            CXFIXEDFRAME = 7,
            CYDLGFRAME = 8,
            CYFIXEDFRAME = 8,
            CYVTHUMB = 9,
            CXHTHUMB = 10,
            CXICON = 11,
            CYICON = 12,
            CXCURSOR = 13,
            CYCURSOR = 14,
            CYMENU = 15,
            CXFULLSCREEN = 16,
            CYFULLSCREEN = 17,
            CYKANJIWINDOW = 18,
            MOUSEPRESENT = 19,
            CYVSCROLL = 20,
            CXHSCROLL = 21,
            DEBUG = 22,
            SWAPBUTTON = 23,
            CXMIN = 28,
            CYMIN = 29,
            CXSIZE = 30,
            CYSIZE = 31,
            CXFRAME = 32,
            CXSIZEFRAME = 32,
            CYFRAME = 33,
            CYSIZEFRAME = 33,
            CXMINTRACK = 34,
            CYMINTRACK = 35,
            CXDOUBLECLK = 36,
            CYDOUBLECLK = 37,
            CXICONSPACING = 38,
            CYICONSPACING = 39,
            MENUDROPALIGNMENT = 40,
            PENWINDOWS = 41,
            DBCSENABLED = 42,
            CMOUSEBUTTONS = 43,
            SECURE = 44,
            CXEDGE = 45,
            CYEDGE = 46,
            CXMINSPACING = 47,
            CYMINSPACING = 48,
            CXSMICON = 49,
            CYSMICON = 50,
            CYSMCAPTION = 51,
            CXSMSIZE = 52,
            CYSMSIZE = 53,
            CXMENUSIZE = 54,
            CYMENUSIZE = 55,
            ARRANGE = 56,
            CXMINIMIZED = 57,
            CYMINIMIZED = 58,
            CXMAXTRACK = 59,
            CYMAXTRACK = 60,
            CXMAXIMIZED = 61,
            CYMAXIMIZED = 62,
            NETWORK = 63,
            CLEANBOOT = 67,
            CXDRAG = 68,
            CYDRAG = 69,
            SHOWSOUNDS = 70,
            CXMENUCHECK = 71,
            CYMENUCHECK = 72,
            SLOWMACHINE = 73,
            MIDEASTENABLED = 74,
            MOUSEWHEELPRESENT = 75,
            XVIRTUALSCREEN = 76,
            YVIRTUALSCREEN = 77,
            CXVIRTUALSCREEN = 78,
            CYVIRTUALSCREEN = 79,
            CMONITORS = 80,
            SAMEDISPLAYFORMAT = 81,
            IMMENABLED = 82,
            CXFOCUSBORDER = 83,
            CYFOCUSBORDER = 84,
            TABLETPC = 86,
            MEDIACENTER = 87,
            STARTER = 88,
            SERVERR2 = 89,
            MOUSEHORIZONTALWHEELPRESENT = 91,
            CXPADDEDBORDER = 92,
            DIGITIZER = 94,
            MAXIMUMTOUCHES = 95,
            REMOTESESSION = 0x1000,
            SHUTTINGDOWN = 0x2000,
            REMOTECONTROL = 0x2001,
            CONVERTIBLESLATEMODE = 0x2003,
            SYSTEMDOCKED = 0x2004
        }

        // ShowWindow
        [Flags]
        public enum SW : int
        {
            HIDE = 0,
            NORMAL = 1,
            SHOWNORMAL = 1,
            SHOWMINIMIZED = 2,
            MAXIMIZE = 3,
            SHOWMAXIMIZED = 3,
            SHOWNOACTIVATE = 4,
            SHOW = 5,
            MINIMIZE = 6,
            SHOWMINNOACTIVE = 7,
            SHOWNA = 8,
            RESTORE = 9,
            SHOWDEFAULT = 10,
            FORCEMINIMIZE = 11
        }

        // SetWindowPos
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

        // Virtual-Key
        public enum VK : ushort
        {
            LBUTTON = 0x01,
            RBUTTON = 0x02,
            CANCEL = 0x03,
            MBUTTON = 0x04,
            XBUTTON1 = 0x05,
            XBUTTON2 = 0x06,
            BACK = 0x08,
            TAB = 0x09,
            CLEAR = 0x0C,
            RETURN = 0x0D,
            SHIFT = 0x10,
            CONTROL = 0x11,
            MENU = 0x12,
            PAUSE = 0x13,
            CAPITAL = 0x14,
            KANA = 0x15,
            HANGUEL = 0x15,
            HANGUL = 0x15,
            IME_ON = 0x16,
            JUNJA = 0x17,
            FINAL = 0x18,
            HANJA = 0x19,
            KANJI = 0x19,
            IME_OFF = 0x1A,
            ESCAPE = 0x1B,
            CONVERT = 0x1C,
            NONCONVERT = 0x1D,
            ACCEPT = 0x1E,
            MODECHANGE = 0x1F,
            SPACE = 0x20,
            PRIOR = 0x21,
            NEXT = 0x22,
            END = 0x23,
            HOME = 0x24,
            LEFT = 0x25,
            UP = 0x26,
            RIGHT = 0x27,
            DOWN = 0x28,
            SELECT = 0x29,
            PRINT = 0x2A,
            EXECUTE = 0x2B,
            SNAPSHOT = 0x2C,
            INSERT = 0x2D,
            DELETE = 0x2E,
            HELP = 0x2F,
            D0 = 0x30,
            D1 = 0x31,
            D2 = 0x32,
            D3 = 0x33,
            D4 = 0x34,
            D5 = 0x35,
            D6 = 0x36,
            D7 = 0x37,
            D8 = 0x38,
            D9 = 0x39,
            A = 0x41,
            B = 0x42,
            C = 0x43,
            D = 0x44,
            E = 0x45,
            F = 0x46,
            G = 0x47,
            H = 0x48,
            I = 0x49,
            J = 0x4A,
            K = 0x4B,
            L = 0x4C,
            M = 0x4D,
            N = 0x4E,
            O = 0x4F,
            P = 0x50,
            Q = 0x51,
            R = 0x52,
            S = 0x53,
            T = 0x54,
            U = 0x55,
            V = 0x56,
            W = 0x57,
            X = 0x58,
            Y = 0x59,
            Z = 0x5A,
            LWIN = 0x5B,
            RWIN = 0x5C,
            APPS = 0x5D,
            SLEEP = 0x5F,
            NUMPAD0 = 0x60,
            NUMPAD1 = 0x61,
            NUMPAD2 = 0x62,
            NUMPAD3 = 0x63,
            NUMPAD4 = 0x64,
            NUMPAD5 = 0x65,
            NUMPAD6 = 0x66,
            NUMPAD7 = 0x67,
            NUMPAD8 = 0x68,
            NUMPAD9 = 0x69,
            MULTIPLY = 0x6A,
            ADD = 0x6B,
            SEPARATOR = 0x6C,
            SUBTRACT = 0x6D,
            DECIMAL = 0x6E,
            DIVIDE = 0x6F,
            F1 = 0x70,
            F2 = 0x71,
            F3 = 0x72,
            F4 = 0x73,
            F5 = 0x74,
            F6 = 0x75,
            F7 = 0x76,
            F8 = 0x77,
            F9 = 0x78,
            F10 = 0x79,
            F11 = 0x7A,
            F12 = 0x7B,
            F13 = 0x7C,
            F14 = 0x7D,
            F15 = 0x7E,
            F16 = 0x7F,
            F17 = 0x80,
            F18 = 0x81,
            F19 = 0x82,
            F20 = 0x83,
            F21 = 0x84,
            F22 = 0x85,
            F23 = 0x86,
            F24 = 0x87,
            NUMLOCK = 0x90,
            SCROLL = 0x91,
            LSHIFT = 0xA0,
            RSHIFT = 0xA1,
            LCONTROL = 0xA2,
            RCONTROL = 0xA3,
            LMENU = 0xA4,
            RMENU = 0xA5,
            BROWSER_BACK = 0xA6,
            BROWSER_FORWARD = 0xA7,
            BROWSER_REFRESH = 0xA8,
            BROWSER_STOP = 0xA9,
            BROWSER_SEARCH = 0xAA,
            BROWSER_FAVORITES = 0xAB,
            BROWSER_HOME = 0xAC,
            VOLUME_MUTE = 0xAD,
            VOLUME_DOWN = 0xAE,
            VOLUME_UP = 0xAF,
            MEDIA_NEXT_TRACK = 0xB0,
            MEDIA_PREV_TRACK = 0xB1,
            MEDIA_STOP = 0xB2,
            MEDIA_PLAY_PAUSE = 0xB3,
            LAUNCH_MAIL = 0xB4,
            LAUNCH_MEDIA_SELECT = 0xB5,
            LAUNCH_APP1 = 0xB6,
            LAUNCH_APP2 = 0xB7,
            OEM_1 = 0xBA,
            OEM_PLUS = 0xBB,
            OEM_COMMA = 0xBC,
            OEM_MINUS = 0xBD,
            OEM_PERIOD = 0xBE,
            OEM_2 = 0xBF,
            OEM_3 = 0xC0,
            OEM_4 = 0xDB,
            OEM_5 = 0xDC,
            OEM_6 = 0xDD,
            OEM_7 = 0xDE,
            OEM_8 = 0xDF,
            OEM_102 = 0xE2,
            PROCESSKEY = 0xE5,
            PACKET = 0xE7,
            ATTN = 0xF6,
            CRSEL = 0xF7,
            EXSEL = 0xF8,
            EREOF = 0xF9,
            PLAY = 0xFA,
            ZOOM = 0xFB,
            NONAME = 0xFC,
            PA1 = 0xFD,
            OEM_CLEAR = 0xFE
        }

        // Windows Hook
        public enum WH : int
        {
            MSGFILTER = -1,
            JOURNALRECORD = 0,
            JOURNALPLAYBACK = 1,
            KEYBOARD = 2,
            GETMESSAGE = 3,
            CALLWNDPROC = 4,
            CBT = 5,
            SYSMSGFILTER = 6,
            MOUSE = 7,
            DEBUG = 9,
            SHELL = 10,
            FOREGROUNDIDLE = 11,
            CALLWNDPROCRET = 12,
            KEYBOARD_LL = 13,
            MOUSE_LL = 14
        }

        // Window Styles
        [Flags]
        public enum WS : uint
        {
            OVERLAPPED = 0x00000000,
            TILED = 0x00000000,
            MAXIMIZEBOX = 0x00010000,
            TABSTOP = 0x00010000,
            GROUP = 0x00020000,
            MINIMIZEBOX = 0x00020000,
            SIZEBOX = 0x00040000,
            THICKFRAME = 0x00040000,
            SYSMENU = 0x00080000,
            HSCROLL = 0x00100000,
            VSCROLL = 0x00200000,
            DLGFRAME = 0x00400000,
            BORDER = 0x00800000,
            CAPTION = 0x00C00000,
            MAXIMIZE = 0x01000000,
            CLIPCHILDREN = 0x02000000,
            CLIPSIBLINGS = 0x04000000,
            DISABLED = 0x08000000,
            VISIBLE = 0x10000000,
            ICONIC = 0x20000000,
            MINIMIZE = 0x20000000,
            CHILD = 0x40000000,
            CHILDWINDOW = 0x40000000,
            POPUP = 0x80000000,
            POPUPWINDOW = (POPUP | BORDER | SYSMENU),
            OVERLAPPEDWINDOW = (OVERLAPPED | CAPTION | SYSMENU | THICKFRAME | MINIMIZEBOX | MAXIMIZEBOX),
            TILEDWINDOW = (OVERLAPPED | CAPTION | SYSMENU | THICKFRAME | MINIMIZEBOX | MAXIMIZEBOX)
        }

        // Extended Window Styles
        [Flags]
        public enum WS_EX : uint
        {
            LEFT = 0x00000000,
            LTRREADING = 0x00000000,
            RIGHTSCROLLBAR = 0x00000000,
            DLGMODALFRAME = 0x00000001,
            NOPARENTNOTIFY = 0x00000004,
            TOPMOST = 0x00000008,
            ACCEPTFILES = 0x00000010,
            TRANSPARENT = 0x00000020,
            MDICHILD = 0x00000040,
            TOOLWINDOW = 0x00000080,
            WINDOWEDGE = 0x00000100,
            CLIENTEDGE = 0x00000200,
            CONTEXTHELP = 0x00000400,
            RIGHT = 0x00001000,
            RTLREADING = 0x00002000,
            LEFTSCROLLBAR = 0x00004000,
            CONTROLPARENT = 0x00010000,
            STATICEDGE = 0x00020000,
            APPWINDOW = 0x00040000,
            LAYERED = 0x00080000,
            NOINHERITLAYOUT = 0x00100000,
            NOREDIRECTIONBITMAP = 0x00200000,
            LAYOUTRTL = 0x00400000,
            COMPOSITED = 0x02000000,
            NOACTIVATE = 0x08000000,
            OVERLAPPEDWINDOW = (WINDOWEDGE | CLIENTEDGE),
            PALETTEWINDOW = (WINDOWEDGE | TOOLWINDOW | TOPMOST)
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

        public enum MouseMessages
        {
            WM_MOUSEACTIVATE = 0x0021,

            WM_NCHITTEST = 0x0084,

            WM_NCMOUSEMOVE = 0x00A0,
            WM_NCLBUTTONDOWN = 0x00A1,
            WM_NCLBUTTONUP = 0x00A2,
            WM_NCLBUTTONDBLCLK = 0x00A3,
            WM_NCRBUTTONDOWN = 0x00A4,
            WM_NCRBUTTONUP = 0x00A5,
            WM_NCRBUTTONDBLCLK = 0x00A6,
            WM_NCMBUTTONDOWN = 0x00A7,
            WM_NCMBUTTONUP = 0x00A8,
            WM_NCMBUTTONDBLCLK = 0x00A9,

            WM_NCXBUTTONDOWN = 0x00AB,
            WM_NCXBUTTONUP = 0x00AC,
            WM_NCXBUTTONDBLCLK = 0x00AD,

            WM_MOUSEMOVE = 0x0200,
            WM_LBUTTONDOWN = 0x0201,
            WM_LBUTTONUP = 0x0202,
            WM_LBUTTONDBLCLK = 0x0203,
            WM_RBUTTONDOWN = 0x0204,
            WM_RBUTTONUP = 0x0205,
            WM_RBUTTONDBLCLK = 0x0206,
            WM_MBUTTONDOWN = 0x0207,
            WM_MBUTTONUP = 0x0208,
            WM_MBUTTONDBLCLK = 0x0209,
            WM_MOUSEWHEEL = 0x020A,
            WM_XBUTTONDOWN = 0x020B,
            WM_XBUTTONUP = 0x020C,
            WM_XBUTTONDBLCLK = 0x020D,
            WM_MOUSEHWHEEL = 0x020E,

            WM_CAPTURECHANGED = 0x0215,

            WM_NCMOUSEHOVER = 0x02A0,
            WM_MOUSEHOVER = 0x02A1,
            WM_NCMOUSELEAVE = 0x02A2,
            WM_MOUSELEAVE = 0x02A3
        }

        public enum WindowMessages : uint
        {
            WM_NULL = 0x0000,
            WM_CREATE = 0x0001,
            WM_DESTROY = 0x0002,
            WM_MOVE = 0x0003,
            WM_SIZE = 0x0005,
            WM_ENABLE = 0x000A,
            WM_SETTEXT = 0x000C,
            WM_GETTEXT = 0x000D,
            WM_GETTEXTLENGTH = 0x000E,
            WM_CLOSE = 0x0010,
            WM_QUIT = 0x0012,
            WM_QUERYOPEN = 0x0013,
            WM_ERASEBKGND = 0x0014,
            WM_SHOWWINDOW = 0x0018,
            WM_ACTIVATEAPP = 0x001C,
            WM_CANCELMODE = 0x001F,
            WM_CHILDACTIVATE = 0x0022,
            WM_GETMINMAXINFO = 0x0024,
            WM_SETFONT = 0x0030,
            WM_GETFONT = 0x0031,
            WM_QUERYDRAGICON = 0x0037,
            WM_COMPACTING = 0x0041,
            WM_WINDOWPOSCHANGING = 0x0046,
            WM_WINDOWPOSCHANGED = 0x0047,
            WM_INPUTLANGCHANGEREQUEST = 0x0050,
            WM_INPUTLANGCHANGE = 0x0051,
            WM_USERCHANGED = 0x0054,
            WM_STYLECHANGING = 0x007C,
            WM_STYLECHANGED = 0x007D,
            WM_GETICON = 0x007F,
            WM_SETICON = 0x0080,
            WM_NCCREATE = 0x0081,
            WM_NCDESTROY = 0x0082,
            WM_NCCALCSIZE = 0x0083,
            WM_NCACTIVATE = 0x0086,
            MN_GETHMENU = 0x01E1,
            WM_SIZING = 0x0214,
            WM_MOVING = 0x0216,
            WM_ENTERSIZEMOVE = 0x0231,
            WM_EXITSIZEMOVE = 0x0232,
            WM_DPICHANGED = 0x02E0,
            WM_THEMECHANGED = 0x031A
        }

        [Serializable]
        [StructLayout(LayoutKind.Explicit, Size = 4)]
        public struct COLORREF
        {
            [FieldOffset(0)]
            public byte R;

            [FieldOffset(1)]
            public byte G;

            [FieldOffset(2)]
            public byte B;

            public COLORREF(byte r, byte g, byte b)
            {
                R = r;
                G = g;
                B = b;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public POINT(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        [StructLayout(LayoutKind.Explicit)]
        public struct RECT
        {
            [FieldOffset(0)]
            public int Left;

            [FieldOffset(4)]
            public int Top;

            [FieldOffset(8)]
            public int Right;

            [FieldOffset(12)]
            public int Bottom;

            public RECT(int left, int top, int right, int bottom)
            {
                Left = left;
                Top = top;
                Right = right;
                Bottom = bottom;
            }
        }

        public struct HARDWAREINPUT
        {
            public uint uMsg;
            public ushort wParamL;
            public ushort wParamH;
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
            public VK wVk;
            public ushort wScan;
            public KEYEVENTF dwFlags;
            public uint time;
            public UIntPtr dwExtraInfo;
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

        [StructLayout(LayoutKind.Sequential)]
        public struct MSG
        {
            public IntPtr hWnd;
            public uint message;
            public IntPtr wParam;
            public IntPtr lParam;
            public uint time;
            public POINT pt;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct KBDLLHOOKSTRUCT
        {
            public uint vkCode;
            public uint scanCode;
            public uint flags;
            public uint time;
            public UIntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public uint mouseData;
            public uint flags;
            public uint time;
            public UIntPtr dwExtraInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct WNDCLASSEX
        {
            [MarshalAs(UnmanagedType.U4)]
            public uint cbSize;
            [MarshalAs(UnmanagedType.U4)]
            public CS style;
            [MarshalAs(UnmanagedType.FunctionPtr)]
            public WNDPROC lpfnWndProc;
            public int cbClsExtra;
            public int cbWndExtra;
            public IntPtr hInstance;
            public IntPtr hIcon;
            public IntPtr hCursor;
            public IntPtr hbrBackground;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpszMenuName;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpszClassName;
            public IntPtr hIconSm;
        }


        public delegate IntPtr HOOKPROC(int nCode, IntPtr wParam, IntPtr lParam);

        public delegate IntPtr WNDPROC(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam);


        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr OpenProcess(AccessRights dwDesiredAccess, [MarshalAs(UnmanagedType.Bool)] bool bInheritHandle, uint dwProcessId);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool QueryFullProcessImageName(IntPtr hProcess, uint dwFlags, StringBuilder lpExeName, ref uint lpdwSize);


        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr CallNextHookEx(IntPtr hHook, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr CreateWindowEx(WS_EX dwExStyle, string lpClassName, string lpWindowName, WS dwStyle, int X, int Y, int nWidth, int nHeight, IntPtr hWndParent, IntPtr hMenu, IntPtr hInstance, IntPtr lpParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr DefWindowProc(IntPtr hWnd, uint uMsg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool DestroyWindow(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr DispatchMessage([In] ref MSG lpMsg);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr GetAncestor(IntPtr hWnd, GA gaFlags);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr GetDC(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetMessage(out MSG lpMsg, IntPtr hWnd, uint wMsgFilterMin, uint wMsgFilterMax);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetSystemMetrics(SM nIndex);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetWindowLong(IntPtr hWnd, GWL nIndex);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool InvalidateRect(IntPtr hWnd, ref RECT lpRect, bool bErase);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern void PostQuitMessage(int nExitCode);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern uint SendInput(uint cInputs, ref INPUT pInput, int cbSize);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetLayeredWindowAttributes(IntPtr hWnd, COLORREF crKey, byte bAlpha, uint dwFlags);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx(WH idHook, HOOKPROC lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int SetWindowLong(IntPtr hWnd, GWL nIndex, int dwNewLong);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetWindowPos(IntPtr hWnd, IA hWndInsertAfter, int X, int Y, int cx, int cy, SWP uFlags);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ShowWindow(IntPtr hWnd, SW nCmdShow);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool TranslateMessage([In] ref MSG lpMsg);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.U2)]
        public static extern ushort RegisterClassEx([In] ref WNDCLASSEX lpWndClass);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnhookWindowsHookEx(IntPtr hHook);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr WindowFromPoint(POINT Point);


        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr CreatePen(PS iStyle, int cWidth, COLORREF color);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr CreateSolidBrush(COLORREF color);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool LineTo(IntPtr hDC, int x, int y);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool MoveToEx(IntPtr hDC, int x, int y, IntPtr lpPoint);

        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SelectObject([In] IntPtr hDC, [In] IntPtr hObject);
    }
}
