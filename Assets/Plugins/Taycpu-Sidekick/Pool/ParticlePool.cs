using UnityEngine;

namespace Pool
{
    public class ParticlePool : GenericPool<ParticleSystem, ParticlePool>
    {
        [ContextMenu("Get Childs")]
        public void GetChildsImmediaetly()
        {
            GetChilds();
        }
    }
}