using System.Collections;
using System.Collections.Generic;
using System.Timers;
using CustomFeatures.Timer;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class AfterNextLevelUI : MonoBehaviour
{
    public RectTransform[] rects;
    [SerializeField] private float yPos;
    [SerializeField] private float time;
    [SerializeField] private LoadingPage loadingPage;


    [ContextMenu("ShowIt")]
    public void Show(int i)
    {
        rects[i].anchoredPosition = new Vector2(rects[i].anchoredPosition.x, yPos);
        rects[i].gameObject.SetActive(true);
        rects[i].DOAnchorPosY(0, time).OnComplete(() =>
        {
            TimerProcessor.Instance.AddTimer(0.5f, () =>
            {
                rects[i].DOAnchorPosY(yPos + 500, time).OnComplete(() =>
                    rects[i].gameObject.SetActive(false));
            });
        });
    }
}