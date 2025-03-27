using UnityEngine;

namespace Platformer397
{
    public class GameManager : Singleton<GameManager>
    {
        private Transform player;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        // Update is called once per frame
        public void SaveGame()
        {
            SaveGameManager.Instance().SaveGame(player);
        }

        public void LoadGame()
        {
            PlayerData data = SaveGameManager.Instance().LoadGame();
            if (data == null) { return; }
            var position = JsonUtility.FromJson<Vector3>(data.pos);
            player.position = position;
        }
    }
}
