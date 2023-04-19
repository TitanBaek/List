namespace HomeWork_230419
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> myLinked = new LinkedList<string>();
            myLinked.AddFirst("a");

            LinkedListNode<string> myNode = myLinked.Find("a");

            Console.WriteLine(myNode.Value);

            myLinked.AddAfter(myNode, "어흑마이깟!!!");

            Console.WriteLine(myNode.next.Value);

        }
    }
}