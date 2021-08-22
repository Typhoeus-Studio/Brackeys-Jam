using System.Collections;
using System.Collections.Generic;
using HyperFeatures;
using UnityEngine;
using UnityEngine.EventSystems;

[CreateAssetMenu(menuName = "Variables/Create CoinVariable")]
public class CoinVariable : UIEventRaiser
{
    public int GetCoin()
    {
        return PlayerPrefsHandler.GetCoin();
    }

    public void SetCoin(int amount)
    {
        PlayerPrefsHandler.ChangeCoin(amount);
        EventTrigger();
    }
}