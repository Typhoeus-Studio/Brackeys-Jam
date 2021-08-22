using UnityEngine;

public class CoinText : TextUIObject
{
    [SerializeField] private CoinVariable coinVar;


    public override void Initialize()
    {
        coinVar.RegisterListener(this);
    }

    protected override string DestText()
    {
        return coinVar.GetCoin().ToString();
    }
}