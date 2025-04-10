using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer397
{
    public class Inventory
    {
        public bool HasSword = false;
        public bool HasKey = false;

        public List<Item> items;

        public Inventory()
        {
            items = new List<Item>();
        }

        public void Add(Item item)
        {
            items.Add(item);

        }
        public void Remove(Item item)
        {
            items.Remove(item);

        }

        public bool HasItem(Item.ItemType itemType)
        {
            foreach (Item item in items)
            {
                if (item.itemType == itemType)
                {
                    return true;
                }
            }
            return false;
        }

        public Item GetKey(out bool hasKey)
        {
            hasKey = false;
            foreach (Item item in items)
            {
                if (item.itemType == Item.ItemType.Key)
                {
                    hasKey = true;
                    return item;
                }
            }
            return null;
        }
    }
}
