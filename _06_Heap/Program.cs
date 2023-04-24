namespace _06_Heap
{
    internal class Program
    {
        /******************************************************
		 * 힙 (Heap)
		 * 
		 * 부모 노드가 항상 자식노드보다 우선순위가 높은 속성을 만족하는 트리기반의 자료구조
		 * 많은 자료 중 우선순위가 가장 높은 요소를 빠르게 가져오기 위해 사용
		 ******************************************************/

       static void PriorityQueue()
        {
            //<T,우선순위(비교가능한 자료형이면 OK)>
            //큐는 선입선출이지만 우선순위큐는 큐처럼 담아두긴 담아두는데 가장 먼저 나오는 값은 우선순위가 가장 높은 자료형이 나온다.
            PriorityQueue<string,int> pq = new PriorityQueue<string, int> ();

            pq.Enqueue("감자", 5);
            pq.Enqueue("마늘", 1);
            pq.Enqueue("대파", 2);
            pq.Enqueue("당근", 4);
            pq.Enqueue("고구마", 3);

            while(pq.Count > 0) {
                Console.WriteLine(pq.Dequeue());            // 우선 순위가 높은 순서대로 데이터가 출력됨.
            }

        }
        static void Main(string[] args)
        {
            PriorityQueue();
        }
    }
}