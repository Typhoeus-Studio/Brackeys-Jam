using DG.Tweening;
using HyperTemplate.HyperMono.HyperCore;
using UnityEngine;
using UnityEngine.UI;

public class ImgUIObject : HyperMonoUIObject, IListener
{
    [SerializeField] private FloatVariable passengerCount;
    [SerializeField] private FloatVariable totalCount;
    [SerializeField] private Image targetImg;
    [SerializeField] private Text totalCountUI;

    public override void FindOwnReferences()
    {
        throw new System.NotImplementedException();
    }

    public virtual void RaiseEvent()
    {
        targetImg.fillAmount = (passengerCount.Value * 100f / totalCount.Value) / 100f;
        if (targetImg.fillAmount > 0.95)
        {
            targetImg.color = Color.red;
        }
        else
        {
            targetImg.color = Color.white;
        }

        totalCountUI.text = totalCount.Value.ToString();
    }

    public void Initialize()
    {
        passengerCount.RegisterListener(this);
        RaiseEvent();
        totalCountUI.text = totalCount.Value.ToString();
    }
}