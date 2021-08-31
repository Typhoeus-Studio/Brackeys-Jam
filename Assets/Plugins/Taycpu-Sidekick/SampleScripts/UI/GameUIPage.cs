using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using HyperTemplate.HyperMono.HyperUI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUIPage : HyperUIPage, IListener
{
    [SerializeField] private TextMeshProUGUI coinText;

    public override void Initialize()
    {
        base.Initialize();
    }


    public void AddCoin(string coin)
    {
        coinText.text = coin;
    }

    public void RaiseEvent()
    {
    }
}