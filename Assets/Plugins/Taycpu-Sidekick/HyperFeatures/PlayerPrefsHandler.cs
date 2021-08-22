using UnityEngine;

namespace HyperFeatures
{
    public static class PlayerPrefsHandler
    {
        public static void ChangeCoin(int amount = 1)
        {
            int currentCoin = PlayerPrefs.GetInt(CONSTANTS.C_CoinPref);
            currentCoin += amount;
            PlayerPrefs.SetInt(CONSTANTS.C_CoinPref, currentCoin);
            PlayerPrefs.Save();
        }

        public static int GetCoin()
        {
            return PlayerPrefs.GetInt(CONSTANTS.C_CoinPref);
        }

        public static int GetLevel()
        {
            return PlayerPrefs.GetInt(CONSTANTS.C_LevelPref);
        }

        public static void UpdateLevel(int amount)
        {
            int currentLevel = PlayerPrefs.GetInt(CONSTANTS.C_LevelPref);
            currentLevel += amount;
            PlayerPrefs.SetInt(CONSTANTS.C_LevelPref, currentLevel);
            PlayerPrefs.Save();
        }
    }
}