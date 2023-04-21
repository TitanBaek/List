namespace HomeWork_230421
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HomeWork_230421.AdapterStack<int> myStack = new AdapterStack<int>();

            for(int i = 1 ; i <= 10; i++)
            {
                myStack.Push(i);
            }

            while(myStack.Count > 0)
            {
                Console.WriteLine(myStack.Pop()) ;
            }



        }
    }
}