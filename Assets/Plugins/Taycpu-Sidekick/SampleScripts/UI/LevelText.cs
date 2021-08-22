using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelText : TextUIObject
{
    [SerializeField] private LevelVariable levelVar;

    public override void Initialize()
    {
        levelVar.RegisterListener(this);
        RaiseEvent();
        
    }

    protected override string DestText()
    {
        return "LEVEL "+(levelVar.GetLevel() + 1).ToString();
    }
}