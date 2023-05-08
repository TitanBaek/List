using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TRPG
{
    public class Stage
    {
        string name = "";
        string[] str_subtitle = new string[] {"불 꺼진","어두운","피비린내 나는","좋은 향기가 나는","무서운 소리가 들리는","평범한","음침한","소름끼치는","뭔가 느낌이 좋은","그냥","으르렁거리는 소리가 들리는","뭐가 나올지 모를","전자음이 들리는","바람소리가 들리는" };
        string[] str_location = new string[] {"방","복도","사무실","창고","화장실","다용도실","탈의실","강당","회의실","카페","식당","사무실","전산실","서버실" };
    
        public Stage() {
            int randomSeed = (int)DateTime.Now.Ticks;
            Random rand = new Random(randomSeed);
            this.name = $"{str_subtitle[rand.Next(0,str_subtitle.Length)]} {str_location[rand.Next(0,str_location.Length)]}";
        }
    
    }
}
