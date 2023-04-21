using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Queue
{
    /******************************************************
    * 어댑터 패턴 (Adapter)
    * 
    * 한 클래스의 인터페이스를 사용하고자 하는 다른 인터페이스로 변환
    ******************************************************/
    internal class Queue<T>
    {
        private const int DefaultCapacity = 4;
        private T[] array;
        private int head;
        private int tail;
        public int Count { 
            get 
            { 
                if (head <= tail) 
                    return tail - head; 
                else 
                    return tail - head + array.Length; 
            } 
        }
        public Queue()
        {
            this.array = new T[DefaultCapacity + 1];
            this.head = 0;                                      // 전단: 현 데이터가 있는 위치
            this.tail = 0;                                      // 후단: 새 데이터가 들어갈 위치
        }

        public void Enqueue(T item)
        {
            if (IsFull())
                Grow();

            array[tail] = item;
            MoveNext(ref tail);
        }

        public T Dequeue()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            T result = array[head];
            MoveNext(ref head);
            return result;
        }

        public T Peek()
        {
            if (IsEmpty())
                throw new InvalidOperationException();

            return array[head];
        }

        private void MoveNext(ref int index)                    // ref 키워드로 매개변수를 받아서 현 함수내에서 Enqueue의 head,tail의 index를 정해줌.
        {
            index = (index == array.Length - 1) ? 0 : index+1;  // 끝에 있는 경우 0 번으로 가고 아니면 Index 는 +1 증감한다.
        }

        public bool IsEmpty()
        {
            return head == tail;                                // 전단과 후단이 같은 위치라면.. 텅텅 비어있는 Queue이다.
        }

        public bool IsFull()
        {
            if (head > tail)
                return head == tail + 1;                            // 후단이 전단의 바로 전에 위치해있다면 꽉 채워져있는 Queue이다.
            else
                return head == 0 && tail == array.Length - 1;       // 전단이 맨 앞 위치에 있고 후단이 맨 뒤에 위치해있을 경우 꽉 채워져있는 Queue이다.
        }

        public void Grow()                                          // Queue가 꽉 차있으면 공간을 늘려줌
        {
            int newCapacity = array.Length * 2;
            T[] newArray = new T[newCapacity];
            if(head < tail)
            {
                Array.Copy(array, newArray, Count);
            }                
            else
            {
                Array.Copy(array, head, newArray, 0, array.Length - head);
                Array.Copy(array, 0, newArray, array.Length - head, tail);
                head = 0;
                tail = Count;
            }
            array = newArray;
        }


    }
}
