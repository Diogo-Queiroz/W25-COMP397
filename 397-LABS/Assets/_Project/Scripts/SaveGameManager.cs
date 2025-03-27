using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Platformer397
{
    [System.Serializable]
    public class SaveGameManager : MonoBehaviour
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
            var file = File.Create(Application.persistentDataPath + "/SaveData.");
            PlayerData data = new PlayerData()
            {
                pos = JsonUtility.ToJson(playerTransform.position)
            };

            formatter.Serialize(file, data);
            file.Close();
        }

        public PlayerData LoadGame()
        {
            string path = Application.persistentDataPath + "/SaveData.txt";
            if (File.Exists(path))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream file = new FileStream(path, FileMode.Open);
                PlayerData data = formatter.Deserialize(file) as PlayerData;
                file.Close();
                return data;
            }
            return null;
        }
    }

    [System.Serializable]
    public class PlayerData
    {
        public string pos;
    }
}
