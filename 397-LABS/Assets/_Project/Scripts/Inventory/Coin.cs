using UnityEngine;

namespace Platformer397
{
    [CreateAssetMenu(fileName = "Coin", menuName = "Inventory/Create Coin")]
    public class Coin : ItemBase
    {
        public uint value = 0;
    }
}