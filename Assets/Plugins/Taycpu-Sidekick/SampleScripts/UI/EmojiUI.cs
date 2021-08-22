using System;
using System.Collections;
using System.Collections.Generic;
using CustomFeatures.Timer;
using DG.Tweening;
using HyperTemplate.HyperMono.HyperUI;
using UnityEngine;

public class EmojiUI : HyperUIElement, IListener
{
    [SerializeField] private IntVariable watch;

    private void Initialize()
    {
        watch.RegisterListener(this);
    }

    public void RaiseEvent()
    {
        ScaleUpAndShake();
    }

    private void ScaleUpAndShake()
    {
        transform.DOScale(Vector3.one, 0.6f).SetEase(Ease.OutBounce).OnComplete(() =>
        {
            TimerProcessor.Instance.AddTimer(1f, () => transform.DOScale(Vector3.zero, 0.3f));
        });
    }
}