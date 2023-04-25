namespace _07_BinarySearchTree
{
    internal class Program
    {
        /******************************************************
		 * 트리 (Tree)
		 * 
		 * 계층적인 자료를 나타내는데 자주 사용되는 자료구조
		 * 부모노드가 0개 이상의 자식노드들을 가질 수 있음
		 * 한 노드에서 출발하여 다시 자기 자신의 노드로 돌아오는 순환구조를 가질 수 없음
		 ******************************************************/

        /******************************************************
		 * 이진탐색트리 (BinarySearchTree)
		 * 
		 * 이진속성과 탐색속성을 적용한 트리
		 * 이진탐색을 통한 탐색영역을 절반으로 줄여가며 탐색 가능
		 * 이진 : 부모노드는 최대 2개의 자식노드들을 가질 수 있음
		 * 탐색 : 자신의 노드보다 작은 값들은 왼쪽, 큰 값들은 오른쪽에 위치
		 * 
		 *            부모(5)
		 *  자식1(2)           자식2(9)
		 *  
		 *  정렬이 보장되는 자료형중 하나
		 ******************************************************/

        // <이진탐색트리의 시간복잡도>
        // 접근			탐색			삽입			삭제
        // O(log n)		O(log n)	O(log n)	O(log n)

        // <이진탐색트리의 주의점>
        // 이진탐색트리의 노드들이 한쪽 자식으로만 추가되는 불균형 발생 가능
        // 이 경우 탐색영역이 절반으로 줄여지지 않기 때문에 시간복잡도 증가
        // 이러한 현상을 막기 위해 자가균형기능을 추가한 트리의 사용이 일반적
        // 대표적인 방식으로 Red-Black Tree, AVL Tree 등이 있음

        /***********************************************************
         * 
         * 트리기반 자료구조의 순회순서
         * 
         * 1. 전위순회
         *    현재노드, 좌측노드, 우측노드
         *    
         * 2. 중위순회 (이진탐색 트리의 순회)  / 오름차 순으로 정렬이됨
         *    좌측노드, 현재노드, 우측노드.
         *    
         * 3. 후위순회
         *    좌측노드, 우측노드, 현재노드
         * 
         * **********************************************************/
        static void BinarySearchTree()
        {
            //생성
            SortedSet<int> sortedSet = new SortedSet<int>();

            //추가
            for (int i = 1; i <= 5; i++)
            {
                sortedSet.Add(i);
            }

            //탐색
            int serchValue;
            bool find = sortedSet.TryGetValue(7, out serchValue); // 탐색시도

            Console.WriteLine(serchValue);

            // 솔티드딕셔너리는 탐색용 키값과 데이터로 이뤄져있음
            //             탐색용키,데이터
            SortedDictionary<string, Monster> mySortedDic = new SortedDictionary<string, Monster>();

            mySortedDic.Add("피카츄", new Monster() { name = "피카츄", hp = 100 });
            mySortedDic.Add("파이리", new Monster() { name = "파이리", hp = 120 });
            mySortedDic.Add("꼬부기", new Monster() { name = "꼬부기", hp = 150 });
            mySortedDic.Add("리아코", new Monster() { name = "리아코", hp = 90 });
            mySortedDic.Add("이상해씨", new Monster() { name = "이상해씨", hp = 130 });

            Monster monster;
            mySortedDic.TryGetValue("파이리", out monster);        // 파이리 탐색 시도
            Monster indexerMonster = mySortedDic["파이리"];        // 인덱서를 통한 솔티드딕셔너리 탐색

            mySortedDic.Remove("리아코");

        }

        class Monster
        {
            public string name;
            public int hp;
            public int mp;
            public int ap;
            public int exp;
        }

        static void Main(string[] args)
        {
            //BinarySearchTree();

            _07_BinarySearchTree.BinarySearchTree<int> myBST = new _07_BinarySearchTree.BinarySearchTree<int>();
            


            myBST.Add(3);
            myBST.Add(5);
            myBST.Add(4);
            myBST.Add(9);
            myBST.Add(7);
            myBST.Add(6);
            myBST.Add(2);
            myBST.Add(1);

            myBST.Print();
        }
    }
}