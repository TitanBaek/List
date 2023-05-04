using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_230504
{
    internal class DefensePotion : Item
    {
        private int point = 5;

        public DefensePotion()
        {
            name = "강철 물약";
            description = $"플레이어의 방어력을 영구적으로 {point} 올립니다.";
            weight = 3;
        }

        public override void Use()
        {
            Console.WriteLine($"강철 물약을 사용하여 영구적으로 플레이어의 방어력을 {point} 올립니다.");
            Thread.Sleep(1000);
            Data.player.StatusUp("DP", point);
            Console.WriteLine($"플레이어의 방어력이 {Data.player.DP}이 되었습니다.");
            Thread.Sleep(1000);
            RemoveItem();
        }
    }
}
