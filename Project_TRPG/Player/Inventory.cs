using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TRPG
{
    public class Inventory
    {
        public Player player;
        public List<Item> items;
        public int now_weight;
        public int max_weight;

        public Inventory(Player player) {
            this.player = player;
            this.items = new List<Item>();
            this.now_weight = 0;
            this.max_weight = 100;
        }

        public void AddItem(Item item)
        {
            int temp_weight = now_weight;
            this.now_weight += item.weight;
            if (item.weight + this.now_weight > max_weight)
            {
                // 아이템을 넣을 수 없다
                Console.WriteLine($"무게 초과로 {item.name} 을(를) 가질 수 없다!");
                this.now_weight = temp_weight;
                return;
            }
            this.items.Add(item);
            Console.WriteLine($"{item.name} 을(를) 얻었다!");
        }

        public void RemoveItem(Item item)
        {
            items.Remove(item);
        }

        public void UseItem(Item item)
        {
            item.Use(player);
        }

        public void UseItem(Equip equip)
        {
            equip.TakeEquip(player);
        }

        public void TakeOffEquip(Equip equip)
        {
            equip.TakeOffEquip();
            player.playerEquip.Remove(equip.equipType);
        }
    }
}
