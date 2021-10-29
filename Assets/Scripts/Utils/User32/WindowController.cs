using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

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
        private static string valor = "";

        private delegate bool EnumWindowsProc(IntPtr hWnd, int lParam);

        private const int SW_SHOWNORMAL = 1;
        private const int SW_SHOWMINIMIZED = 2;
        private const int SW_SHOWMAXIMIZED = 3;

        private enum ShowWindowEnum
        {
            Hide = 0,
            ShowNormal = 1, ShowMinimized = 2, ShowMaximized = 3,
            Maximize = 3, ShowNormalNoActivate = 4, Show = 5,
            Minimize = 6, ShowMinNoActivate = 7, ShowNoActivate = 8,
            Restore = 9, ShowDefault = 10, ForceMinimized = 11
        };

        private struct WindowPlacement
        {
            public int length;
            public int flags;
            public int showCmd;
            public System.Drawing.Point ptMinPosition;
            public System.Drawing.Point ptMaxPosition;
            public System.Drawing.Rectangle rcNormalPosition;
        }

        public static bool SetFrontWindow(string processName, string windowName)
        {
            Process processe = Process.GetProcessesByName(processName).FirstOrDefault();

            if (processe == null)
                return false;

            IntPtr hWnd = FindWindowByProcessID(processe.Id, windowName);

            //get the hWnd of the process
            WindowPlacement placement = new WindowPlacement();
            GetWindowPlacement(hWnd, ref placement);

            // Check if window is minimized
            if (placement.showCmd != 2)
            {
                //the window is hidden so we restore it
                ShowWindow(hWnd, ShowWindowEnum.Hide);
                ShowWindow(hWnd, ShowWindowEnum.Restore);
            }

            //ShowWindow(hWnd, ShowWindowEnum.Maximize);
            //SetForegroundWindow(hWnd);
            //
            //ShowWindow(hWnd, ShowWindowEnum.Show);
            //SetForegroundWindow(hWnd);
            //
            //ShowWindow(hWnd, ShowWindowEnum.ShowMaximized);
            //SetForegroundWindow(hWnd);

            //set user's focus to the window
            SetForegroundWindow(hWnd);

            return true;
        }

        //public static void BringWindowToFront(string title)
        //{
        //    IntPtr wdwIntPtr = FindWindow(null, "Put_your_window_title_here");
        //
        //    //get the hWnd of the process
        //    WindowPlacement placement = new WindowPlacement();
        //    GetWindowPlacement(wdwIntPtr, ref placement);
        //
        //    // Check if window is minimized
        //    if (placement.showCmd == 2)
        //    {
        //        //the window is hidden so we restore it
        //        ShowWindow(wdwIntPtr, ShowWindowEnum.Restore);
        //    }
        //
        //    //set user's focus to the window
        //    SetForegroundWindow(wdwIntPtr);
        //}

        //public static bool GetWindowPlacementInfo(string processName, string windowName, ref WindowPlacement windowPlacement)
        //{
        //    Process processe = Process.GetProcessesByName(processName).FirstOrDefault();
        //
        //    if (processe == null)
        //        return false;
        //
        //    IntPtr hWnd = FindWindowByProcessID(processe.Id, windowName);
        //
        //    GetWindowPlacement(hWnd, ref windowPlacement);
        //
        //    return true;
        //}

        private static IntPtr FindWindowByProcessID(int processID, string windowName)
        {
            int hSaaa = FindWindow(null, windowName);

            IntPtr hShellWindow = GetShellWindow();
            IntPtr windowCode = (IntPtr)0;

            EnumWindows(delegate (IntPtr hWnd, int lParam)
            {
                if(hWnd == (IntPtr)4395392)
                {
                    int fodase = hSaaa;

                    var a = 1;
                }

                valor += " " + hWnd;                
                //ignore the shell window
                if (hWnd == hShellWindow)
                {
                    return true;
                }

                uint windowPid;
                GetWindowThreadProcessId(hWnd, out windowPid);

                //ignore windows from a different process
                if (windowPid != processID)
                {
                    return true;
                }

                StringBuilder wName = new StringBuilder(windowName.Length);
                GetWindowText(hWnd, wName, windowName.Length + 1);

                //ignore windoww with no match name
                if (windowName != wName.ToString())
                {
                    return true;
                }

                windowCode = hWnd;

                return true;

            }, 0);

            UnityEngine.Debug.Log(valor);

            return windowCode;
        }

        #region ExternalDlls
        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, ShowWindowEnum nCmdShow);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("USER32.DLL")]
        private static extern bool EnumWindows(EnumWindowsProc enumFunc, int lParam);

        [DllImport("USER32.DLL")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("USER32.DLL")]
        private static extern int GetWindowTextLength(IntPtr hWnd);

        [DllImport("USER32.DLL")]
        private static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("USER32.DLL")]
        private static extern IntPtr GetShellWindow();

        [DllImport("user32.dll")]
        private static extern int FindWindow(string className, string windowName);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetWindowPlacement(IntPtr hWnd, ref WindowPlacement lpwndpl);
        #endregion
    }
}