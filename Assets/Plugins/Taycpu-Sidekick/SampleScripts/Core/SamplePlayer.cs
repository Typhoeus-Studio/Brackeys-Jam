using System;
using CustomFeatures;
using HyperFeatures;
using HyperTemplate.HyperMono.HyperGameObject;
using UnityEngine;



public class SamplePlayer : HyperPlayer
{
    [SerializeField] private TouchHelper touchHelper;
    [SerializeField] private RunnerMovementHelper runnerMovement;
    [SerializeField] private CoinVariable coinVariable;

    public override void Initialize()
    {
        base.Initialize();
    }

    public override void ReadyForStart()
    {
        base.ReadyForStart();
        animator.Play(aMediator.idle);
    }

    public override void StartLevel()
    {
        base.StartLevel();
        animator.Play(aMediator.walk);
    }

    public void EarnCoin()
    {
        coinVariable.SetCoin(1);
    }


    private void Update()
    {
        if (!canRun) return;
        runnerMovement.RunnerMovementRigidbody(rb, touchHelper.CheckForInput());
    }
}