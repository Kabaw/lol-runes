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

        public static bool SetFrontWindow(string processName, string windowName)
        {
            Process processe = Process.GetProcessesByName(processName).FirstOrDefault();
                            
            if (processe == null)
                return false;

            IntPtr hWnd = FindWindowByProcessID(processe.Id, windowName);
            
            ShowWindow(hWnd, SW_SHOWMAXIMIZED);
            SetForegroundWindow(hWnd);

            return true;
        }

        public static bool GetWindowPlacementInfo(string processName, string windowName, ref WindowPlacement windowPlacement)
        {
            Process processe = Process.GetProcessesByName(processName).FirstOrDefault();

            if (processe == null)
                return false;

            IntPtr hWnd = FindWindowByProcessID(processe.Id, windowName);

            GetWindowPlacement(hWnd, ref windowPlacement);

            return true;
        }

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
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

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