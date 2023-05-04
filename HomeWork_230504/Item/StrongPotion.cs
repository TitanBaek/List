using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_230504
{
    internal class StrongPotion : Item
    {
        private int point = 10;

        public StrongPotion()
        {
            name = "힘의 물약";
            description = $"플레이어의 힘을 영구적으로 {point} 올립니다.";
            weight = 5;
        }

        public override void Use()
        {
            Console.WriteLine($"힘의 물약을 사용하여 영구적으로 플레이어의 힘을 {point} 올립니다.");
            Thread.Sleep(1000);
            Data.player.StatusUp("AP",point);
            Console.WriteLine($"플레이어의 힘이 {Data.player.AP}이 되었습니다.");
            Thread.Sleep(1000);
            RemoveItem();
        }
    }
}
