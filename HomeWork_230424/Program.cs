namespace HomeWork_230424
{
    internal class Program
    {
        static void Main(string[] args)
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
    }
}