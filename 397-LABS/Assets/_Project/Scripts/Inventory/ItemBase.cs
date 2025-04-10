using UnityEngine;

namespace Platformer397
{
    public abstract class ItemBase : ScriptableObject
    {
        public enum ItemType
        {
            Weapon,
            Key,
            Coin,
        }
        public ItemType itemType;
        public string itemName = "";
    }
}
