using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_230421
{
    internal class Bracket
    {
        public void Main()
        {

            string str;
            string temp = "";
            int leftCount = 0;
            int rightCount = 1;

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

            while (bracketStack.Count > 0)
            {
                if (temp == "")
                {
                    temp = bracketStack.Pop().ToString();
                    continue;
                }
                if (!IsOkay(temp, bracketStack.Pop().ToString(), ref leftCount, ref rightCount))
                {
                    Console.WriteLine("일치하지 않아요.");
                    break;
                }

                temp = "";
            }

            if (leftCount == rightCount)
            {
                Console.WriteLine("일치합니다.");
            }
            Console.WriteLine("끝");
            Console.WriteLine();

        }
        public static bool IsOkay(string left, string right, ref int leftCount, ref int rightCount)
        {
            Console.WriteLine($"Left : {left} Right : {right} ");
            bool isOkay = false;
            switch (left)
            {
                case "]":
                    {
                        if (right == "[")
                        {
                            leftCount++;
                        }
                        else if (right == "]")
                        {
                        }
                        else
                        {
                            isOkay = false;
                        }
                        break;
                    }
                case ")":
                    {
                        if (right == "(")
                        {
                            leftCount++;
                        }
                        else if (right == ")")
                        {
                            rightCount++;
                        }
                        else
                        {
                            isOkay = false;
                        }
                        break;
                    }
                case "}":
                    {
                        if (right == "{")
                        {
                            leftCount++;
                        }
                        else if (right == "}")
                        {
                            rightCount++;
                        }
                        else
                        {
                            isOkay = false;
                        }
                        break;
                    }
                case ">":
                    {
                        if (right == "<")
                        {
                            leftCount++;
                        }
                        else if (right == ">")
                        {
                            rightCount++;
                        }
                        else
                        {
                            isOkay = false;
                        }
                        break;
                    }
                case "[":
                    {
                        if (right == "]")
                        {
                            rightCount++;
                        }
                        else if (right == "[")
                        {
                            leftCount++;
                        }
                        else
                        {
                            isOkay = false;
                        }
                        break;
                    }
                case "(":
                    {
                        if (right == ")")
                        {
                            rightCount++;
                        }
                        else if (right == "(")
                        {
                            leftCount++;
                        }
                        else
                        {
                            isOkay = false;
                        }
                        break;
                    }
                case "{":
                    {
                        if (right == "}")
                        {
                            rightCount++;
                        }
                        else if (right == "{")
                        {
                            leftCount++;
                        }
                        else
                        {
                            isOkay = false;
                        }
                        break;
                    }
                case "<":
                    {
                        if (right == ">")
                        {
                            rightCount++;
                        }
                        else if (right == "<")
                        {
                            leftCount++;
                        }
                        else
                        {
                            isOkay = false;
                        }
                        break;
                    }
                default: isOkay = false; break;

            }

            Console.WriteLine($"{leftCount} & {rightCount}");
            if (leftCount == rightCount && isOkay)
            {
                isOkay = leftCount == rightCount ? true : false;
            }
            return isOkay;
        }
    }
}
