using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TRPG
{
    internal class Hammer : Equip
    {
        public Hammer() {

            this.itemNumber = 3;
            this.name = "망치";
            this.player = null;
            this.itemType = ItemType.장비;
            this.equipType = EquipType.손;
            this.min_ap = 1;
            this.max_ap = 5;
            this.dp = 0;
            this.durability = 10;
            this.weight = 2;

        }

        public override void Use(Player player)
        {

        }
    }
}
