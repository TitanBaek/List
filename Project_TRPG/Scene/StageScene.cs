using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TRPG
{
    public class StageScene : Scene
    {
        public StageScene(Game game) : base(game) { }


        public override void Render()
        {
            Console.WriteLine($"{Data.player.name}({Data.player.job})");
        }

        public override void Update()
        {
            string choose = Console.ReadLine();
        }
    }
}
