using System;
using System.Collections.Generic;
using System.Linq;
using CustomFeatures;
using Pool;
using UnityEditor;
using UnityEngine;

namespace Pool
{
    [Serializable]
    public class TayPools<T>
    {
        public List<T> pool = new List<T>();

        public int Count
        {
            get => pool.Count;
        }

        public T this[int i]
        {
            get { return pool[i]; }
        }

        public void Add(T t)
        {
            pool.Add(t);
        }

        public void RemoveAt(int index)
        {
            pool.RemoveAt(index);
        }
    }

    public class GenericPool<T, Y> : TaycpuSingleton<Y> where T : Component where Y : MonoBehaviour
    {
        [SerializeField] private List<TayPools<T>> pool = new List<TayPools<T>>();


        public void CreatePoolMember(int poolIndex, int amount, T item, Transform parent, bool worldSpace = false)
        {
            for (int i = 0; i < amount; i++)
            {
                pool[poolIndex].Add(Instantiate(item, parent, worldSpace));
            }
        }

        public void AddToPool(int poolIndex, T obj)
        {
            pool[poolIndex].Add(obj);
        }

        public T GetFromPool(int poolIndex)
        {
            if (pool[poolIndex] == null) Debug.LogError("PoolIndex is null!");
            for (int i = 0; i < pool[poolIndex].Count; i++)
            {
                if (pool[poolIndex][i] == null)
                {
                    pool[poolIndex].RemoveAt(i);
                    Debug.LogError("PoolIndex's " + i + ". element is null.");
                    continue;
                }

                if (!pool[poolIndex][i].gameObject.activeInHierarchy)
                {
                    pool[poolIndex][i].gameObject.SetActive(true);
                    return pool[poolIndex][i];
                }
            }

            var newObj = Instantiate(pool[poolIndex][0]);
            newObj.gameObject.SetActive(true);
            AddToPool(poolIndex, newObj);

            return newObj;
        }


        public void GetChilds()
        {
            pool.Clear();
            for (int i = 0; i < transform.childCount; i++)
            {
                var obj = transform.GetChild(i);
                pool.Add(new TayPools<T>());
                for (int j = 0; j < obj.transform.childCount; j++)
                {
                    var poolObj = obj.transform.GetChild(j).GetComponent<T>();
                    AddToPool(pool.Count - 1, poolObj);
                }
            }
        }
    }
}