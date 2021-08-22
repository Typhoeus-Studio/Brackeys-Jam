using UnityEngine;

namespace HyperTemplate.HyperMono.HyperCore
{
    public abstract class HyperGameObject : HyperMono
    {
        [HideInInspector] public bool isAvailable;

        public abstract void Initialize();
        public abstract void Dispose();
    }
}