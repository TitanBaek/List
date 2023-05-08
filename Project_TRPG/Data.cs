using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TRPG
{
    public static class Data
    {
        public static Player player;
        public static Stage[,] stages;

        public static void Init(string name, Job job)
        {
            player = new Player(name,job);

            player.inventory.AddItem(new Phill());
            player.inventory.AddItem(new Phill());
        }

        public static void LoadStages()
        {
            stages = new Stage[,]
            {
                { null, null,        null,       null,       null},
                { null, new Stage(), new Stage(),new Stage(),null},
                { null, new Stage(), null,       new Stage(),null},
                { null, new Stage(), null,       null,       null},
                { null, null,        null,       null,       null}
            };

            player.pos = new Position(3, 1);
        }

    }
}
