using System;
using System.Runtime.InteropServices;

namespace LoLRunes.Utils.User32
{
    #region Window Structs
    public struct PointApi
    {
        public int x;
        public int y;
    }

    public struct Rect
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
    }

    public struct WindowPlacement
    {
        public int length;
        public int flags;
        public int showCmd;
        public PointApi ptMinPosition;
        public PointApi ptMaxPosition;
        public Rect rcNormalPosition;
    }
    #endregion

    public static class WindowController
    {
        [DllImport("user32.dll")]
        private static extern int FindWindow(string className, string windowName);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowPlacement(IntPtr hWnd, ref WindowPlacement lpwndpl);

        public static void SetForegroundWindow(string windowName)
        {
            int hWnd = FindWindow(null, windowName);

            SetForegroundWindow((IntPtr)hWnd);
        }

        public static WindowPlacement GetWindowPlacementInfo(string windowName)
        {
            int hWnd = FindWindow(null, windowName);
            WindowPlacement windowPlacement = new WindowPlacement();

            GetWindowPlacement((IntPtr)hWnd, ref windowPlacement);

            return windowPlacement;
        }
    }
}