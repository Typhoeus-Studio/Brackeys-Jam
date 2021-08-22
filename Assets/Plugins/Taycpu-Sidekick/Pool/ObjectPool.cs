using System.Collections.Generic;
using UnityEngine;

namespace Pool
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private List<DynamicPool> dynamicPool;
        public static ObjectPool Instance;

        private void Awake()
        {
            if (Instance != null) Destroy(Instance);
            Instance = this;
        }


        public Poolable GetFromDynamicPoolById(int id)
        {
            return dynamicPool[id].GetFromPool();
        }
    }
}