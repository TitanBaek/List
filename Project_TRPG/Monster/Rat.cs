using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TRPG
{
    public class Rat : Monster
    {
        public Rat()
        {
            this.name = "쥐";
            this.monsterType = MonsterType.동물형;
            this.hp = 50;
            this.max_hp = 50;
            this.min_ap = 1;
            this.max_ap = 5;
            this.dp = 0;
            this.exp = 10;
            this.items = new List<Item>();
            this.items.Add(new Phill());
            this.items.Add(new Leather());
        }

        public override void DropItem(Player player)
        {
            Random rand = new Random();
            int itemRoot = rand.Next(0, 100);
            // 랜덤 값이 80보다 낮으면 '알약'을 플레이어가 얻게 됨
            if (itemRoot < 80)
            {
                player.inventory.AddItem(items[0]);
            }

            // 랜덤 값이 50~60이면 추가로 '가죽'을 플레이어가 얻게 됨
            if (itemRoot >= 50 && itemRoot <= 60)
            {
                player.inventory.AddItem(items[1]);
            }
        }

        public override int RollDice()
        {
            int randomSeed = (int)DateTime.Now.Ticks;

            Random rand = new Random(randomSeed);
            int diceNumber = rand.Next(0,50);

            return diceNumber;
        }
    }
}
