using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Platformer397 {

    [System.Serializable]
    public class PlayerData {

        public string position; //Vector3 String Format

    }

    [System.Serializable]
    public class SaveManager {
    
        private static SaveManager instance = null;

        private SaveManager() {}

        public static SaveManager Instance() {

            return instance ??= new SaveManager();

        }

        //Method To Save The Game
        public void SaveGame(Transform playerTransform) {

            BinaryFormatter formatter = new BinaryFormatter();

            var file = File.Create(Application.persistentDataPath + "/SaveData.txt");

            PlayerData data = new PlayerData {
                position = JsonUtility.ToJson(playerTransform.position)
            };

            formatter.Serialize(file, data);
            file.Close();
            Debug.Log("Game Data Was Saved At: " + Application.persistentDataPath);

        }

        //Method To Load Save Game Data
        public PlayerData LoadGame() {

            string path = Application.persistentDataPath + "/SaveData.txt";

            if (File.Exists(path)) {

                BinaryFormatter formatter = new BinaryFormatter();
                FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
                PlayerData data = formatter.Deserialize(file) as PlayerData;
                file.Close();
                return data;

            }
            return null;
        }

    }

}
