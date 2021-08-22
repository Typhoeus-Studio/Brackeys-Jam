using System.Collections.Generic;
using HyperTemplate.HyperMono.HyperCore;
using UnityEngine;

namespace HyperTemplate
{
    public class Level : MonoBehaviour
    {
        [SerializeField] protected List<HyperCentralObject> hyperCentralObjects;
        [SerializeField] protected List<HyperSelfGameObject> hyperSelfObjects;
        protected LevelData currentLevelData;

        public void Load(LevelData levelData)
        {
            currentLevelData = levelData;
            WhenLevelLoad();
            LateLevelLoad();
        }

        protected virtual void WhenLevelLoad()
        {
        }

        public void LateLevelLoad()
        {
            for (int q = 0; q < hyperSelfObjects.Count; q++)
            {
                hyperSelfObjects[q].Initialize();
            }

            for (int i = 0; i < hyperCentralObjects.Count; i++)
            {
                hyperCentralObjects[i].Initialize();
            }
        }

        public virtual void StartLevel()
        {
        }

        public void MainUpdate()
        {
            for (int i = 0; i < hyperCentralObjects.Count; i++)
            {
                hyperCentralObjects[i].Tick();
            }
        }

        public void MainFixedUpdate()
        {
        }

        public void MainLateUpdate()
        {
        }


        public virtual void EndLevel(bool isWin)
        {
        }

        public virtual void Dispose()
        {
        }

        [ContextMenu("Find All Single End Object And add them")]
        public void FindAllSingleEndObjects()
        {
            List<HyperCentralObject> singleEndObjects = new List<HyperCentralObject>();
            foreach (var seObj in FindObjectsOfType<HyperCentralObject>())
            {
                if (seObj.transform.parent == transform)
                    singleEndObjects.Add(seObj);
            }

            hyperCentralObjects = singleEndObjects;
        }


        public void AddManualCentralObject(HyperCentralObject cobj)
        {
            hyperCentralObjects.Add(cobj);
        }
    }
}