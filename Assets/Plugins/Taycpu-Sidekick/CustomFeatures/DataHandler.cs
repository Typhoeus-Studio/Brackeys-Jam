/*using Newtonsoft.Json;
using UnityEngine;

namespace CustomFeatures
{
    public static class DataHandler
    {
        public static string jsonDataPath;

        public static void WipeAllData()
        {
            System.IO.File.Delete(Application.persistentDataPath + "/saveData.json");

            ResetPlayerPrefs();
        }

        


        public static void SaveAllData(SaveData saveData)
        {
            var serializedPlayerDAta = JsonConvert.SerializeObject(saveData);
            System.IO.File.WriteAllText(Application.persistentDataPath + "/saveData.json", serializedPlayerDAta);
        }


        public static bool HaveSaveData()
        {
            return System.IO.File.Exists(Application.persistentDataPath + "/saveData.json");
        }
        public static SaveData GetSaveData()
        {
            string jsonData = Application.persistentDataPath + "/saveData.json";

            var obj = System.IO.File.OpenText(jsonData);
            
            SaveData saveData =
                JsonConvert.DeserializeObject<SaveData>(obj.ReadToEnd());


            return saveData;
        }

        

        public static void ResetPlayerJson()
        {
        }

        public static void ResetPlayerPrefs()
        {
            PlayerPrefs.DeleteAll();
        }
    }
}
*/

