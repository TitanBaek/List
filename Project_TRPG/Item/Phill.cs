using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TRPG
{
    internal class Phill : Item
    {
        public int point;

        public Phill()
        {
            this.itemNumber = 2;
            this.name = "알약";
            this.point = 20;
            this.itemType = ItemType.소모품;
        }

        // 플레이어의 아이템 사용 및 삭제 구현 
        public override void Use(Player player)
        {
            Console.WriteLine($"{this.name}을(를) 사용했다!");
            player.UseingItem("hp", this.point);
            player.inventory.RemoveItem(this);
        }
    }
}
