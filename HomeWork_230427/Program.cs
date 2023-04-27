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

        /// <summary>
        /// N&M3 과제..
        /// </summary>
        static int n, m;
        static StringBuilder sb2 = new StringBuilder();
        static int[] numArray;
        static void NandM()
        {
            string inputNM = Console.ReadLine();

            string[] nm = inputNM.Split(" ");

            n = Int32.Parse(nm[0]);
            m = Int32.Parse(nm[1]);
            numArray = new int[m];

            DoNandM(0);
            
;
        }

        static void DoNandM(int depth)
        {
            if(depth == m) // depth가 입력된 M과 같다면
            {
                for(int i = 0; i < numArray.Length; i++)
                {
                    sb2.Append($"{numArray[i]} ");
                }
                sb2.Append('\n');
                return;
            }

            for(int i = 0; i < n; i++)
            {
                numArray[depth] = i + 1;
                DoNandM(depth+1);
            }
        }


        /// <summary>
        /// 잃어버린 괄호..과제..
        /// 백준에서만 컴파일(Format Exception) 에러 도대체 왜 나는건지 모르겠습니다...
        /// </summary>
        static void Bracket()
        {
            // 55-50+40
            string inputMath = Console.ReadLine();

            string[] plusArray;
            string[] minusArray;
            int result = 0;
            int result2 = 0;

            if (inputMath.Contains("-"))
            {
                minusArray = inputMath.Split("-");         // - 를 기준으로 Split
                for (int i = 0; i < minusArray.Length; i++)
                {
                    if (i == 0)
                    {
                        result = int.Parse(minusArray[i]);
                        continue;
                    }

                    if (minusArray[i].Contains("+"))
                    {
                        plusArray = minusArray[i].Split("+");
                        for(int j = 0; j < plusArray.Length; j++)
                        {
                            result2 += int.Parse(plusArray[j]);
                        }
                    } else
                    {
                        result -= int.Parse(minusArray[i]);
                    }
                }

                result -= result2;
            } else
            {
                plusArray = inputMath.Split('+');
                for (int i = 0; i < plusArray.Length; i++)
                    result += Convert.ToInt32(plusArray[i]);
            }
            Console.WriteLine(result);

        }


        static void Main(string[] args)
        {
            Bracket();
        }
    }
}