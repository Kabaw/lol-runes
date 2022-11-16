using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

namespace LoLRunes.Shared.Utils.User32
{
    #region Window Data Resources
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

    public enum ShowWindowEnum
    {
        Hide = 0,
        ShowNormal = 1, ShowMinimized = 2, ShowMaximized = 3,
        Maximize = 3, ShowNormalNoActivate = 4, Show = 5,
        Minimize = 6, ShowMinNoActivate = 7, ShowNoActivate = 8,
        Restore = 9, ShowDefault = 10, ForceMinimized = 11
    };
    #endregion

    public static class WindowController
    {

        private delegate bool EnumWindowsProc(IntPtr hWnd, int lParam);

        public static bool SetFrontWindow(string processName, string windowName)
        {
            IntPtr hWnd = GetWindowHandleID(processName, windowName);

            //get the hWnd of the process
            WindowPlacement placement = new WindowPlacement();
            GetWindowPlacement(hWnd, ref placement);

            // Check if window is minimized
            if (placement.showCmd == 2)
            {
                //the window is hidden so we restore it
                ShowWindow(hWnd, ShowWindowEnum.Restore);
            }
            else
            {
                hWnd = (IntPtr)FindWindow(null, windowName);
            }            

            //set user's focus to the window
            SetForegroundWindow(hWnd);

            return true;
        }

        public static bool GetWindowPlacementInfo(string processName, string windowName, ref WindowPlacement windowPlacement)
        {
            IntPtr hWnd = GetWindowHandleID(processName, windowName);

            GetWindowPlacement(hWnd, ref windowPlacement);

            //if (windowPlacement.showCmd != (int)ShowWindowEnum.ShowMaximized)
            //{
            //    hWnd = (IntPtr)FindWindow(null, windowName);
            //}
            //
            //GetWindowPlacement(hWnd, ref windowPlacement);
        
            return true;
        }

        private static IntPtr GetWindowHandleID(string processName, string windowName)
        {
            Process processe = Process.GetProcessesByName(processName).FirstOrDefault();

            if (processe == null)
                throw new Exception("No Process found");

            IntPtr hWnd = FindWindowByProcessID(processe.Id, windowName);

            WindowPlacement placement = new WindowPlacement();
            GetWindowPlacement(hWnd, ref placement);

            if (placement.showCmd != 2)
            {
                hWnd = (IntPtr)FindWindow(null, windowName);

                if ((int)hWnd < 1)
                    throw new Exception("No Process found");
            }

            return hWnd;
        }

        private static IntPtr FindWindowByProcessID(int processID, string windowName)
        {
            int hSaaa = FindWindow(null, windowName);

            IntPtr hShellWindow = GetShellWindow();
            IntPtr windowCode = (IntPtr)0;

            EnumWindows(delegate (IntPtr hWnd, int lParam)
            {           
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