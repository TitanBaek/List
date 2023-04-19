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
            if (head != null)                                               // head가 안 비어있다.
            {
                newNode.next = head;                                        // newNode의 next 는 구)head
                head.prev = newNode;                                        // 이제 앞으로 밀려나니까 구)head의 prev는 newNode
            
            } else                                                          // head가 비어있다. 즉 최초로 값을 넣는 경우
            {
                tail = newNode;                                             // LinkedList는 비어있었으니 head와 tail는 newNode다
            }
            head = newNode;                                                 // 위 조건문에 head = newNode는 무조건 들어가기 때문에 조건문 밖으로 빼줬음.

            return newNode;
                

        }

        public LinkedListNode<T> AddLast(T item)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(this,item);        // 새노드 생성
            if (tail != null)                                               // tail이 안 비어있다.
            {
                newNode.prev = tail;                                        // newNode의 prev는 구)tail
                tail.next = newNode;                                        // 구)tail의 next는 newNode
            }
            else                                                            // tail이 비어있다.
            {
                head = newNode;                                             // LinkedList는 비어있었으니 head와 tail은 newNode다.
            }
            tail = newNode;                                                 // 위 조건문에 tail = newNode가 무조건 들어가니 조건문 밖으로 빼줬음.

            return newNode;                                                 // 반환 newNode
        }

        public LinkedListNode<T> AddBefore(LinkedListNode<T> targetNode,T item)
        {
            
            if(targetNode.list != this || targetNode == null)               // 예외처리  - 전달 받은 targetNode가 현재의 LinkedList에 없는 경우 || targetNode가 null 인 경우
            {
                throw new ArgumentNullException(nameof(targetNode));        // 예외처리 날려버리기
            }
            LinkedListNode<T> newNode = new LinkedListNode<T> (this, targetNode.prev, targetNode, item); // newNode 생성

            // 연결구조 변경 시작
            if(targetNode.prev != null)                                     // targetNode의 Prev이 null이 아니면
            {
                targetNode.prev.next = newNode;                             // targetNode의 Prev 노드의 Next를 newMode 로
            
            }
            else                                                            // targetNode의 Prev이 null 이다, 즉 targetNode가 head 다.
            {
                head = newNode;                                             // head를 newNode로 바꿔준다.
            }
            targetNode.prev = newNode;                                      // targetNode의 Prev을 newNode로 바꿔준다.

            return newNode;                                                 // newNode 반환
        }

        public LinkedListNode<T> AddAfter(LinkedListNode<T> targetNode,T item)
        {
            if (targetNode.list != this || targetNode == null)               // 예외처리  - 전달 받은 targetNode가 현재의 LinkedList에 없는 경우 || targetNode가 null 인 경우
            {
                throw new ArgumentNullException(nameof(targetNode));        // 예외처리 날려버리기
            }

            LinkedListNode<T> newNode = new LinkedListNode<T>(this, targetNode, targetNode.next, item); // newNode 생성

            // 연결구조 변경 시작
            if (targetNode.next != null)                                    // targetNode의 next가 null이 아니면
            {
                targetNode.next.prev = newNode;                             // targetNode의 next 노드의 prev를 newMode 로

            }
            else                                                            // targetNode의 next이 null 이다, 즉 targetNode가 tail 이다.
            {
                tail = newNode;                                             // tail를 newNode로 바꿔준다.
            }
            targetNode.next = newNode;                                      // targetNode의 next를 newNode로 바꿔준다.

            return newNode;                                                 // newNode 반환
        }

        public LinkedListNode<T> Find(T item)
        {

        }
        
        public LinkedListNode<T> FindLast(T item)
        {

        }

        public LinkedListNode<T> Remove(T item)
        {

        }

        public LinkedListNode<T> Remove(LinkedListNode<T> node)
        {

        }

        public LinkedListNode<T> RemoveFirst(T value)
        {

        }

        public LinkedListNode <T> RemoveLast(T value)
        {

        }
    }
}
