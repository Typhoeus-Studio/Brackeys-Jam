using System;
using DG.Tweening;
using HyperTemplate.HyperMono.HyperCore;
using UnityEngine;
using UnityEngine.Events;

namespace HyperTemplate.HyperMono.HyperUI
{
    public abstract class HyperUIPage : HyperMonoUIObject
    {
        [SerializeField] protected bool isAnimated;
        [SerializeField] private RectTransform rect;


        public override void FindOwnReferences()
        {
        }

        public virtual void Initialize()
        {
            if (isAnimated)
                rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, 2000);
        }

        public virtual void Hide()
        {
            if (isAnimated)
            {
                rect.DOAnchorPosY(2000, 0.3f).OnComplete(() => { rect.gameObject.SetActive(false); });
            }
            else
            {
                gameObject.SetActive(false);
            }
        }

        public virtual void Show()
        {
            if (isAnimated)
            {
                rect.anchoredPosition = new Vector2(rect.anchoredPosition.x, 2000);
                gameObject.SetActive(true);

                rect.DOAnchorPosY(0, 0.3f);
            }
            else
            {
                gameObject.SetActive(true);
            }
        }
    }
}