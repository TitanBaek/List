using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TRPG
{
    public enum MonsterType {인간형,동물형,사물형};
    public abstract class Monster
    {
        public string name;
        public MonsterType monsterType;
        public int hp;
        public int max_hp;
        public int min_ap;
        public int max_ap;
        public int dp;
        public int exp;
        public List<Item> items;

        public abstract int RollDice();

        public void TakeDamege(int dmg, Player player)
        {
            this.hp -= dmg;
            Console.WriteLine($"{this.name}은(는) {dmg}의 대미지를 입었다!");
            if (hp <= 0)
            {
                this.hp = 0;
                Died(player);
            }
        }
        public void AttackEnemy(Player player)
        {
            Random rand = new Random();
            int dmg = rand.Next(min_ap, max_ap + 1);          // Random을 이용하여 최소대미지와 최대대미지 범위의 값을 정해 대미지로 지정
            Console.WriteLine($"{this.name}의 공격!");
            Thread.Sleep(1000);
            player.TakeDamege(dmg);                         // 플레이어에게 공격
        }

        public void Died(Player player)
        {
            Console.WriteLine($"{this.name}은(는) 죽어버렸다!");
            GiveExp(player);
            DropItem(player);
        }
        public void GiveExp(Player player)
        {
            player.CalculExp(this.exp);
        }
        public abstract void DropItem(Player player);
    }
}
