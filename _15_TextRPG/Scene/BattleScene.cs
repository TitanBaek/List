using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_TextRPG
{
    internal class BattleScene : Scene
    {
        Monster monster;
        public BattleScene(Game game) : base(game)
        {
        }

        public override void Render()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("몬스터 등장");
            sb.AppendLine("1. 공격하기");
            sb.AppendLine("2. 도망가기");
            sb.AppendLine("행동을 선택하세요.");

            Console.WriteLine(sb.ToString());
        }

        public override void Update()
        {
            string input = Console.ReadLine();
        }

        public void BattleStart(Monster monster)
        {
            this.monster = monster;
            Data.monsters.Remove(monster);

            Console.Clear();
            Console.WriteLine("전투 시작!!!");
            Thread.Sleep(1000);


        }
    }
}
