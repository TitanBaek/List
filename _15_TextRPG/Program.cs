namespace _15_TextRPG
{
    internal class Program
    {
        /// <summary>
        /// Main은 수정 X
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Game game = new Game();         // 시작은 이렇게..
            game.Run();                     // Run() 호출
        }
    }
}