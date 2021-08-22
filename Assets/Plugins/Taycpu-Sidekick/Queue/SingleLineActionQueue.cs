using System;
using System.Collections.Generic;
using System.Linq;
using CustomFeatures.Timer;

namespace Queue
{
    public class SingleLineActionQueue
    {
        private Queue<ActionTyphoon> commands = new Queue<ActionTyphoon>();
        private Action _currentTweenDel;
        private Timer _timer = new Timer();
        private ActionTyphoon currentAct;

        public void Initialize()
        {
        }

        public void SingleLineUpdate()
        {
            if (commands.Any())
            {
                if (!_timer.OnTiming)
                {
                    currentAct = commands.Peek();
                    currentAct.act?.Invoke();
                    _timer.SetTimer(() => commands.Dequeue(), currentAct.time);
                }
                else
                {
                    _timer.CalculateRemainingTime();
                }
            }
        }
        //TODO: ADD TIMER OFFSET.

        public void MultiLineUpdate()
        {
            if (commands.Any())
            {
                if (!_timer.OnTiming)
                {
                }
                else
                {
                    _timer.CalculateRemainingTime();
                }
            }
        }

        public void AddToQueue(Action action, float time)
        {
            ActionTyphoon typ = new ActionTyphoon(action, time);
            _timer.SetTimer();
            commands.Enqueue(typ);
        }
    }
}