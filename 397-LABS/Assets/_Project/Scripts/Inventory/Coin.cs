using UnityEngine;

namespace Platformer397
{
    [CreateAssetMenu(fileName = "Item", menuName = "Inventory/Create Coin")]
    public class Coin : ItemBase
    {
        public int value = 0;
    }
}
