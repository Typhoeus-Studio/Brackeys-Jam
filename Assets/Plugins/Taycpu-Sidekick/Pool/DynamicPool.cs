using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Pool
{
    [Serializable]
    public class DynamicPool
    {
        public string key;
        [SerializeField] private List<Poolable> pool;

        public DynamicPool(string key, List<Poolable> pool)
        {
            this.key = key;
            this.pool = pool;
        }

        public void AddToPool(Poolable obj)
        {
            pool.Add(obj);
        }

        public Poolable GetFromPool()
        {
            for (int i = 0; i < pool.Count; i++)
            {
                if (pool[i].available)
                {
                    pool[i].available = false;
                    return pool[i];
                }
            }

            AddToPool(Object.Instantiate(pool[0]));

            return pool[pool.Count - 1];
        }
    }
}