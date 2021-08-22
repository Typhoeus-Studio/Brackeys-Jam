using HyperTemplate.HyperMono.HyperCore;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class TextUIObject : HyperMonoUIObject, IListener
{
    [SerializeField] protected Text text;

    public abstract void Initialize();

    public override void FindOwnReferences()
    {
        throw new System.NotImplementedException();
    }

    public virtual void RaiseEvent()
    {
        text.text = DestText();
    }

    protected abstract string DestText();
}