using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Gma.UserActivityMonitor;
using System.Windows.Forms;
using TMPro;
using System.Runtime.InteropServices;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;

public class ApplicationManager : MonoBehaviour
{
    [DllImport("kernel32.dll")]
    public static extern IntPtr GetModuleHandle(string name);

    [SerializeField] private TMP_Text text;

    private GlobalEventProvider globalEventProvider;    

    private List<Point> positions;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        globalEventProvider = new GlobalEventProvider();
        
        
        IntPtr a = GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName);

        Process[] process = Process.GetProcesses().Where(p => p.ProcessName.Contains("League")).ToArray();


        MouseEventExtArgs e = new MouseEventExtArgs(MouseButtons.Left, 0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void HookManager_MouseMove(object sender, MouseEventExtArgs e)
    {       
        if (count < 4)
        {
            print(count);
            positions[count] = new Point(e.X, e.Y);
            count++;
        }
        else
        {
            globalEventProvider.MouseDown -= HookManager_MouseMove;
        }

        text.text = string.Format("x={0:0000}; y={1:0000}", e.X, e.Y); 
    }

    public void ButtonFindWindow()
    {
        var clickClass = new ClickClass();

        int hWnd = ClickClass.FindWindow(null, "League of Legends");
        //ClickClass.MaximizeWindow((IntPtr)hWnd);
        ClickClass.SetForegroundWindow((IntPtr)hWnd);
        ClickClass.SetCursorPos(1250, 540);
        //
        clickClass.leftClick(new Point());
    }

    public void ButtonPerformClicks()
    {
        var clickClass = new ClickClass();

        int hWnd = ClickClass.FindWindow(null, "League of Legends");
        ClickClass.SetForegroundWindow((IntPtr)hWnd);

        foreach (Point point in positions)
        {
            ClickClass.SetCursorPos(point.X, point.Y);
            clickClass.leftClick(new Point());
        }
    }

    public void ButtonUnsubscribe()
    {
        globalEventProvider.MouseDown -= HookManager_MouseMove;
    }

    public void ButtonSynchronize()
    {
        count = 0;
        positions = new List<Point>() { Point.Empty, Point.Empty, Point.Empty, Point.Empty };

        globalEventProvider.MouseDown += HookManager_MouseMove;
    }

    private void OnDestroy()
    {
        globalEventProvider.MouseDown -= HookManager_MouseMove;
    }
}
