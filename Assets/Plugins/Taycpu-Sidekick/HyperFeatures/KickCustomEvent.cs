using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;


[Serializable]
public class KickCustomEvent : TDFeedback
{
    [SerializeField] private UnityEvent unityEvent;

    public override void Play()
    {
        unityEvent.Invoke();
    }
}