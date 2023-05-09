using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TRPG
{
    public class StageScene : Scene
    {
        public StageScene(Game game) : base(game) {
        }




        public override void Render()
        {
            StageInfo();
            PlayerInfo();
            PrintWay();
        }

        public void StageInfo()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine($"    현재 장소: {Data.stages[Data.player.pos.x, Data.player.pos.y].name}");
            sb.AppendLine(".-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= -.");
            sb.AppendLine("      어디선가 이상한 소리가 들려온다..                                        ");
            sb.AppendLine(" -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= - - --");
            Console.WriteLine(sb.ToString());
        }

        public void PlayerInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"    {Data.player.name}({Data.player.job}) ");
            sb.AppendLine($"현재 체력     {Data.player.Hp}/{Data.player.Max_hp}");
            sb.AppendLine($"현재 행동력   {Data.player.Sp}/{Data.player.Max_sp}");
            sb.AppendLine($"공격력        {Data.player.Ap}");
            sb.AppendLine($"방어력        {Data.player.Dp}");
            sb.AppendLine($"행운          {Data.player.Luck}");

            Console.WriteLine(sb.ToString());
        }

        public void PrintWay()
        {
            StringBuilder sb = new StringBuilder();
            Dictionary<Direction, Position> way = Data.stages[Data.player.pos.x, Data.player.pos.y].FindWay();
            sb.Append("이동 가능한 경로 : ");
            foreach (KeyValuePair<Direction, Position> item in way)
            {
                sb.Append($"{item.Key}  ");
            }

            Console.WriteLine(sb.ToString());
        }

        public override void Update()
        {
            string choose = Console.ReadLine();

        }
    }
}
