namespace HomeWork_230425
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataStructure.BinarySearchTree<int> myBST = new DataStructure.BinarySearchTree<int>();

            // Add 테스트
            myBST.Add(11);
            myBST.Add(9);
            myBST.Add(16);
            myBST.Add(18);
            myBST.Add(8);
            myBST.Add(5);
            myBST.Add(13);
            myBST.Add(15);
            myBST.Add(7);
            myBST.Add(6);
            myBST.Add(3);
            myBST.Add(2);

            // Add -> 출력 테스트
            myBST.Print();
            Console.WriteLine();

            // TryGetValue 테스트
            int num;
            myBST.TryGetValue(5, out num);

            // TryGetValue -> 출력 테스트
            Console.WriteLine(num);
            Console.WriteLine();

            // Remove 테스트
            myBST.Remove(2);

            // Remove -> 출력 테스트
            myBST.Print();


        }
    }
}