namespace HomeWork_230418
{
    /*
     *  1. 선형리스트 구현 - msdn C#의 List 참고
     *     인덱서[], Add, Remove, Find, FindIndex, Count 등등
     * 
     *  2. 배열, 선형리스트 기술면접 정리
     */

    internal class Program
    {
        static void Main(string[] args)
        {
            HomeWork_230418.List<string> myList = new HomeWork_230418.List<string>();

            myList.Add("1번 데이터");
            myList.Add("2번 데이터");
            myList.Add("3번 데이터");
            myList.Add("4번 데이터");
            myList.Add("5번 데이터");

            myList.Insert(3, "New 4번 데이터");
                
            for(int i = 0; i < myList.Count ; i++) {
                Console.WriteLine(myList[i]);
            }
            Console.WriteLine();
            myList.Remove("3번 데이터");

            for (int i = 0; i < myList.Count; i++)
            {
                Console.WriteLine(myList[i]);
            }

        }
    }
}