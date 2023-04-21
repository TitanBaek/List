namespace HomeWork_230421
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Adapter Stack 
            HomeWork_230421.AdapterStack<int> myStack = new HomeWork_230421.AdapterStack<int>();

            for(int i = 1 ; i <= 10; i++)
            {
                myStack.Push(i);
            }

            while (myStack.Count > 0)
            {
                Console.WriteLine(myStack.Pop()) ;
            }
            Console.WriteLine();
            Console.WriteLine();
            // Queue
            HomeWork_230421.Queue<int> myQueue = new Queue<int> ();
            for(int i = 1; i <= 10; i++)
            {
                myQueue.Enqueue(i);
            }

            while (myQueue.Count > 0)
            {
                Console.WriteLine(myQueue.Dequeue());
            }

        }
    }
}