﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Stroke
{
    public static class MouseHook
    {
        public enum MouseButtonStates
        {
            Move,
            Down,
            Up,
            DoubleClick,
            Wheel
        }

        public class MouseActionArgs
        {
            public readonly Point Location;
            public readonly MouseButtons MouseButton;
            public readonly MouseButtonStates MouseButtonState;
            public readonly short WheelDelta;

            public MouseActionArgs(Point location, MouseButtons mouseButton, MouseButtonStates mouseButtonState, short wheelDelta = 0)
            {
                Location = location;
                MouseButton = mouseButton;
                MouseButtonState = mouseButtonState;
                WheelDelta = wheelDelta;
            }
        }

        private static API.HOOKPROC procedure = HookCallback;
        private static IntPtr hook = IntPtr.Zero;
        public delegate bool MouseActionHandler(MouseActionArgs args);
        public static event MouseActionHandler MouseAction;
        public static bool Enable { private set; get; } = false;

        public static void StartHook()
        {
            if (Enable == false)
            {
                using (ProcessModule module = Process.GetCurrentProcess().MainModule)
                {
                    hook = API.SetWindowsHookEx(API.WH.MOUSE_LL, procedure, API.GetModuleHandle(module.ModuleName), 0);
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
                API.MSLLHOOKSTRUCT hookStruct = (API.MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(API.MSLLHOOKSTRUCT));

                if (hookStruct.dwExtraInfo == (UIntPtr)0x7FuL)
                {
                    return API.CallNextHookEx(hook, nCode, wParam, lParam);
                }

                Point location = new Point(hookStruct.pt.X, hookStruct.pt.Y);
                MouseButtons mouseButton = MouseButtons.None;
                MouseButtonStates mouseButtonState = MouseButtonStates.Move;
                short wheelDelta = 0;

                switch ((API.MouseMessages)wParam)
                {
                    case API.MouseMessages.WM_NCMOUSEMOVE:
                    case API.MouseMessages.WM_MOUSEMOVE:
                        {
                            mouseButton = MouseButtons.None;
                            mouseButtonState = MouseButtonStates.Move;
                        }
                        break;
                    case API.MouseMessages.WM_NCLBUTTONDOWN:
                    case API.MouseMessages.WM_LBUTTONDOWN:
                        {
                            mouseButton = MouseButtons.Left;
                            mouseButtonState = MouseButtonStates.Down;
                        }
                        break;
                    case API.MouseMessages.WM_NCLBUTTONUP:
                    case API.MouseMessages.WM_LBUTTONUP:
                        {
                            mouseButton = MouseButtons.Left;
                            mouseButtonState = MouseButtonStates.Up;
                        }
                        break;
                    case API.MouseMessages.WM_NCLBUTTONDBLCLK:
                    case API.MouseMessages.WM_LBUTTONDBLCLK:
                        {
                            mouseButton = MouseButtons.Left;
                            mouseButtonState = MouseButtonStates.DoubleClick;
                        }
                        break;
                    case API.MouseMessages.WM_NCRBUTTONDOWN:
                    case API.MouseMessages.WM_RBUTTONDOWN:
                        {
                            mouseButton = MouseButtons.Right;
                            mouseButtonState = MouseButtonStates.Down;
                        }
                        break;
                    case API.MouseMessages.WM_NCRBUTTONUP:
                    case API.MouseMessages.WM_RBUTTONUP:
                        {
                            mouseButton = MouseButtons.Right;
                            mouseButtonState = MouseButtonStates.Up;
                        }
                        break;
                    case API.MouseMessages.WM_NCRBUTTONDBLCLK:
                    case API.MouseMessages.WM_RBUTTONDBLCLK:
                        {
                            mouseButton = MouseButtons.Right;
                            mouseButtonState = MouseButtonStates.DoubleClick;
                        }
                        break;
                    case API.MouseMessages.WM_NCMBUTTONDOWN:
                    case API.MouseMessages.WM_MBUTTONDOWN:
                        {
                            mouseButton = MouseButtons.Middle;
                            mouseButtonState = MouseButtonStates.Down;
                        }
                        break;
                    case API.MouseMessages.WM_NCMBUTTONUP:
                    case API.MouseMessages.WM_MBUTTONUP:
                        {
                            mouseButton = MouseButtons.Middle;
                            mouseButtonState = MouseButtonStates.Up;
                        }
                        break;
                    case API.MouseMessages.WM_NCMBUTTONDBLCLK:
                    case API.MouseMessages.WM_MBUTTONDBLCLK:
                        {
                            mouseButton = MouseButtons.Middle;
                            mouseButtonState = MouseButtonStates.DoubleClick;
                        }
                        break;
                    case API.MouseMessages.WM_NCXBUTTONDOWN:
                    case API.MouseMessages.WM_XBUTTONDOWN:
                        {
                            switch ((ushort)(hookStruct.mouseData >> 16))
                            {
                                case 0x0001:
                                    mouseButton = MouseButtons.XButton1;
                                    break;
                                case 0x0002:
                                    mouseButton = MouseButtons.XButton2;
                                    break;
                            }
                            mouseButtonState = MouseButtonStates.Down;
                        }
                        break;
                    case API.MouseMessages.WM_NCXBUTTONUP:
                    case API.MouseMessages.WM_XBUTTONUP:
                        {
                            switch ((ushort)(hookStruct.mouseData >> 16))
                            {
                                case 0x0001:
                                    mouseButton = MouseButtons.XButton1;
                                    break;
                                case 0x0002:
                                    mouseButton = MouseButtons.XButton2;
                                    break;
                            }
                            mouseButtonState = MouseButtonStates.Up;
                        }
                        break;
                    case API.MouseMessages.WM_NCXBUTTONDBLCLK:
                    case API.MouseMessages.WM_XBUTTONDBLCLK:
                        {
                            switch ((ushort)(hookStruct.mouseData >> 16))
                            {
                                case 0x0001:
                                    mouseButton = MouseButtons.XButton1;
                                    break;
                                case 0x0002:
                                    mouseButton = MouseButtons.XButton2;
                                    break;
                            }
                            mouseButtonState = MouseButtonStates.DoubleClick;
                        }
                        break;
                    case API.MouseMessages.WM_MOUSEWHEEL:
                        {
                            mouseButton = MouseButtons.None;
                            mouseButtonState = MouseButtonStates.Wheel;
                            wheelDelta = (short)(hookStruct.mouseData >> 16);
                        }
                        break;
                }

                if (MouseAction(new MouseActionArgs(location, mouseButton, mouseButtonState, wheelDelta)))
                {
                    return (IntPtr)1;
                }
            }

            return API.CallNextHookEx(hook, nCode, wParam, lParam);
        }

    }
}
