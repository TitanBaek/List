using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TRPG
{
    public class Leather : Item
    {
        public Leather() {
            this.itemNumber = 1;
            this.name = "가죽";
            this.itemType = ItemType.재료;
            this.weight = 0;
        }

        public override void Use(Player player)
        {
        }
    }
}
