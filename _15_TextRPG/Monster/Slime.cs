using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_TextRPG
{
    public class Slime : Monster
    {
        private int moveCount;
        public override void MoveAction()
        {
            if (moveCount++ % 3 != 0) return;
            // 랜덤한 움직임을 구현
            Random random = new Random();
            switch (random.Next(0,4))
            {
                case 0: Move(Direction.Up); break;
                case 1: Move(Direction.Down); break;
                case 2: Move(Direction.Left); break;
                case 3: Move(Direction.Right); break;
            }
        }
    }
}
