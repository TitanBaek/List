using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            // 예외처리
            if(node.list != this)                               // 노드가 연결리스트에 포함된 노드가 아닌경우
                throw new InvalidOperationException();
            if (node == null)                                   // 노드가 Null인 경우
                throw new ArgumentNullException(nameof(node));

            // 0. 삭제 시 head 나 tail이 변경되는 경우
            if (head == node)
                head = node.next;
            if(tail == node)
                tail = node.prev;

            // 1. 연결구조 바꾸기
            if(node.prev != null)
                node.prev.next = node.next;
            if(node.next != null)
                node.next.prev = node.prev;
            // 2. 실제 노드 삭제
            count--;
        }

        public bool Remove(T value)
        {
            LinkedListNode<T> findNode = Find(value); // 찾는 노드
            if(findNode != null)
            {
                Remove(findNode);
                return true;
            }
            return false;
        }

        public LinkedListNode<T> Find(T value)
        {
            LinkedListNode<T> target = head;
            EqualityComparer<T> compare = EqualityComparer<T>.Default; // 일반화 '똑같은지' 비교하는거
            while(target != null)
            {
                if (compare.Equals(value,target.Value))
                {
                    return target;
                } else
                {
                    target = target.next;
                }
            }
            return null;
        }

        
        public LinkedListNode<T> AddBefore (LinkedListNode<T> node, T item)
        {
            // 0. 예외처리
            if(node.list == this)
                throw new ArgumentNullException(nameof(node));
            if(node == null)
                throw new ArgumentNullException(nameof(node));

            // 1. 새로운 노드
            LinkedListNode<T> newNode = new LinkedListNode<T>(this,node.prev, node, item);

            // 2. 연결구조
            if (node.prev != null)
            {
                node.prev.next = newNode;
            }
            else
            {
                this.head = newNode;
            }

            node.prev = newNode;

            // 3. 갯수 증가
            count++;

            return newNode;
        }
        
        public LinkedListNode<T> AddAfter (LinkedListNode<T> node, T item)
        {
            // 0. 예외처리
            if (node.list == this)
                throw new ArgumentNullException(nameof(node));
            if (node == null)
                throw new ArgumentNullException(nameof(node));

            // 1. 새로운 노드
            LinkedListNode<T> newNode = new LinkedListNode<T>(this, node, node.next, item);

            // 2. 연결구조
            if (node.next != null)
            {
                node.next.prev = newNode;
            }
            else
            {
                this.tail = newNode;
            }

            node.next = newNode;

            // 3. 갯수 증가
            count++;

            return newNode;

        }

    }
}
