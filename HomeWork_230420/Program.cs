using HomeWork_230420;

namespace HomeWork_230420
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LinkedList :");
            LinkedList<string> myLinked = new LinkedList<string>();

            myLinked.AddLast("Hello");
            myLinked.AddLast("How");
            myLinked.AddLast("Are");
            myLinked.AddLast("You?");

            foreach(string str in myLinked)
            {
                Console.WriteLine(str);
            }

            Console.WriteLine();
            Console.WriteLine("List :");

            List<string> list = new List<string>();
            list.Add("안녕하세요.");
            list.Add("뭘봐요.");
            list.Add("내 맘이야");

            foreach(string str in list)
            {
                Console.WriteLine(str);
            }

            Console.WriteLine();
            Console.WriteLine("Sort:");

            LinkedList<int> myLinked2 = new LinkedList<int>();
            myLinked2.AddLast(1);
            myLinked2.AddLast(8);
            myLinked2.AddLast(97);
            myLinked2.AddLast(15);
            myLinked2.AddLast(6);
            myLinked2.AddLast(24);

            List<int> myList2 = new List<int>();
            myList2.Add(1);
            myList2.Add(15);
            myList2.Add(17);
            myList2.Add(18);
            myList2.Add(91);
            myList2.Add(441);
            myList2.Add(51);

            Sort.Generic_Sort<int>(myList2, Sort.G_AsendCompare);
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}