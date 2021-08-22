using System.Collections;
using System.Collections.Generic;
using System.Timers;
using CustomFeatures.Timer;
using HyperTemplate.HyperMono.HyperManager;
using HyperTemplate.HyperMono.HyperUI;
using UnityEngine;

public class FailUIPage : HyperUIPage
{
    public void ChangeToFailedState()
    {
        TimerProcessor.Instance.AddTimer(0.2f, () => GameManager.Instance.ChangeState(0));
    }

    public void AddCoinToBank()
    {
    }
}