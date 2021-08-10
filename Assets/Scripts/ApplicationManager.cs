﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Runtime.InteropServices;
using System;
using System.Drawing;
using System.Linq;
using Gma.UserActivityMonitor;
using LoLRunes.Utils.User32;
using LoLRunes.Enumerators;

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
        foreach (var item in Enum.GetValues(typeof(RuneTypeEnum)))
        {
            print(item.ToString());
        }

        WindowController.SetForegroundWindow("League of Legends");

        WindowPlacement windowPlacement = WindowController.GetWindowPlacementInfo("League of Legends");

        text.text = string.Format("top={0}; bottom={1}; left={2}; right={3}", windowPlacement.rcNormalPosition.top, windowPlacement.rcNormalPosition.bottom, windowPlacement.rcNormalPosition.left, windowPlacement.rcNormalPosition.right);
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
