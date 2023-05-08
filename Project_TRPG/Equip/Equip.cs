using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TRPG
{
    public enum EquipType { 손, 발, 상의, 하의, 투구 };

    public abstract class Equip : Item
    {
        public Player? player;
        public EquipType equipType;
        public int min_ap;
        public int max_ap;
        public int dp;
        public int hpPlus;
        public int spPlus;
        public int durability;


        // TODO. 대미지를 입었을때 내구도가 깎이는 함수 만들기
        // 1. 내구도가 0일때 아이템이 벗겨짐과 동시에 인벤토리에서 사라져야함
        // 2. 이벤트를 활용해서 만들기


        public int GetDamage()
        {
            Random random = new Random();
            int dmg = random.Next(this.min_ap, this.max_ap + 1);

            return dmg;
        }

        public int GetDefence()
        {
            return this.dp;
        }

        public void TakeEquip(Player player)
        {
            this.player = player;
        }

        public void TakeOffEquip()
        {
            this.player = null;
        }
        public void DestroyItem()
        {
            Thread.Sleep(500);
            Console.WriteLine($"와장창!");
            Thread.Sleep(500);
            Console.WriteLine($"장비 [{this.name}]이(가) 파괴 되었습니다.");
            player.inventory.TakeOffEquip(this);
            player.inventory.RemoveItem(this);
        }
        public void UsingDurability()
        {
            Random random = new Random();
            int randNum = random.Next(0, 100);

            // 랜덤수가 30보다 적으면 내구도를 1씩  차감
            if (randNum < 30)
            {
                this.durability--;
                if (this.durability <= 0)
                {
                    DestroyItem();
                }
            }
        }
    }
}
