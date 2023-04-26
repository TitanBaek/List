namespace _08_HashTable
{
    internal class Program
    {
        /******************************************************
		 * 해시테이블 (HashTable)
		 * 
		 * [키 값을 해시함수로 해싱하여 해시테이블의 특정 위치(인덱스)로 직접 엑세스하도록 만든 방식]
		 * 
		 * 해시 : 임의의 길이를 가진 데이터를 고정된 길이를 가진 데이터로 매핑
		 * 
		 * 키 값을 해시함수를 통해 Index화 하여 해당 위치에 데이터를 저장하고
		 * 데이터를 불러올때도 키 값을 해시함수를 통해 Index화 하여 해당 위치의 데이터를 꺼낸다.
		 * 주의 사항으로는 입력된 키 값이 해시함수를 돌렸을때 동일한 값이 나와야함
         ******************************************************/

        // <해시함수의 조건>
        // 1. 입력에 대한 해시함수의 결과가 항상 동일한 값이어야 한다.
        // 2.
        //
        //
        // <해시함수의 효율>
        // 1. 해시함수 자체가 느린경우 해시테이블을 사용하는 의미가 없다.
        // 2. 
        //
        //

        static void Dictionary()
        {
            Dictionary<string,Item> dictionary = new Dictionary<string,Item>();

            dictionary.Add("초기무기", new Item("초보자용 방어구", 20));
            dictionary.Add("초기방어구", new Item("초보자용 무기", 15));
            dictionary.Add("초기아이템", new Item("체력포션", 5));

            Console.WriteLine(dictionary["초기아이템"].name);

            dictionary.Remove("초기방어구");

            if (dictionary.ContainsKey("초기방어구"))                                        // 키 값의 여부를 bool로 반환해주는 메소드
            {
                Console.WriteLine("있습니다. 초기방어구");
            }
            else
            {
                Console.WriteLine("없습니다. 초기방어구");
            }


        }

        static void Main(string[] args)
        {
            Dictionary();
        }

        public class Item
        {
            public string name;
            public int weight;

            public Item(string name,int weight) { 
                this.name = name;
                this.weight = weight;
            }
        }
    }
}