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
using System.Diagnostics;

public class ApplicationTestManager : MonoBehaviour
{
    [DllImport("kernel32.dll")]
    public static extern IntPtr GetModuleHandle(string name);

    [SerializeField] private TMP_Text text;
    [SerializeField] private string numbers;
    [SerializeField] private float clickDelay;
    [SerializeField] private ResolutionRunePositionConfig _resolutionRunePositionConfig;

    private List<Point> positions;
    private int count;
    private string mouseClickLog;

    public ResolutionRunePositionConfig resolutionRunePositionConfig => _resolutionRunePositionConfig;

    // Start is called before the first frame update
    void Start()
    {
        string[] breakNumbers = numbers.Split(new char[] { ';' });

        Process[] processes = Process.GetProcesses().Where(p => p.ProcessName.Contains("League")).ToArray();
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
        //foreach (var item in Enum.GetValues(typeof(RuneTypeEnum)))
        //{
        //    print(item.ToString());
        //}

        WindowPlacement windowPlacement = new WindowPlacement();

        WindowController.SetFrontWindow("LeagueClientUx", "League of Legends");
        //WindowController.GetWindowPlacementInfo("LeagueClientUx", "League of Legends", ref windowPlacement);

        //text.text = string.Format("top={0}; bottom={1}; left={2}; right={3}", windowPlacement.rcNormalPosition.top, windowPlacement.rcNormalPosition.bottom, windowPlacement.rcNormalPosition.left, windowPlacement.rcNormalPosition.right);
    }

    public void ButtonPerformClicks()
    {
        //WindowController.SetForegroundWindow("League of Legends");
        //
        //foreach (Point point in positions)
        //    MouseController.LeftClick(point);

        mouseClickLog = "";

        StartCoroutine(PerformClicks());
    }

    public IEnumerator PerformClicks()
    {
        WindowPlacement windowPlacement = new WindowPlacement();
                
        //WindowController.GetWindowPlacementInfo("LeagueClientUx", "League of Legends", ref windowPlacement);

        foreach (string pointText in _resolutionRunePositionConfig.RelativePositions.Split(new char[] { ';' }))
        {
            string[] pointValueText = pointText.Split(new char[] { ' ' });
            int x = windowPlacement.rcNormalPosition.left + (int.Parse(pointValueText[0]));
            int y = windowPlacement.rcNormalPosition.top + (int.Parse(pointValueText[1]));

            Point point = new Point(x, y);

            mouseClickLog += String.Format("{0} {1};", (int.Parse(pointValueText[0])) - windowPlacement.rcNormalPosition.left, (int.Parse(pointValueText[1])) - windowPlacement.rcNormalPosition.top);
            //print("X = " + windowPlacement.rcNormalPosition.left + (int.Parse(pointValueText[0]) - resolutionRunePositionConfig.WindowX + " --- Y = " + windowPlacement.rcNormalPosition.top + (int.Parse(pointValueText[1]) - resolutionRunePositionConfig.WindowY)));

            MouseController.LeftClick(point);

            yield return new WaitForSeconds(clickDelay);
        }

        print(mouseClickLog);
    }

    public void SetFrontWindow()
    {
        WindowController.SetFrontWindow("LeagueClientUx", "League of Legends");
    }

    public void GetWindowPlacement()
    {
        WindowPlacement windowPlacement = new WindowPlacement();

        //WindowController.GetWindowPlacementInfo("LeagueClientUx", "League of Legends", ref windowPlacement);
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

        WindowPlacement windowPlacement = new WindowPlacement();

        //WindowController.GetWindowPlacementInfo("LeagueClientUx", "League of Legends", ref windowPlacement);

        MSWindowsEventManager.instance.Subscribe_MouseDown(HookManager_MouseMove);
    }

    private void OnDestroy()
    {
        MSWindowsEventManager.instance.Unsubscribe_MouseDown(HookManager_MouseMove);
        MSWindowsEventManager.instance.UnsubscribeAll();
    }
}
