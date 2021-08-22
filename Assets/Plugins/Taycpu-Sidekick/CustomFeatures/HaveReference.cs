using System;

namespace CustomFeatures
{
    [Serializable]
    public struct HaveReference<T>
    {
        public bool haveItem;
        public T item;

        public void AddItem(T obj)
        {
            if (haveItem) return;
            item = obj;
            haveItem = true;
        }

        public void RemoveItem()
        {
            if (!haveItem) return;
            item = default(T);
            haveItem = false;
        }

        public bool GetItem(out T t)
        {
            t = item;
            return haveItem;
        }
    }
}