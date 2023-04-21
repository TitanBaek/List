namespace _04_Stack
{
    internal class Program
    {
        /******************************************************
        * 스택 (Stack)
        * 
        * 선입후출(FILO), 후입선출(LIFO) 방식의 자료구조
        * 가장 최신 입력된 순서대로 처리해야 하는 상황에 이용
        ******************************************************/

        static void Test()
        {
            Stack<int> stack = new Stack<int>();

            for (int i = 1; i <= 10; i++) { stack.Push(i); }
            Console.WriteLine("Pick:");
            Console.WriteLine(stack.Peek());                        // 가장 위(최상단)에 있는 값을 '확인'만 해주는 것

            Console.WriteLine();

            Console.WriteLine("While_Pop:");
            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());                     // 스택 내의 값을 꺼내주는
            }

        }
        static void Main(string[] args)
        {
                Test();
        }
    }
}