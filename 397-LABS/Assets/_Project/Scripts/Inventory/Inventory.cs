using System.Collections.Generic;
using UnityEngine;

namespace Platformer397
{
    public class Inventory
    {
        public bool hasSword = false;
        public bool hasKey = false;

        public List<ItemBase> items;

        public Inventory()
        {
            items = new List<ItemBase>();
            Debug.Log("Inventory Created");
        }

        public void Add(ItemBase item)
        {
            items.Add(item);
        }

        public void Remove(ItemBase item)
        {
            items.Remove(item);
        }

        public ItemBase GetKey(out bool hasKey)
        {
            hasKey = false;
            foreach (ItemBase item in items)
            {
                if (item.itemType == ItemBase.ItemType.Key)
                {
                    hasKey = true;
                    return item;
                }
            }
            return null;
        }
    }
}