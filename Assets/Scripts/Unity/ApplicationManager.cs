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
    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        globalEventProvider = new GlobalEventProvider();
        
        
        IntPtr a = GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName);


        MouseEventExtArgs e = new MouseEventExtArgs(MouseButtons.Left, 0, 0, 0, 0);


        globalEventProvider.MouseClick += HookManager_MouseMove;        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void HookManager_MouseMove(object sender, MouseEventExtArgs e)
    {
        text.text = string.Format("x={0:0000}; y={1:0000}", e.X, e.Y) + " ------- " + count;
        count++;        
    }

    public void ButtonFindWindow()
    {
        var clickClass = new ClickClass();

        int hWnd = ClickClass.FindWindow(null, "League of Legends");
        ClickClass.SetForegroundWindow((IntPtr)hWnd);
        //ClickClass.SetCursorPos(1250, 540);
        //
        //clickClass.leftClick(new Point());
    }

    public void ButtonUnsubscribe()
    {
        globalEventProvider.MouseClick -= HookManager_MouseMove;
    }

    private void OnDestroy()
    {
        globalEventProvider.MouseClick -= HookManager_MouseMove;
    }
}
