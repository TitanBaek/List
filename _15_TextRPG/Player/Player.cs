using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_TextRPG
{
    public class Player
    {
        public Position pos;
        public char icon = 'P';

        public void Move(Direction dir)
        {
            Position prevPosition = pos;
            switch (dir)
            {
                case Direction.Up:
                    pos.y--;
                    break;
                case Direction.Down:
                    pos.y++;
                    break;
                case Direction.Left:
                    pos.x--;
                    break;
                case Direction.Right:
                    pos.x++;
                    break;
            }

            if (!Data.map[pos.y, pos.x])
            {
                this.pos = prevPosition;
            }
        }
    }
}
