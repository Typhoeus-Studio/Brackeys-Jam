using System.Collections.Generic;
using System.Linq;
using CustomFeatures;
using UnityEngine;

namespace Queue
{
    public class CoroutineQueue : TaycpuSingleton<CoroutineQueue>
    {
        private Queue<CoroutineCommand> commands = new Queue<CoroutineCommand>();
        private CoroutineCommand _currentCoroutine;
        [SerializeField] private bool onAnim;

        private void Update()
        {
            if (commands.Any() && !onAnim)
            {
                onAnim = true;
                _currentCoroutine = commands.Dequeue();
                StartCoroutine(_currentCoroutine.Execute(Finished));
            }
        }

        public void AddToQueue(CoroutineCommand coroutineCommand)
        {
            commands.Enqueue(coroutineCommand);
        }

        private void Finished()
        {
            onAnim = false;
        }
    }
}