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
        public bool Main()
        {
            string str;
            Console.Write("괄호를 입력하세요 : ");
            str = Console.ReadLine();

            if (IsRightRracket(str))
                return true;
            else
                return false;
        }

        public bool IsRightRracket(string str)
        {
            return false;
        }
    }
}
