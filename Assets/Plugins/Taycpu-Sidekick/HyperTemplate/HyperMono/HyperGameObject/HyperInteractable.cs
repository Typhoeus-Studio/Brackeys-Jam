using HyperTemplate.HyperMono.HyperCore;
using Pool;
using UnityEngine;

namespace HyperTemplate.HyperMono.HyperGameObject
{
    public abstract class HyperInteractable : HyperCentralObject
    {
        [SerializeField] private int particleIndex;
        protected bool isInteracted;

        public override void FindOwnReferences()
        {
            throw new System.NotImplementedException();
        }

        public override void Initialize()
        {
            isAvailable = true;
        }

        public override void Tick()
        {
        }

        public override void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public virtual void Interact()
        {
            if (particleIndex != -1)
            {
                ParticleSystem particle = ParticlePool.Instance.GetFromPool(particleIndex);
                particle.transform.position = transform.position;
                particle.Play();
            }

            isInteracted = true;
        }
    }
}