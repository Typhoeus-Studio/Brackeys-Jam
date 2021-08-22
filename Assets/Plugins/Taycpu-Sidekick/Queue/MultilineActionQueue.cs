using System;
using System.Collections.Generic;
using System.Linq;
using CustomFeatures.Timer;

namespace Queue
{
    public class MultilineActionQueue
    {
        private List<Queue<ActionTyphoon>> commands = new List<Queue<ActionTyphoon>>();
        private Action _currentTweenDel;
        private Timer _timer = new Timer();
        private ActionTyphoon currentAct;

        public bool haveElement;

        public void Initialize()
        {
        }

        public void MultiLineUpdate()
        {
            if (commands.Any())
            {
                for (int i = 0; i < commands.Count; i++)
                {
                    if (commands[i].Any())
                    {
                        if (!_timer.OnTiming)
                        {
                            var i1 = i;
                            _timer.SetTimer(() =>
                            {
                                currentAct = commands[i1].Peek();
                                currentAct.act?.Invoke();

                                commands[i1].Dequeue();
                            }, currentAct.time);
                        }
                        else
                        {
                            _timer.CalculateRemainingTime();
                        }

                        if (commands[i].Count < 1)
                        {
                            commands.RemoveAt(i);
                            haveElement = false;
                        }
                    }
                }
            }
        }
        //TODO: ADD TIMER OFFSET.


        public void AddToQueue(Action action, float time, int line)
        {
            ActionTyphoon typ = new ActionTyphoon(action, time);
            if (commands.Count < line)
            {
                commands.Add(new Queue<ActionTyphoon>());
                line = commands.Count - 1;
            }

            commands[line].Enqueue(typ);
        }
    }
}