using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    internal class PriorityQueue<TElement>
    {
        private struct Node
        {
            public TElement element;            // 노드에 담길 데이터
            public int priority;                // 우선순위
        }

        private List<Node> nodes;               // 노드가 담길 List
        private IComparer<int> comparer;        // 우선순위 선발 규칙
        public int Count { get { return nodes.Count; } }        // 총 node 수

        public PriorityQueue() {                // 생성자                   
            this.nodes = new List<Node>();      // Node 담을 List 생성
        }

        public void Enqueue(TElement element,int priority)
        {
            Node newNode = new Node() { element = element, priority = priority};            // 새로운 노드 정의
            nodes.Add(newNode);                                                             // 노드 삽입
            int newNodeIndex = nodes.Count - 1;                                             // 새로 삽입될 노드의 인덱스 값 = 맨 마지막 인덱스
            
            while (newNodeIndex > 0)                                                        // 새로운 노드를 힙상태가 유지되도록 아래 세대부터 윗 세대로 승격 작업 반복
            {
                // 현 newNodeIndex의 부모 노드를 확인한다.
                int parentIndex = GetParentIndex(newNodeIndex);                             // ParentIndex를 찾는 함수를 호출하여
                Node parentNode = nodes[parentIndex];                                       // parantNode를 찾아낸다.

                // newNode와 parentNode 우선순위 확인 후 교체 작업
                if (newNode.priority < parentNode.priority)                                 // newNode의 우선순위가 parentNode보다 높다( 적은 수인 경우 )
                {
                    nodes[newNodeIndex] = parentNode;                                       // nodes(노드들이 담긴 리스트)의 newNodeIndex 자리에 parentNode 를 넣고 
                    nodes[parentIndex] = newNode;                                           // parentIndex 자리에 newNode를 넣는다
                    newNodeIndex = parentIndex;                                             // 반복문의 조건이 되는 newNodeIndex를 parentIndex 로 교체
                }
                else
                {
                    break;                                                                  // 자식 값이 없다.. Break
                }
            }
        }

        public TElement Dequeue()
        {
            TElement result = nodes[0].element;                                             // 반환할 최상위 노드의 Element
            Node lastNode = nodes[nodes.Count - 1];                                         // 가장 마지막 노드 구하기
            nodes[0] = lastNode;
            nodes.RemoveAt(nodes.Count - 1);                                                // 가장 마지막 노드 삭제
            int index = 0;                                                                  // while 문에서 반복 조건으로 사용될 index 선언

            while (index < nodes.Count)                                                     // index 가 nodes 리스트의 크기보다 적을 동안 반본
            {
                int leftChildIndex = GetLeftIndex(index);                                   // 비교에 쓰일 좌측 자식의 Index
                int rightChildIndex = GetRightIndex(index);                                 // 비교에 쓰일 우측 자식의 Index
                int lessChildIndex = 0;
                if(rightChildIndex < nodes.Count)                                           // 우측 자식이 존재하는 경우, 그렇다는건 이진트리를 형성하고 있다는 뜻( 좌,우측 모두 자식값이 있다)
                {
                    // 좌측,우측 중 우선순위가 높은것을 추려주세요.
                    lessChildIndex = nodes[leftChildIndex].priority < nodes[rightChildIndex].priority ? leftChildIndex : rightChildIndex;

                } else if(leftChildIndex < nodes.Count)                                     // 좌측 자식만 있는 경우, Heap Tree에서는 '우측 트리만 존재'하는 경우는 없음
                {
                    lessChildIndex = leftChildIndex;
                }
                else                                                                        // 자녀가 없습니다..
                {
                    break;
                }

                if (nodes[lessChildIndex].priority < nodes[index].priority )                // 비교할 자식 인덱스의 우선순위가 현 index의 우선순위 보다 높다면
                {
                    nodes[index] = nodes[lessChildIndex];                                   // Nodes 리스트의 현 인덱스 자리에 자식인덱스의 Node를 넣고
                    nodes[lessChildIndex] = lastNode;                                       // 자식인덱스 자리의 노드에 LastNode(
                    index = lessChildIndex;                                                 // index 를 현 자식 인덱스로 교체
                } else
                {
                    break;
                }
            }
            return result;
        }


        public TElement Peek()                                      
        {
            return nodes[0].element;                                                        // 최상위 값 반환
        }

        public int GetParentIndex(int childIndex)
        {
            return (childIndex - 1 ) / 2;                                                   // 매개변수로 전달 받은 인덱스의 부모 값을 구하여 반환
        }

        public int GetLeftIndex(int index)
        {
            return index * 2 + 1;                                                           // 매개변수로 전달 받은 인덱스의 '좌측'자식 인덱스를 구하여 반환
        }

        public int GetRightIndex(int index)
        {
            return index * 2 + 2;                                                           // 매개변수로 전달 받은 인덱스의 '우측'자식 인덱스를 구하여 반환
        }


    }
}
