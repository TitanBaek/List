using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_TextRPG
{
    internal class MainMenuScene : Scene
    {
        public MainMenuScene(Game game) : base(game)
        {
        }

        public override void Render()
        {
            // TODO : 메인메뉴 표현 구현
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("1. 게임시작");
            sb.AppendLine("2. 게임종료");
            sb.Append("메뉴를 선택하세요 : ");

            Console.Write(sb.ToString());
        }

        public override void Update()
        {
            // TODO : 메인메뉴 갱신 구현
            string input = Console.ReadLine();

            int command;
            if(!int.TryParse(input, out command)) // 예외처리
            {
                Console.WriteLine("잘못 입력 하셨습니다.");
                Thread.Sleep(1000);
                return;
            }

            switch (command)
            {
                case 1: 
                    {
                        game.GameStart(); 
                        Thread.Sleep(1000); 
                        break; 
                    }
                case 2:
                    {
                        game.GameOver();
                        Thread.Sleep(1000);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("잘못 입력 하셨습니다.");
                        Thread.Sleep(1000);
                        break;
                    }
            }
        }
    }
}
