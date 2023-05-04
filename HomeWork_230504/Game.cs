using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_230504
{
    public class Game
    {
        private bool running = true;

        private Scene scene;
        private MainMenuScene mainMenu;
        private MapScene mapScene;
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

            Data.Init();
            mainMenu = new MainMenuScene(this);
            mapScene = new MapScene(this);
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

        public void Map()
        {
            scene = mapScene;
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
            scene = mapScene;
            mapScene.GenerateMap();
        }

        public void GameOver(string text = "")
        {
            Console.Clear();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine();
            sb.AppendLine("  ***    *   *   * *****       ***  *   * ***** ****  ");
            sb.AppendLine(" *      * *  ** ** *          *   * *   * *     *   * ");
            sb.AppendLine(" * *** ***** * * * *****      *   * *   * ***** ****  ");
            sb.AppendLine(" *   * *   * *   * *          *   *  * *  *     *  *  ");
            sb.AppendLine("  ***  *   * *   * *****       ***    *   ***** *   * ");
            sb.AppendLine();

            sb.AppendLine();
            sb.Append(text);

            Console.WriteLine(sb.ToString());

            running = false;
        }
    }
}
