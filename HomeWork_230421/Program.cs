using System.Reflection.Metadata.Ecma335;

namespace HomeWork_230421
{
    internal class Program
    {
        static void TestingStack()
        {
            // Adapter Stack 
            HomeWork_230421.AdapterStack<int> myStack = new HomeWork_230421.AdapterStack<int>();

            for (int i = 1; i <= 10; i++)
            {
                myStack.Push(i);
            }

            while (myStack.Count > 0)
            {
                Console.WriteLine(myStack.Pop());
            }
        }

        static void TestingQueue()
        {
            // Queue
            HomeWork_230421.Queue<int> myQueue = new Queue<int>();
            for (int i = 1; i <= 10; i++)
            {
                myQueue.Enqueue(i);
            }

            while (myQueue.Count > 0)
            {
                Console.WriteLine(myQueue.Dequeue());
            }
        }

        static void Main(string[] args)
        {
            string str;
            string temp = "";
            int leftCount = 0;
            int rightCount = 0;

            Console.Write("괄호를 입력하세요 : ");
            str = Console.ReadLine();

            char[] cArray = str.ToCharArray(0, str.Length);

            HomeWork_230421.AdapterStack<char> bracketStack = new AdapterStack<char>();

            for (int i = 0; i < cArray.Length; i++)
            {
                bracketStack.Push(cArray[i]);
            }

            // Pop해서 값 하나를 꺼내서 temp 변수에 넣어주고
            // 반복문 한 번돌고 다음 Pop에서 temp와 Pop한 데이터를 비교해줘서 
            // 정답인지 아닌지 판단하는 로직을 우선 구현해보자.

            while(bracketStack.Count > 0)
            {
                if (temp == "")                                 // temp에 값이 없으면 Pop을 넣음
                {
                    temp = bracketStack.Pop().ToString();
                } else if (temp == bracketStack.Peek().ToString()) {    // temp의 값과 Peek의 값이 같다? 다중괄호란뜻..;
                    rightCount++;
                } else
                {
                    Console.WriteLine($"Temp : {temp}  NowPop : {bracketStack.Peek()} ");

                    if (IsOkay(temp, bracketStack.Pop().ToString()))
                    {
                        temp = "";
                        Console.WriteLine("일치하는 괄호");
                    }
                    else
                    {
                        Console.WriteLine("일치하지 않는 괄호");
                        break;
                    }
                }           

            }

            Console.WriteLine("끝");
            Console.WriteLine();
        }

        public static bool IsOkay(string left,string right)
        {
            Console.WriteLine($"Left : { left } Right : {right} ");
            bool isOkay = false;
            switch (left)
            {
                case "]": { isOkay = right == "[" ? true : false; break; }
                case ")": { isOkay = right == "(" ? true : false; break; }
                case "}": { isOkay = right == "{" ? true : false; break; }
                case ">": { isOkay = right == "<" ? true : false; break; }

                default: isOkay = false; break;

            }

            return isOkay;
        }
    }
}