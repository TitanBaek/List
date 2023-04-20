namespace _02_LinkedList
{
    internal class Program
    {
        /******************************************************
		 * 연결리스트 (Linked List)
		 * 
		 * 데이터를 포함하는 노드들을 연결식으로 만든 자료구조
		 * 노드는 데이터와 이전/다음 노드 객체를 참조하고 있음
		 * 노드가 메모리에 연속적으로 배치되지 않고 이전/다음노드의 위치를 확인
		 * 인덱스 개념이 없다 !!!!!!!!!!!!!!!!
		 * 인덱스를 통해 바로 값을 찾는게 불가능하다..
		 * 삽입/삭제가 빨라야하는 데이터를 처리할때 유용하다.
		 * C#에선 잘 안써요 ㅎ;;
		 * GC에게 미친듯이 영향을 주는 자료구조이다 .		 *
		 * 
		 * 3가지의 종류가 있음
		 * 
		 * 
		 * 1. 단방향 LinkedList 
		 *    무조건 순차적으로 즉 이전 주소를 가지고 있을 필요가 없을 경우 사용함
		 *    참조형 데이터(이전 주소)가 하나 적어서 메모리 소모가 덜함
		 * 2. 양방향 LinkedList
		 *    양방향으로 이전,다음 데이터의 주소 값을 가지고 있음
		 *    데이터가 많아질수록 메모리 소모가 심함
		 *    
		 * 3. 원형(환형) LinkedList
		 *    기본적으로 양방향과 흡사하지만 맨 마지막 데이터가 맨 처음 데이터의 주소값을 가지고 있다.
		 *    
		 *    C#은 3번의 원형 LinkedList를 사용하고 있음.
		 *    
		 *    
		 *    가장 앞의 노드를 헤드노드라고 칭하고, 가장 마지막의 노드는 테일노드 라고 한다.
		 ******************************************************/

        // <링크드리스트 사용>
        static void LinkedList()
        {
            LinkedList<string> linkedList = new LinkedList<string>();

            // 링크드리스트 요소 삽입
            linkedList.AddFirst("0번 앞데이터");
            linkedList.AddFirst("1번 앞데이터");
            linkedList.AddLast("0번 뒤데이터");
            linkedList.AddLast("1번 뒤데이터");

            // 링크드리스트 요소 삭제
            linkedList.Remove("1번 앞데이터");

            // 링크드리스트 요소 탐색
            LinkedListNode<string> findNode = linkedList.Find("0번 뒤데이터");

            // 링크드리스트 노드를 통한 노드 참조
            LinkedListNode<string> prevNode = findNode.Previous;
            LinkedListNode<string> nextNode = findNode.Next;

            // 링크드리스트 노드를 통한 노드 삽입
            linkedList.AddBefore(findNode, "찾은노드 앞데이터");
            linkedList.AddAfter(findNode, "찾은노드 뒤데이터");

            // 링크드리스트 노드를 통한 삭제
            linkedList.Remove(findNode);
        }

        // <List의 시간복잡도>
        // 접근		탐색		삽입		삭제
        // O(1)		O(n)	O(n)	O(n)

        // <LinkedList의 시간복잡도>
        // 접근		탐색		삽입		삭제
        // O(n)		O(n)	O(1)	O(1)

        static void Main(string[] args)
        {
            DataStructure.LinkedList<int> myLinked = new DataStructure.LinkedList<int>();

            myLinked.AddFirst(0);
            myLinked.AddFirst(1);
            myLinked.AddFirst(2);
            myLinked.AddFirst(3);

            myLinked.Remove(2);


        }
    }
}