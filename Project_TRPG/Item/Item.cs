using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TRPG
{
    public enum ItemType { 소모품, 장비, 재료 };
    public abstract class Item
    {
        public int itemNumber = 0;
        public ItemType itemType;
        public string name;
        public int weight;

        public abstract void Use(Player player);
        //public abstract void RemoveItem();
    }
}
