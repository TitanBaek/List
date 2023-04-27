using System.Text;

namespace HomeWork_230427
{
    internal class Program
    {
        /*
            재귀 : 하노이탑 문제 - https://www.acmicpc.net/problem/11729
            백트래킹 : N과 M(3) - https://www.acmicpc.net/problem/15651
            탐욕 : 잃어버린 괄호 - https://www.acmicpc.net/problem/1541
            분할정복 : 색종이 만들기 - https://www.acmicpc.net/problem/2630
            동적계획법 : 정수삼각형 - https://www.acmicpc.net/problem/1932
         */


        /// <summary>
        /// [재귀] 하노이 탑 쌓기 과제... 
        /// </summary>
        static StringBuilder sb = new StringBuilder();
        static void Move(int count,int start,int end)
        {
            if(count == 1)
            {
                // 그냥이동
                //Console.WriteLine($"{start+1} {end+1}");
                sb.Append($"{start+1} {end+1}\n");
                return;
            }

            int other = (3 - start - end);

            Move(count - 1, start, other);
            Move(1, start, end);
            Move(count - 1, other, end);             
        }

        static void Hanoi()
        {
            int num = Int32.Parse(Console.ReadLine());
            Console.WriteLine((int)Math.Pow(2, num) - 1);
            Move(num, 0, 2);
            Console.WriteLine(sb.ToString());
        }
        //

        static void NandM()
        {
            StringBuilder mySb = new StringBuilder();
            int n = 4;
            int m = (int)Math.Pow(2,2);

            for (int j = 1; j <= n; j++)
            {
                for (int i = 1; i <= m; i++)
                {
                    mySb.Append($"{j} {i} \n");
                }

            }

            Console.WriteLine(mySb.ToString());
        }


        static void Main(string[] args)
        {
            NandM();
        }
    }
}