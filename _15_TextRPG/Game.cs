using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_TextRPG
{
    public class Game
    {
        private bool running = true;

        private Scene               curScene;      
        private MainMenuScene       mainMenuScene;
        private MapScene            mapScene;
        private InventoryScene      inventoryScene;
        private BattleScene         battleScene;

        public void Run()
        {
            // 초기화
            Init();
            // 게임루프

            while (running)
            {
                // 표현
                Render();

                // 입력
                Input();

                // 갱신(Update)
                Update();
            }

            // 마무리
            Release();
        }
        /// <summary>
        /// 초기화 함수
        /// </summary>
        private void Init()
        {
            Data.Init(); // 데이터 초기화

            // 각 Scene 들 초기화
            mainMenuScene = new MainMenuScene(this);
            mapScene = new MapScene(this);
            inventoryScene = new InventoryScene(this);
            battleScene = new BattleScene(this);

            // 최초실행(초기화) 시 현재 Scene은 메인메뉴로
            curScene = mainMenuScene;
        }

        public void BattleStart(Monster monster)
        {
            curScene = battleScene;
        }

        /// <summary>
        /// 랜더링 함수
        /// </summary>
        private void Render()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            curScene.Render();          // 현재 Scene을 랜더한다.
        }

        /// <summary>
        /// 입력 함수
        /// </summary>
        private void Input()
        {

        }

        public void GameStart()
        {
            Data.LoadLevel();
            curScene = mapScene;
        }

        public void GameOver()
        {
            running = false;
        }

        /// <summary>
        /// 업데이트 함수
        /// </summary>
        private void Update()
        {
            curScene.Update();          // 현재 Scene을 갱신한다.
        }

        /// <summary>
        /// 마무리 해주는 릴리즈 함수
        /// </summary>
        private void Release()
        {

        }
    }
}
