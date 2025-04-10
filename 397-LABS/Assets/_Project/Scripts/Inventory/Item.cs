using UnityEngine;

namespace Platformer397
{
    public abstract class Item : ScriptableObject
    {
        public enum ItemType
        {
            Sword, Key, Coin
        }

        public ItemType itemType;
        public string itemName = "";
    }
}
