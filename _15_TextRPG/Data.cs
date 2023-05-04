using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _15_TextRPG
{
    public static class Data
    {
        public static Player player;
        public static List<Monster> monsters;
        public static bool[,] map;

        public static void Init() // 최초 플레이어 초기화
        {
            player = new Player();
            monsters = new List<Monster>();
        }
        public static void LoadLevel()
        {
            map = new bool[,]
            {
                { false, false, false, false, false, false, false, false, false, false, false, false, false, false },
                { false,  true,  true,  true,  true, false,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true, false,  true,  true,  true,  true, false, false,  true, false },
                { false,  true,  true,  true,  true, false,  true,  true,  true,  true, false,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true, false,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true, false, false, false, false,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false,  true, false },
                { false,  true, false,  true,  true,  true,  true,  true,  true,  true,  true, false,  true, false },
                { false,  true, false,  true,  true,  true,  true,  true,  true,  true,  true, false,  true, false },
                { false,  true, false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false,  true, false,  true,  true,  true,  true,  true,  true,  true,  true,  true,  true, false },
                { false, false, false, false, false, false, false, false, false, false, false, false, false, false },
            };

            
            player.pos = new Position(2, 2);

            Monster slime1 = new Slime();
            slime1.pos = new Position(3, 5);
            monsters.Add(slime1);

            Monster slime2 = new Slime();
            slime2.pos = new Position(7, 5);
            monsters.Add(slime2);

            Monster dragon = new Dragon();
            dragon.pos = new Position(7, 8);
            monsters.Add(dragon);
            /*
            monsters.Clear();
            items.Clear();
            
            Slime slime1 = new Slime();
            slime1.pos = new Position(3, 5);
            monsters.Add(slime1);

            Slime slime2 = new Slime();
            slime2.pos = new Position(7, 5);
            monsters.Add(slime2);

            Dragon dragon = new Dragon();
            dragon.pos = new Position(12, 12);
            monsters.Add(dragon);

            Item potion = new Potion();
            potion.pos = new Position(12, 1);
            items.Add(potion);
            */
        }

        public static Monster MonsterInPos(Position pos)
        {
            // 플레이어와 같은 위치에 있는 몬스터 찾기
            Monster monster = monsters.Find(target => target.pos.x == pos.x && target.pos.y == pos.y);
            return monster;
        }
    }
}
