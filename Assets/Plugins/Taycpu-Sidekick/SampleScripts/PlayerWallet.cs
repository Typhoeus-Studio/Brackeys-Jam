using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Create PlayerWallet")]
public class PlayerWallet : UIEventRaiser
{
    public IntVariable pumpCount;
    public IntVariable dumpCount;



    public void AddPump()
    {
        pumpCount.AddCount(1);
        EventTrigger();
    }

    public void AddDump()
    {
        dumpCount.AddCount(1);
        EventTrigger();
    }

    public float[] GetProfit()
    {
        float total = dumpCount.Count + pumpCount.Count;

        float pumpPerc = pumpCount.Count / total;
        float dumpPerc = dumpCount.Count / total;

        float last = pumpPerc - dumpPerc;

        return new[] {pumpPerc, dumpPerc};
    }
}