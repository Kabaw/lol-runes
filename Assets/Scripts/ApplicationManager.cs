using System.Collections;
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
using LoLRunes.ScriptableObjects;

public class ApplicationManager : MonoBehaviour
{
    [DllImport("kernel32.dll")]
    public static extern IntPtr GetModuleHandle(string name);

    [SerializeField] private TMP_Text text;
    [SerializeField] private string numbers;
    [SerializeField] private float clickDelay;
    [SerializeField] private ResolutionRunePositionConfig resolutionRunePositionConfig;

    private List<Point> positions;
    private int count;
    private string mouseClickLog;        

    // Start is called before the first frame update
    void Start()
    {
        string[] breakNumbers = numbers.Split(new char[] { ';' });
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void HookManager_MouseMove(object sender, MouseEventExtArgs e)
    {       
        if (count < 10000000)
        {
            //print(count);
            //positions[count] = new Point(e.X, e.Y);
            //mouseClickLog += String.Format("{0} {1};", e.X, e.Y);
            print("X = " + (1133 - e.X) + " --- Y = " + (317 - e.Y));
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
        //WindowController.SetForegroundWindow("League of Legends");
        //
        //foreach (Point point in positions)
        //    MouseController.LeftClick(point);

        StartCoroutine(PerformClicks());
    }

    public IEnumerator PerformClicks()
    {
        WindowController.SetForegroundWindow("League of Legends");

        WindowPlacement windowPlacement = WindowController.GetWindowPlacementInfo("League of Legends");

        foreach (string pointText in resolutionRunePositionConfig.Positions.Split(new char[] { ';' }))
        {
            string[] pointValueText = pointText.Split(new char[] { ' ' });

            Point point = new Point(
                windowPlacement.rcNormalPosition.left + (int.Parse(pointValueText[0]) - resolutionRunePositionConfig.WindowX),
                windowPlacement.rcNormalPosition.top + (int.Parse(pointValueText[1]) - resolutionRunePositionConfig.WindowY));

            MouseController.LeftClick(point);

            yield return new WaitForSeconds(clickDelay);
        }
    }

    public void ButtonUnsubscribe()
    {
        MSWindowsEventManager.instance.Unsubscribe_MouseDown(HookManager_MouseMove);
    }

    public void ButtonSynchronize()
    {
        count = 0;
        positions = new List<Point>() { Point.Empty, Point.Empty, Point.Empty, Point.Empty };

        mouseClickLog = "";

        MSWindowsEventManager.instance.Subscribe_MouseDown(HookManager_MouseMove);
    }

    private void OnDestroy()
    {
        MSWindowsEventManager.instance.Unsubscribe_MouseDown(HookManager_MouseMove);
        MSWindowsEventManager.instance.UnsubscribeAll();
    }
}
