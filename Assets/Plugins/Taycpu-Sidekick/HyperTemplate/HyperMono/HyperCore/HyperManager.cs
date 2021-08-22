using CustomFeatures;
using UnityEngine;

namespace HyperTemplate.HyperMono.HyperCore
{
    public abstract class HyperManager<T> : TaycpuSingleton<T> where T : Component
    {
        public bool IsInitialized;
        public abstract void Initialize();
    }
}