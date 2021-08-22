using UnityEngine;

namespace CustomFeatures
{
    public class TaycpuSingleton<T> : MonoBehaviour where T : Component
    {
        private static T instance;

        private static bool propIns;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                    if (instance == null)
                    {
                        propIns = true;

                        GameObject go = new GameObject();
                        instance = go.AddComponent<T>();
                        go.name = typeof(T).Name;
                    }
                }


                return instance;
            }
            set => instance = value;
        }

        public bool dontDestroyOnLoad;

        public void Awake()
        {
            if (propIns)
            {
                propIns = false;
                return;
            }

            if (instance != null)
            {
                Destroy(this);
                return;
            }

            Instance = this as T;

            if (dontDestroyOnLoad)
            {
                DontDestroyOnLoad(Instance);
            }
        }
    }
}