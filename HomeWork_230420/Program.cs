namespace HomeWork_230420
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("LinkedList :");
            HomeWork_230420.LinkedList<string> myLinked = new HomeWork_230420.LinkedList<string>();

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

            HomeWork_230420.List<string> list = new HomeWork_230420.List<string>();
            list.Add("안녕하세요.");
            list.Add("뭘봐요.");
            list.Add("내 맘이야");

            foreach(string str in list)
            {
                Console.WriteLine(str);
            }
        }
    }
}