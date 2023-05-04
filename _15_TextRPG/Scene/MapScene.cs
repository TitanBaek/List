using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _15_TextRPG
{
    internal class MapScene : Scene
    {
        public MapScene(Game game) : base(game)
        {
        }

        public override void Render()
        {
            PrintMap();
        }

        public override void Update()
        {
            ConsoleKeyInfo input = Console.ReadKey();

            // 플레이어 이동 구현
            switch (input.Key)
            {
                case ConsoleKey.UpArrow: Data.player.Move(Direction.Up); break;
                case ConsoleKey.DownArrow: Data.player.Move(Direction.Down); break;
                case ConsoleKey.LeftArrow: Data.player.Move(Direction.Left); break;
                case ConsoleKey.RightArrow: Data.player.Move(Direction.Right); break;
            }

            // 플레이어 몬스터에 접근
            Monster mosnterInPos = Data.MonsterInPos(Data.player.pos);
            if (mosnterInPos != null)
            {
                // 전투시작
                game.BattleStart(mosnterInPos);
                return;
            }

            // 몬스터 이동 구현
            foreach (Monster m in Data.monsters)
            {
                m.MoveAction();
                if (m.pos.x == Data.player.pos.x &&
                    m.pos.y == Data.player.pos.y)
                {
                    // 전투시작
                    game.BattleStart(m);
                    return;
                }
            }
        }

        private void PrintMap()
        {
            StringBuilder sb = new StringBuilder();
            for (int y = 0; y < Data.map.GetLength(0); y++)
            {
                for(int x = 0; x < Data.map.GetLength(1); x++)
                {
                    if (Data.map[y, x])
                    {
                        sb.Append(' ');
                    } else
                    {
                        sb.Append('@');
                    }
                }
                sb.AppendLine();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(sb.ToString());

            Console.ForegroundColor= ConsoleColor.Yellow;
            foreach(Monster monster in Data.monsters){
                Console.SetCursorPosition(monster.pos.x, monster.pos.y);
                Console.Write(monster.icon);
            }

            Console.ForegroundColor= ConsoleColor.Red;
            Console.SetCursorPosition(Data.player.pos.x, Data.player.pos.y);
            Console.WriteLine(Data.player.icon);
        }
    }
}
