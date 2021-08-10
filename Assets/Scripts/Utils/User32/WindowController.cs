using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace LoLRunes.Utils.User32
{
    public static class WindowController
    {
        [DllImport("user32.dll")]
        private static extern int FindWindow(string className, string windowName);

        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        public static void SetForegroundWindow(string windowName)
        {
            int hWnd = FindWindow(null, windowName);

            SetForegroundWindow((IntPtr)hWnd);
        }
    }
}