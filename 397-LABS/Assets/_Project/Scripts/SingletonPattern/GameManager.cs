using UnityEngine;

namespace Platformer397
{
   
    public class GameManager : Singleton<GameManager> {
       
        private Transform player;

        private void Start() {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        public void SaveGame() {
            SaveManager.Instance().SaveGame(player);
        }
        public void LoadGame() {
            PlayerData data = SaveManager.Instance().LoadGame();

            if (data == null) { return; }

            var position = JsonUtility.FromJson<Vector3>(data.position);
            player.position = position;

        }

    }

}
