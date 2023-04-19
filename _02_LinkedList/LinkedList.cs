using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    public class LinkedListNode<T>  // 어떤 데이터가 들어올지 모르니 일반화
    {
        internal LinkedList<T> list;
        internal LinkedListNode<T> prev;     // 이전 데이터의 주소값
        internal LinkedListNode<T> next;     // 다음 데이터의 주소값
        private T item;                      // 값

        public LinkedList<T> List { get { return list; } }
        public LinkedListNode<T> Prev {  get { return prev; } }     // prev 의 Getter
        public LinkedListNode<T> Next {  get { return next; } }     // next 의 Getter
        public T Value { get { return item; }  set { item = value; }  }

        public LinkedListNode(T value)
        {
            this.list = null;
            this.prev = null;
            this.next = null;
            this.item = value;
        }

        public LinkedListNode(LinkedList<T> list, T value)
        {
            this.list = list;
            this.prev = null;
            this.next = null;
            this.item = value;
        }

        public LinkedListNode(LinkedList<T> list, LinkedListNode<T> prev, LinkedListNode<T> next, T value)
        {
            this.list = list;
            this.prev = prev;
            this.next = next;
            this.item = value;
        }

    }
    public class LinkedList<T>
    {
        private LinkedListNode<T> head;
        private LinkedListNode<T> tail;
        private int count;

        public LinkedListNode<T> First { get { return head; } }
        public LinkedListNode<T> Last  { get { return tail; } }
        public int Count { get { return count; } }

        public LinkedList()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        public LinkedListNode<T> AddFirst(T item)
        {
            //1. 새로운 노드 추가
            LinkedListNode<T> newNode = new LinkedListNode<T>(this,item);
            //2. 연결구조 바꾸기
            if (head != null)           //2-1 Head 노드가 있을 때
            {  
                newNode.next = head;
                head.prev = newNode;
                head = newNode;
            } else
            {
                head = newNode;
                tail = newNode;
            }
            count++;
            return newNode;
        }

        public LinkedListNode<T> AddLast(T item)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(this,item);
            if(tail != null)
            {
                newNode.prev = tail;
                tail.next = newNode;
                tail = newNode;
            }
            else
            {
                head = newNode;
                tail = newNode;
            }
            count++;
            return newNode;
        }

        public void Remove(LinkedListNode<T> node)
        {
            // 1. 연결구조 바꾸기
            // 2. 실제 노드 삭제
        }

        /*
        public LinkedListNode<T> AddBefore (LinkedListNode<T> targetNode, T item)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, item);
            // targetNode 의 prev,next 를 가져와야함
            // targetNode 의 prev 주소값의 녀석의 Next를 newNode로 해주고
            // targetNode 의 prev 주소값을 newNode로 한다.

        }

        public LinkedListNode<T> AddAfter (LinkedListNode<T> targetNode, T item)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, item);

        }
        */

    }
}
