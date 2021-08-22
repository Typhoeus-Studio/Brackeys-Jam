using Queue;
using UnityEngine;

namespace CustomFeatures
{
    public class BaseCoreUpdate : MonoBehaviour
    {
        private MultilineActionQueue multiAction = new MultilineActionQueue();

        public MultilineActionQueue MultiAction => multiAction;

        private void Start()
        {
            multiAction.Initialize();
        }

        private void Update()
        {
            multiAction.MultiLineUpdate();
        }
    }
}