using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.InteropServices;
using System;
using System.Drawing;
using System.Linq;
using Gma.UserActivityMonitor;
using LoLRunes.User32;

public class ApplicationManager : MonoBehaviour
{
    [DllImport("kernel32.dll")]
    public static extern IntPtr GetModuleHandle(string name);

    [SerializeField] private TMP_Text text;

    private List<Point> positions;
    private int count;

    // Start is called before the first frame update
    void Start()
    {

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
            MSWindowsEventManager.instance.Unsubscribe_MouseDown(HookManager_MouseMove);
        }

        text.text = string.Format("x={0:0000}; y={1:0000}", e.X, e.Y);  
    }

    public void ButtonFindWindow()
    {
        WindowController.SetForegroundWindow("League of Legends");
    }

    public void ButtonPerformClicks()
    {
        WindowController.SetForegroundWindow("League of Legends");

        foreach (Point point in positions)
            MouseController.LeftClick(point);
    }

    public void ButtonUnsubscribe()
    {
        MSWindowsEventManager.instance.Unsubscribe_MouseDown(HookManager_MouseMove);
    }

    public void ButtonSynchronize()
    {
        count = 0;
        positions = new List<Point>() { Point.Empty, Point.Empty, Point.Empty, Point.Empty };

        MSWindowsEventManager.instance.Subscribe_MouseDown(HookManager_MouseMove);
    }

    private void OnDestroy()
    {
        MSWindowsEventManager.instance.UnsubscribeAll();
    }
}
