using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Platformer397
{
    [System.Serializable]
    public class PlayerData
    {
        public string position;
    }

    [System.Serializable]
    public class SaveGameManager
    {
        private static SaveGameManager instance = null;
        private SaveGameManager() { }
        public static SaveGameManager Instance()
        {
            return instance ??= new SaveGameManager();
        }

        public void SaveGame(Transform playerTransform)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            var file = File.Create(Application.persistentDataPath + "/SavedData.txt");
            PlayerData data = new PlayerData 
            { 
                position = JsonUtility.ToJson(playerTransform.position)
            };

            formatter.Serialize(file, data);
            file.Close();
        }

        public PlayerData LoadGame()
        {
            string path = Application.persistentDataPath + "/SavedData.txt";
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new();
                FileStream file = new FileStream(path,FileMode.Open, FileAccess.Read);
                PlayerData data = formatter.Deserialize(file) as PlayerData;
                file.Close();
                return data;
            }
            return null;
        }
    }
}
