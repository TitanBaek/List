using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TRPG
{
    public class MainMenuScene : Scene
    {
        int chooseInt = 1;
        StringBuilder sb = new StringBuilder();
        public MainMenuScene(Game game) : base(game) { }

        public override void Render()
        {
            Console.Clear();
            if (chooseInt == 1)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                sb.AppendLine("게 임 시 작");
                Console.WriteLine(sb.ToString());
                sb.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                sb.AppendLine("게 임 종 료");
                Console.WriteLine(sb.ToString());
                sb.Clear();
            }
            else if (chooseInt == 2)
            {
                sb.AppendLine("게 임 시 작");
                Console.WriteLine(sb.ToString());
                sb.Clear();
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                sb.AppendLine("게 임 종 료");
                Console.WriteLine(sb.ToString());
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                sb.Clear();
            }
        }

        public override void Update()
        {
            ConsoleKeyInfo key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.UpArrow : chooseInt--;Thread.Sleep(300); break;
                case ConsoleKey.DownArrow : chooseInt++; Thread.Sleep(300); break;
                case ConsoleKey.Enter: ChooseDone();  break;
            }

            if(chooseInt > 2)
            {
                chooseInt = 2;
            } else if(chooseInt < 1)
            {
                chooseInt = 1;
            }
        }

        public void ChooseDone()
        {
            switch (chooseInt)
            {
                case 1:game.GameStart(); break;
                case 2:game.GameOver(); break;
            }
        }
    }
}
