using System;
using System.Timers;
using CustomFeatures.Timer;
using HyperTemplate.HyperMono.HyperUI;
using UnityEngine;


public class LoadingPage : HyperUIPage
{
    private bool first;

    private void Awake()
    {
    }

    public override void Show()
    {
        isAnimated = first;
        base.Show();
        first = true;
    }

    public void AutoShow()
    {
        Show();
        TimerProcessor.Instance.AddTimer(0.8f, Hide);
    }
}