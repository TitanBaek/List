using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TRPG
{
    public class Stage
    {
        public string name = "";
        public bool isSearch = false;
        public Player player;
        string[] str_subtitle = new string[] {"불 꺼진","어두운","피비린내 나는","좋은 향기가 나는","무서운 소리가 들리는","평범한","음침한","소름끼치는","뭔가 느낌이 좋은","그냥","으르렁거리는 소리가 들리는","뭐가 나올지 모를","전자음이 들리는","바람소리가 들리는" };
        string[] str_location = new string[] {"방","복도","사무실","창고","화장실","다용도실","탈의실","강당","회의실","카페","식당","사무실","전산실","서버실" };
        public int encounter = 0;
        int randomSeed = (int)DateTime.Now.Ticks;
        public Stage() {
            Random rand = new Random(randomSeed);
            this.player = Data.player;
            this.name = $"{str_subtitle[rand.Next(0,str_subtitle.Length)]} {str_location[rand.Next(0,str_location.Length)]}";
            this.encounter = rand.Next(0,100);
        }

        public void SearchStage()
        {
            if (!isSearch)
            {
                Random rand = new Random(randomSeed);
                int randNum = rand.Next(0, 100);

                if (randNum >= 0 || randNum <= 60)
                {
                    Data.player.inventory.AddItem(new Leather());
                }
                else if (randNum >= 61 || randNum <= 100)
                {                    
                    EncounterMonster();
                }
                isSearch = true;
            } else
            {
                return;
            }
        }

        public Monster EncounterMonster()
        {
            return new Rat();
        }
    
        public Dictionary<Direction, Position> FindWay()
        {
            Position prevPos = player.pos;

            // 차례대로 위 아래 좌 우
            int[] locations = new int[] { player.pos.y--, player.pos.y++, player.pos.x--, player.pos.x++ };
            Dictionary<Direction,Position> way = new Dictionary<Direction, Position>();
            // 위
            way[Direction.Up] = new Position(player.pos.x, player.pos.y - 1);
            // 아래
            way[Direction.Down] = new Position(player.pos.x, player.pos.y + 1);
            // 좌
            way[Direction.Left] = new Position(player.pos.x - 1, player.pos.y);
            // 우
            way[Direction.Right] = new Position(player.pos.x + 1, player.pos.y);

            foreach(KeyValuePair<Direction,Position> item in way)
            {
                if (Data.stages[item.Value.y,item.Value.x] == null)
                {
                    way.Remove(item.Key);
                }
            }

            return way;
        }
    }
}
