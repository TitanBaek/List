using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_230504
{
    public abstract class Item
    {
        public string name;
        public string description;
        public char icon = 'I';
        public Position pos;
        public int weight;

        public abstract void Use();
        public void RemoveItem()
        {
            Data.inventory.Remove(this);
        }
    }
}
