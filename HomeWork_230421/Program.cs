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

            while(myStack.Count > 0)
            {
                Console.WriteLine(myStack.Pop()) ;
            }

            // Queue


        }
    }
}