using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_230419
{
    public class LinkedListNode<T>
    {
        internal LinkedListNode<T> next;
        internal LinkedListNode<T> prev;
        internal LinkedList<T> list;
        private T item;

        public T Value { get { return item; } }
        public LinkedListNode<T> Next { get { return next; } }
        public LinkedListNode<T> Prev { get { return prev; } }
        public LinkedList<T> List { get { return list; } }

        public LinkedListNode(T value)
        {
            this.next = null;
            this.prev = null;
            this.list = null;
            this.item = value;
        }

        public LinkedListNode(LinkedList<T> list,T value)
        {
            this.next = null;
            this.prev = null;
            this.list = list;
            this.item = value;
        }

        public LinkedListNode(LinkedList<T> list, LinkedListNode<T> prev, LinkedListNode<T> next, T item)
        {
            this.next = next;
            this.prev = prev;
            this.list = list;
            this.item = item;
        }

    }

    public class LinkedList<T>
    {
        private int count = 0;
        private LinkedListNode<T> head;
        private LinkedListNode<T> tail;

        public int Count { get { return count; } }
        public LinkedListNode<T> First { get { return head; } }
        public LinkedListNode<T> Last { get {  return tail; } }

        public LinkedListNode<T> AddFirst(T item)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T> (this,item);       // 새노드생성
            if (this.head != null)                                               // head가 안 비어있다.
            {
                newNode.next = this.head;                                        // newNode의 next 는 구)head
                this.head.prev = newNode;                                        // 이제 앞으로 밀려나니까 구)head의 prev는 newNode
            
            } else                                                          // head가 비어있다. 즉 최초로 값을 넣는 경우
            {
                this.tail = newNode;                                             // LinkedList는 비어있었으니 head와 tail는 newNode다
            }
            this.head = newNode;                                                 // 위 조건문에 head = newNode는 무조건 들어가기 때문에 조건문 밖으로 빼줬음.

            this.count++;

            return newNode;
                

        }

        public LinkedListNode<T> AddLast(T item)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(this,item);        // 새노드 생성
            if (this.tail != null)                                               // tail이 안 비어있다.
            {
                newNode.prev = this.tail;                                        // newNode의 prev는 구)tail
                this.tail.next = newNode;                                        // 구)tail의 next는 newNode
            }
            else                                                            // tail이 비어있다.
            {
                this.head = newNode;                                             // LinkedList는 비어있었으니 head와 tail은 newNode다.
            }
            this.tail = newNode;                                                 // 위 조건문에 tail = newNode가 무조건 들어가니 조건문 밖으로 빼줬음.

            this.count++;

            return newNode;                                                 // 반환 newNode
        }

        public LinkedListNode<T> AddBefore(LinkedListNode<T> targetNode,T item)
        {
            
            if(targetNode.list != this || targetNode == null)               // 예외처리  - 전달 받은 targetNode가 현재의 LinkedList에 없는 경우 || targetNode가 null 인 경우
            {
                throw new ArgumentNullException(nameof(targetNode));        // 예외상황 발생
            }
            LinkedListNode<T> newNode = new LinkedListNode<T> (this, targetNode.prev, targetNode, item); // newNode 생성

            // 연결구조 변경 시작
            if(targetNode.prev != null)                                     // targetNode의 Prev이 null이 아니면
            {
                targetNode.prev.next = newNode;                             // targetNode의 Prev 노드의 Next를 newMode 로
            
            }
            else                                                            // targetNode의 Prev이 null 이다, 즉 targetNode가 head 다.
            {
                this.head = newNode;                                             // head를 newNode로 바꿔준다.
            }
            targetNode.prev = newNode;                                      // targetNode의 Prev을 newNode로 바꿔준다.
            
            this.count++;

            return newNode;                                                 // newNode 반환
        }

        public LinkedListNode<T> AddAfter(LinkedListNode<T> targetNode,T item)
        {
            if (targetNode.list != this || targetNode == null)               // 예외처리  - 전달 받은 targetNode가 현재의 LinkedList에 없는 경우 || targetNode가 null 인 경우
            {
                throw new ArgumentNullException(nameof(targetNode));        // 예외상황 발생
            }

            LinkedListNode<T> newNode = new LinkedListNode<T>(this, targetNode, targetNode.next, item); // newNode 생성

            // 연결구조 변경 시작
            if (targetNode.next != null)                                    // targetNode의 next가 null이 아니면
            {
                targetNode.next.prev = newNode;                             // targetNode의 next 노드의 prev를 newMode 로

            }
            else                                                            // targetNode의 next이 null 이다, 즉 targetNode가 tail 이다.
            {
                this.tail = newNode;                                             // tail를 newNode로 바꿔준다.
            }
            targetNode.next = newNode;                                      // targetNode의 next를 newNode로 바꿔준다.

            this.count++;

            return newNode;                                                 // newNode 반환
        }

        public LinkedListNode<T> Find(T item)
        {
            LinkedListNode<T> target = this.head;                                // '처음'부터 찾아줄거니까 target에 head를 넣고
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;     // 비교를 위한 comparer 

            while(target != null)                                           // target 이 null이 아닌동안 동작하는 while ON
            {
                if (comparer.Equals(target.Value, item))                    // target의 Value(item)과 item이 같다면 
                {
                    return target;                                          // target을 반환해주고
                } else
                {
                    target = target.next;                                   // 다르다면 target을 target.next(다음 노드)로 !
                }
            }

            return null;                                                    // item의 값을 가진 Node가 없었기에 null을 반환
        }
        
        public LinkedListNode<T> FindLast(T item)
        {
            LinkedListNode<T> target = this.tail;                                // '끝'에서 부터 찾아줄거니까 target에 tail를 넣고
            EqualityComparer<T> comparer = EqualityComparer<T>.Default;     // 비교를 위한 comparer 

            while (target != null)                                           // target 이 null이 아닌동안 동작하는 while ON
            {
                if (comparer.Equals(target.Value, item))                    // target의 Value(item)과 item이 같다면 
                {
                    return target;                                          // target을 반환해주고
                }
                else
                {
                    target = target.prev;                                   // 다르다면 target을 target.prev(이전 노드)로 !
                }
            }

            return null;                                                    // item의 값을 가진 Node가 없었기에 null을 반환
        }

        public bool Remove(T item)
        {
            LinkedListNode<T> findNode = Find(item);                        // Find 에서 해당 item 값의 노드를 찾아보고
            if(findNode != null)                                            // 해당 값으로 노드가 존재하면
            {
                Remove(findNode);                                           // 매개변수를 LinkedListNode로 하는 Remove 함수 호출
                return true;                                                // True 반환
            }

            return false;                                                   // 해당 값을 가진 Node를 찾지 못하여 삭제가 이뤄지지 않았으므로 false 반환
        }

        public void Remove(LinkedListNode<T> node)
        {
            if(node.list != this || node == null)                           // 예외처리 Node가 현재의 LinkedList에 없거나 Null 인 경우 
            {
                throw new ArgumentNullException(nameof(node));              // 예외상황 발생
            }

            if (node == this.head)                                               // node 가 head 였다?
                this.head = node.next;                                           // head 는 이제 node의 next 다.
            if (node == this.tail)                                               // node 가 tail 이였다.
                this.tail = node.prev;                                           // tail 은 이제 node의 prev다.

            if (node.prev != null)                                          // node의 prev가 존재할 때
                node.prev.next = node.next;                                 // 이제 node의 prev의 next는 node의 next다.
            if (node.next != null)                                          // node의 next가 존재할 때
                node.next.prev = node.prev;                                 // 이제 node의 next의 prev는 node의 prev다.

            this.count--;
        }


        /// <summary>
        /// Remove(this.head) 한 줄이면 구현 가능하지만.. 그래도 써봤습니다...
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        public void RemoveFirst()
        {
            if (this.head == null)                                          // head 가 없는데 이 함수를 불러왔다? 
                throw new ArgumentNullException();                          // 바로 예외상황 날려버리기

            this.head.next.prev = null;                                     // head의 바로 다음 Node의 prev을 없애주고
            this.head = this.head.next;                                     // head를 이제 head.next로 바꿔준다.

            count--;                                                        // 카운트 차감
        }

        public void RemoveLast()
        {
            if (this.tail == null)                                          // tail이 없는데 이 함수를 불러왔다? 
                throw new ArgumentNullException();                          // 바로 예외상황 날려버리기

            this.tail.prev.next = null;                                     // tail의 바로 이전 Node의 next를 없애주고
            this.tail = this.tail.prev;                                     // tail을 이제 tail.prev로 바꿔준다.

            count--;                                                        // 카운트 차감
        }

        public bool Contains(T value)                                       
        {
            if(Find(value) != null)                                         // Find 함수를 호출하여 Node가 넘어온다면
                return true;                                                // True 반환
            return false;                                                   // 아니라면 False 반환
        }
    }
}
