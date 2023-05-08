using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TRPG
{
    public class LeatherJacket : Equip
    {
        public LeatherJacket()
        {
            this.itemNumber = 4;
            this.name = "가죽자켓";
            this.player = null;
            this.itemType = ItemType.장비;
            this.equipType = EquipType.상의;
            this.min_ap = 0;
            this.max_ap = 0;
            this.dp = 10;
            this.durability = 15;
            this.weight = 10;
        }
        public override void Use(Player player)
        {
        }
    }
}
