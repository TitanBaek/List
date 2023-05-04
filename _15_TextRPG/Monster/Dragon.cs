using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_TextRPG
{
    public class Dragon : Monster
    {
        public char icon = 'D';
        private int moveCount;

        public override void MoveAction()
        {
            if (moveCount++ % 2 != 0) return;

            List<Util.Position> path;
            bool result = Util.Astar.PathFinding(Data.map, new Util.Position(pos.x, pos.y),new Util.Position(Data.player.pos.x, Data.player.pos.y), out path);

            if (!result)
            {
                return;
            }

            if (path[1].y == pos.y - 1)
            {
                Move(Direction.Up);
            }else if (path[1].y == pos.y + 1)
            {
                Move(Direction.Down);
            }else if (path[1].x == pos.x - 1)
            {
                Move(Direction.Left);
            }
            else
            {
                Move(Direction.Right);
            }
        }
    }
}
