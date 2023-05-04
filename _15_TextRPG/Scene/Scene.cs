using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_TextRPG
{
    public abstract class Scene // 추상 클래스로 씬
    {
        protected Game game;

        public Scene(Game game)
        {
            this.game = game;
        }

        public abstract void Render(); // 씬은 표현될 수 있어야하고
        public abstract void Update(); // 갱신될 수 있어야한다.

    }
}
