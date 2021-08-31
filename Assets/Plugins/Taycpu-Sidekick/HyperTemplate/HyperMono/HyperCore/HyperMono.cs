using UnityEngine;

namespace HyperTemplate.HyperMono.HyperCore
{
    public abstract class HyperMono : MonoBehaviour
    {
        public Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }

        public abstract void FindOwnReferences();
    }
}