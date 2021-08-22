using System.Collections.Generic;
using HyperTemplate.HyperMono.HyperCore;
using UnityEngine;

namespace HyperTemplate.HyperMono.HyperManager
{
    public class LevelController : HyperController
    {
        [SerializeField] private List<Level> levels;
        [SerializeField] private LevelVariable levelVariable;
        public int debugLevelIndex = -1;

        private int levelIndex;
        private int overHeatIndex;


        public void LoadLevel(LevelData levelData)
        {
            GetLevel().Load(levelData);
        }

        public void LoadLevel(Level level, LevelData levelData)
        {
            level.Load(levelData);
        }

        public Level GetSameLevel()
        {
            return levels[levelIndex];
        }

        public Level GetLevel()
        {
            if (debugLevelIndex != -1)
            {
                int ind = debugLevelIndex;
                debugLevelIndex = -1;
                return levels[ind];
            }

            return levels[overHeatIndex];
        }


        public void LevelSuccess()
        {
            levelIndex++;
            levelVariable.SetLevel(1);
            if (levelIndex > levels.Count - 1)
            {
                overHeatIndex = Random.Range(0, levels.Count);
            }
            else
            {
                overHeatIndex = levelIndex;
            }
        }


        public void DestroyLevel()
        {
            levels[levelIndex].Dispose();
        }

        public void DestroyLevel(Level level)
        {
            level.Dispose();
        }

        public override void FindOwnReferences()
        {
            throw new System.NotImplementedException();
        }
    }
}