namespace _04_Queue
{
    internal class Program
    {
        /******************************************************
		 * 큐 (Queue)
		 * 
		 * 선입선출(FIFO), 후입후출(LILO) 방식의 자료구조
		 * 입력된 순서대로 처리해야 하는 상황에 이용
		 ******************************************************/

        static void Test()
        {
            Queue<int> queue = new Queue<int>();

            for (int i = 1; i <= 10; i++) { queue.Enqueue(i); }                     // .Enqueue 로 값 넣기

            Console.WriteLine("Pick:");
            Console.WriteLine(queue.Peek());                                        // 최전방의 데이터 Peek으로 확인하기

            Console.WriteLine();

            Console.WriteLine("While_Dequeue:");
            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());                                 // .Dequeue 로 값을 확인
            }
        }
        static void Main(string[] args)
        {
                Test();
        }
    }
}