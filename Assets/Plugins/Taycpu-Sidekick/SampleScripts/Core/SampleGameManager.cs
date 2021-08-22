using System.Collections;
using System.Collections.Generic;
using System.Timers;
using CustomFeatures.Timer;
using HyperTemplate.HyperMono.HyperManager;
using UnityEngine;
using Timer = System.Timers.Timer;

public class SampleGameManager : GameManager
{
    [SerializeField] private ScreenManager screenManager;
    [SerializeField] private LoadingPage loadingPage;
    [SerializeField] private ClearFloatVars clear;


    public override void Awake()
    {
        base.Awake();
        clear.ClearAll();
    }

    public override void Loading()
    {
        base.Loading();
        loadingPage.Show();
        TimerProcessor.Instance.AddTimer(1f, loadingPage.Hide);
    }

    public override void AfterStatesInit()
    {
        base.AfterStatesInit();
        screenManager.Initialize();
    }
}