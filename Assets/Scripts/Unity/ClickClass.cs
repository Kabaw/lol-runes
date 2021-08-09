//you need these
using System;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;

//CLASS CLICK
public class ClickClass
{
    [DllImport("user32.dll")]
    public static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

    [DllImport("user32.dll")]
    public static extern bool SetForegroundWindow(IntPtr hWnd);

    [DllImport("user32.dll")]
    public static extern int FindWindow(string ClassName, string WindowName);

    [DllImport("user32.dll")]
    public static extern bool SetCursorPos(int X, int Y);[DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

    [DllImport("user32.dll")]
    static extern bool SetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

    private struct POINTAPI
    {
        public int x;
        public int y;
    }

    private struct RECT
    {
        public int left;
        public int top;
        public int right;
        public int bottom;
    }

    private struct WINDOWPLACEMENT
    {
        public int length;
        public int flags;
        public int showCmd;
        public POINTAPI ptMinPosition;
        public POINTAPI ptMaxPosition;
        public RECT rcNormalPosition;
    }




    [Flags]
    public enum MouseEventFlags
    {
        LEFTDOWN = 0x00000002,
        LEFTUP = 0x00000004,
        MIDDLEDOWN = 0x00000020,
        MIDDLEUP = 0x00000040,
        MOVE = 0x00000001,
        ABSOLUTE = 0x00008000,
        RIGHTDOWN = 0x00000008,
        RIGHTUP = 0x00000010
    }

    public void leftClick(Point p)
    {
        //Cursor.Position = p;
        mouse_event((int)(MouseEventFlags.LEFTDOWN), 0, 0, 0, 0);
        mouse_event((int)(MouseEventFlags.LEFTUP), 0, 0, 0, 0);
    }

    public void rightClick(Point p)
    {
        Cursor.Position = p;
        mouse_event((int)(MouseEventFlags.RIGHTDOWN), 0, 0, 0, 0);
        mouse_event((int)(MouseEventFlags.RIGHTUP), 0, 0, 0, 0);
    }

    public void doubleRightClick(Point p)
    {
        Cursor.Position = p;
        mouse_event((int)(MouseEventFlags.RIGHTDOWN), 0, 0, 0, 0);
        mouse_event((int)(MouseEventFlags.RIGHTUP), 0, 0, 0, 0);
        mouse_event((int)(MouseEventFlags.RIGHTDOWN), 0, 0, 0, 0);
        mouse_event((int)(MouseEventFlags.RIGHTUP), 0, 0, 0, 0);
    }

    public void holDownLeft(Point p, int tempo)
    {
        Cursor.Position = p;
        mouse_event((int)(MouseEventFlags.LEFTDOWN), 0, 0, 0, 0);
        Thread.Sleep(tempo);
        mouse_event((int)(MouseEventFlags.LEFTUP), 0, 0, 0, 0);
    }

    public void holDownRight(Point p, int tempo)
    {
        Cursor.Position = p;
        mouse_event((int)(MouseEventFlags.RIGHTDOWN), 0, 0, 0, 0);
        Thread.Sleep(tempo);
        mouse_event((int)(MouseEventFlags.RIGHTUP), 0, 0, 0, 0);
    }

    public static void MaximizeWindow(IntPtr hWnd)
    {
        WINDOWPLACEMENT wp = new WINDOWPLACEMENT();
        GetWindowPlacement(hWnd, ref wp);
        wp.showCmd = 3; // 1- Normal; 2 - Minimize; 3 - Maximize;
        SetWindowPlacement(hWnd, ref wp);
    }

}
