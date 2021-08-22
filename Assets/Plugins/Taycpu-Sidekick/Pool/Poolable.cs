using UnityEngine;

namespace Pool
{
    public abstract class Poolable:MonoBehaviour
    {
        public bool available;
        public abstract void OnCall(Vector3 pos);
        public abstract void OnReset();
    }
}