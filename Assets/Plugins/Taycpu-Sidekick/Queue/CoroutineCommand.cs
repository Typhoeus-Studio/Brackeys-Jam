using System;
using System.Collections;
using UnityEngine;

namespace Queue
{
    public abstract class CoroutineCommand
    {
        protected RectTransform indicator;
        protected float final;

        protected CoroutineCommand(RectTransform obj, float final)
        {
            this.indicator = obj;
            this.final = final;
        }


        public abstract IEnumerator Execute(Action action);
    }
}