using UnityEngine;

namespace Platformer397
{
    [CreateAssetMenu(fileName = "Item", menuName = "Inventory/Create Key")]

    public class Key : Item
    {
        public bool isUsed = false;
    }
}
