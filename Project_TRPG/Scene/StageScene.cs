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
            PrintWay();
        }

        public void StageInfo()
        {
            StringBuilder sb = new StringBuilder();
            
            sb.AppendLine($"    현재 장소: {Data.stages[Data.player.pos.x, Data.player.pos.y].name}");
            sb.AppendLine(".-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= -.");

            sb.AppendLine(" -=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-= - -   ");
            sb.AppendLine($"    {Data.player.name}({Data.player.job})");
            Console.WriteLine(sb.ToString());
        }

        public void PrintWay()
        {
            Dictionary<Direction, Position> way = Data.stages[Data.player.pos.x, Data.player.pos.y].FindWay();
            foreach (KeyValuePair<Direction, Position> item in way)
            {
                Console.WriteLine("!");
                Console.WriteLine($"{item.Key}");
            }
        }

        public override void Update()
        {
            string choose = Console.ReadLine();

        }
    }
}
