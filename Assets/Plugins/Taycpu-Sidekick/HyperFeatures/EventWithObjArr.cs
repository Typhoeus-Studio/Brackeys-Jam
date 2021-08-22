using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class EventWithObjArr : TDFeedback
{
    [SerializeField] private UnityEvent<object[]> unityEvent;

    public override void Play()
    {
        base.Play();
        unityEvent.Invoke(null);
    }

    public override void Play(object[] parameter)
    {
        unityEvent.Invoke(parameter);
    }
}