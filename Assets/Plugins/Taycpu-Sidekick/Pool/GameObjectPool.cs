using System;
using System.Collections.Generic;
using CustomFeatures;
using HyperTemplate.HyperMono.HyperCore;
using UnityEngine;

namespace Pool
{
    [Serializable]
    public class PoolList
    {
        public List<HyperGameObject> pool;

        public float Count
        {
            get => pool.Count;
        }

        public HyperGameObject this[int i]
        {
            get { return pool[i]; }
            set { pool[i] = value; }
        }

        public void Add(HyperGameObject go)
        {
            pool.Add(go);
        }
    }
    

    public class GameObjectPool : TaycpuSingleton<GameObjectPool>
    {
        public List<PoolList> pool;

        public HyperGameObject GetItemInArray(int index)
        {
            for (int i = 0; i < pool[index].Count; i++)
            {
                if (!pool[index][i].gameObject.activeInHierarchy) return pool[index][i];
            }

            HyperGameObject newObj = Instantiate(pool[index][0], Vector3.zero, Quaternion.Euler(Vector3.zero));
            pool[index].Add(newObj);

            newObj.Dispose();
            return newObj;
        }
    }
}