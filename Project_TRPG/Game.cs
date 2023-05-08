using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_TRPG
{
    public class Game
    {
        private bool running = true;

        private Scene scene;
        private MainMenuScene mainMenu;
        private StageScene stageScene;
        private InventoryScene inventoryScene;
        private BattleScene battleScene;

        public void Run()
        {
            Init();

            while (running)
            {
                Render();
                Update();
            }

            Release();
        }

        private void Init()
        {
            Console.CursorVisible = false;

            mainMenu = new MainMenuScene(this);
            stageScene = new StageScene(this);
            inventoryScene = new InventoryScene(this);
            battleScene = new BattleScene(this);

            scene = mainMenu;
        }

        private void Render()
        {
            Console.Clear();
            scene.Render();
        }

        private void Update()
        {
            scene.Update();
        }

        private void Release()
        {

        }

        public void MainMenu()
        {
            scene = mainMenu;
        }

        public void Stage()
        {
            scene = stageScene;
        }

        public void Battle(Monster monster)
        {
            scene = battleScene;
            battleScene.StartBattle(monster);
        }

        public void Inventory()
        {
            scene = inventoryScene;

        }

        public void GameStart()
        {
            Console.Clear();
            string name = "";
            Job job = new Job();
            int i = 1;
            StringBuilder sb = new StringBuilder();

            Console.Write("당신의 이름은 무엇입니까 : ");
            name = Console.ReadLine();
            Console.Clear();
            foreach (Job j in Enum.GetValues(typeof(Job)))
            {
                sb.Append($"{i}. {j.ToString()}    ");
                i++;
            }
            Console.WriteLine(sb.ToString());
            Console.WriteLine("------------------------------------");
            Console.Write("직업을 선택해주세요 : ");
            job = (Job)int.Parse(Console.ReadLine()) - 1;
            Console.WriteLine("------------------------------------");

            Data.Init(name, job);
            Data.LoadStages();
            scene = stageScene;
        }

        public void GameOver()
        {
            Console.Clear();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine();
            sb.AppendLine("┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼");
            sb.AppendLine("███▀▀▀██┼███▀▀▀███┼███▀█▄█▀███┼██▀▀▀");
            sb.AppendLine("██┼┼┼┼██┼██┼┼┼┼┼██┼██┼┼┼█┼┼┼██┼██┼┼┼");
            sb.AppendLine("██┼┼┼▄▄▄┼██▄▄▄▄▄██┼██┼┼┼▀┼┼┼██┼██▀▀▀");
            sb.AppendLine("██┼┼┼┼██┼██┼┼┼┼┼██┼██┼┼┼┼┼┼┼██┼██┼┼┼");
            sb.AppendLine("███▄▄▄██┼██┼┼┼┼┼██┼██┼┼┼┼┼┼┼██┼██▄▄▄");
            sb.AppendLine("┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼");
            sb.AppendLine("███▀▀▀███┼▀███┼┼██▀┼██▀▀▀┼██▀▀▀▀██▄┼");
            sb.AppendLine("██┼┼┼┼┼██┼┼┼██┼┼██┼┼██┼┼┼┼██┼┼┼┼┼██┼");
            sb.AppendLine("██┼┼┼┼┼██┼┼┼██┼┼██┼┼██▀▀▀┼██▄▄▄▄▄▀▀┼");
            sb.AppendLine("██┼┼┼┼┼██┼┼┼██┼┼█▀┼┼██┼┼┼┼██┼┼┼┼┼██┼");
            sb.AppendLine("███▄▄▄███┼┼┼─▀█▀┼┼─┼██▄▄▄┼██┼┼┼┼┼██▄");
            sb.AppendLine("┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼");
            sb.AppendLine("┼┼┼┼┼┼┼┼██┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼██┼┼┼┼┼┼┼┼┼");
            sb.AppendLine("┼┼┼┼┼┼████▄┼┼┼▄▄▄▄▄▄▄┼┼┼▄████┼┼┼┼┼┼┼");
            sb.AppendLine("┼┼┼┼┼┼┼┼┼▀▀█▄█████████▄█▀▀┼┼┼┼┼┼┼┼┼┼");
            sb.AppendLine("┼┼┼┼┼┼┼┼┼┼┼█████████████┼┼┼┼┼┼┼┼┼┼┼┼");
            sb.AppendLine("┼┼┼┼┼┼┼┼┼┼┼██▀▀▀███▀▀▀██┼┼┼┼┼┼┼┼┼┼┼┼");
            sb.AppendLine("┼┼┼┼┼┼┼┼┼┼┼██┼┼┼███┼┼┼██┼┼┼┼┼┼┼┼┼┼┼┼");
            sb.AppendLine("┼┼┼┼┼┼┼┼┼┼┼█████▀▄▀█████┼┼┼┼┼┼┼┼┼┼┼┼");
            sb.AppendLine("┼┼┼┼┼┼┼┼┼┼┼┼███████████┼┼┼┼┼┼┼┼┼┼┼┼┼");
            sb.AppendLine("┼┼┼┼┼┼┼┼▄▄▄██┼┼█▀█▀█┼┼██▄▄▄┼┼┼┼┼┼┼┼┼");
            sb.AppendLine("┼┼┼┼┼┼┼┼▀▀██┼┼┼┼┼┼┼┼┼┼┼██▀▀┼┼┼┼┼┼┼┼┼");
            sb.AppendLine("┼┼┼┼┼┼┼┼┼┼▀▀┼┼┼┼┼┼┼┼┼┼┼▀▀┼┼┼┼┼┼┼┼┼┼┼");
            sb.AppendLine("┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼┼");
            sb.AppendLine();

            Console.WriteLine(sb.ToString());

            running = false;
        }
    }
}
