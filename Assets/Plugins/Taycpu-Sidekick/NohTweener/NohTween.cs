using System.Collections;
using System.Collections.Generic;
using CustomFeatures;
using UnityEngine;

namespace NohTweener
{
    public class NohTween
    {
        public Transform actor;
        public Vector3 target;
        public float Time;
    }

    public static class NohTweenExtensions
    {
        public static void NTLookAt(this Transform transform, Vector3 targetPos, float time)
        {
            NohTween nT = new NohTween();
            nT.actor = transform;
            nT.target = targetPos;
            nT.Time = time;
            TweenerProcessor.Instance.AddTween(nT);
        }
    }

    public class TweenerProcessor : TaycpuSingleton<TweenerProcessor>
    {
        private NohTween _currentTween;

        public void AddTween(NohTween tween)
        {
        }

    
    }
}