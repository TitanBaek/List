namespace HomeWork_230424
{
    internal class Program
    {
        public static void Test_Priority()
        {
            DataStructure.PriorityQueue<string> myQueue = new DataStructure.PriorityQueue<string>();

            myQueue.Enqueue("Hi", 1);
            myQueue.Enqueue("See", 3);
            myQueue.Enqueue("Ya", 4);
            myQueue.Enqueue("I have to go", 2);

            while (myQueue.Count > 0)
            {
                Console.WriteLine(myQueue.Dequeue());
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("과제 테스트");
            Console.Write("1. 우선순위 큐 정상 작동 확인하기   2. 응급실 만들기 확인하기     :  ");
            string keyInput = Console.ReadLine();
            switch (keyInput)
            {
                case "1": Test_Priority(); break;
                case "2": Er.Input_Patient(); break;
                default: break;
            }
        }
    }
}