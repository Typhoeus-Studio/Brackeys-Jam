using System.Collections;
using System.Collections.Generic;
using CustomFeatures.Timer;
using HyperTemplate.HyperMono.HyperManager;
using HyperTemplate.HyperMono.HyperUI;
using UnityEngine;

public class WinUIPage : HyperUIPage
{
    public override void Show()
    {
        base.Show();
        //  winParticle.Play();
    }

    public void NextLevel()
    {
        TimerProcessor.Instance.AddTimer(0.2f, () => GameManager.Instance.ChangeState(0));
    }
}