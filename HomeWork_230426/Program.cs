namespace HomeWork_230426
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DataStructure.Dictionary<string, string> myDictionary = new DataStructure.Dictionary<string, string>();

            myDictionary.Add("시작무기", "단도");
            myDictionary.Add("시작방어구", "천옷");
            myDictionary.Add("시작보조무기", "나무방패");

            Console.WriteLine(myDictionary["시작무기"]);


            if (myDictionary.Remove("시작무기"))
            {
                Console.WriteLine("삭제성공");
            } else
            {
                Console.WriteLine("삭제실패");
            }
        }
    }
}