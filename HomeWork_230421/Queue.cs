using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_230421
{
    internal class Queue<T>
    {
        private const int defaultCapacity = 4;
        private T[] array;
        private int head;
        private int tail;

        public int Count                                                            // Queue 의 Count(데이터 수)
        {
            //  t           h
            // [ ] [2] [3] [4] [ ] [ ]
            //  0   1   2   3   4   5            

            //      h       t
            // [ ] [2] [3] [ ] [ ] [ ]
            //  0   1   2   3   4   5
            get
            {
                if (this.head <= this.tail)                                         // 전단이 후단과 같거나 앞에 위치해 있을 때
                    return this.tail - this.head;                                   // 후단 위치 값 - 전단 위치 값 <- Queue 내의 데이터 값을 구하는 식
                else                                                                // 전단이 후단보다 뒤에 위치해 있을 때
                    return this.tail + (this.array.Length - this.head);             // 후단 + ( 배열 길이 - 전단 위치) <- Queue 내의 데이터 값을 구하는 식
            }
        }

        public Queue()
        {
            this.array = new T[defaultCapacity + 1];                                // 전단과 후단이 겹치는 불상사를 막기 위해, 추가(1) 여유공간을 확보해준다.
            this.head = 0;                                                          // Queue 생성 시 전단(뺄 데이터를 가르키는)은 0
            this.tail = 0;                                                          // 후단(데이터를 삽입할 위치를 가르키는)은 0

        }

        public void Enqueue(T item)                                                 // Queue에 값을 넣어주는 함수
        {
            if (IsFull())                                                           // 이 Queue가 꽉 차있는지 확인하는 함수 호출
            {
                Grow();                                                             // 꽉 차있다면 Queue 자료구조의 크기를 키워주는 함수를 호출한다.
            }
            this.array[this.tail] = item;                                                // array의 후단 위치에 데이터를 넣어주고
            MoveNext(ref this.tail);                                                // 후단의 위치를 이동시키는 함수를 호출
        }

        public T Dequeue()                                                          // Queue의 값을 빼는 함수
        {
            if(IsEmpty())                                                           // Queue가 비어있는지 확인하는 함수 호출
                throw new InvalidOperationException();                              // 예외상황 날리기
            T result = this.array[this.head];                                       // result에 전단위치의 데이터를 넣어주고
            MoveNext(ref this.head);                                                // 전단의 위치를 이동시키는 함수를 호출
            return result;                                                          // result 반환
        }

        public T Peek()
        {
            if (IsEmpty())                                                          // Queue가 비어있는지 확인하는 함수 호출
                throw new InvalidOperationException();                              // 예외상황 날리기
            T result = this.array[this.head];
            return result;
        }

        public void MoveNext(ref int index)                                         // ref(참조) 키워드를 사용 매개변수를 받아서 현 함수내에서 전단,후단의 위치를 지정해줌
        {
            index = (index == this.array.Length -1 ) ? 0 : index + 1;               // index(전단 또는 후단)의 위치가 마지막 위치라면 0을 아니라면 현 위치에서 +1 해준다.
        }

        public bool IsEmpty()                                                       // Queue 가 비어있는지, bool 형을 반환하는 함수 
        {
            return this.head == this.tail;                                          // 전단과 후단의 위치가 같다면(0일 경우) Queue는 비어있다.
        }

        public bool IsFull()                                                        // Queue 가 꽉 차있는지 bool 형을 반환하는 함수
        {
            //      h           t
            // [ ] [2] [3] [4] [ ] [ ]
            //  0   1   2   3   4   5
            if(this.head > this.tail)                                               // 전단이 후단보다 뒤에 위치한 경우
            {
                return this.head == this.tail + 1;                                  // 후단의 위치가 전단의 바로 뒤라면 Queue는 꽉 차있다.
            } else                                                                  // 전단이 후단 앞에 위치한 경우
            { 
                return this.head == 0 && this.tail == this.array.Length - 1;        // 전단이 후단의 뒤에 위치해있고 전단의 위치가 0이며 후단의 위치가 마지막 위치인 경우 Queue는 꽉 차있다.
            }
        }

        public void Grow()
        {
            int newCapacity = this.array.Length * 2;
            T[] newArray = new T[newCapacity];

            //      h           t
            // [ ] [2] [3] [4] [ ] [ ]
            //  0   1   2   3   4   5
            if (this.head < this.tail)                                              // 전단이 후단보다 앞에 위치한 경우
            {
                Array.Copy(this.array,newArray, this.Count);                        // newArray에 array의 0부터 Count 만큼의 데이터를 복사한다.
            } else
            {
                //          t       h
                // [7] [8] [ ] [ ] [5] [6]
                // [5] [6] [ ] [ ] [ ] [ ] [ ] [ ] [ ] [ ] [ ] [ ]
                Array.Copy(this.array, this.head, newArray, 0, this.array.Length - this.head);          // newArray의 0 위치에 array의 전단 위치부터 ~ (array 배열의 총 크기 - 전단위치) 까지의 데이터를 복사한다. 
                //          t       h
                // [7] [8] [ ] [ ] [5] [6]
                // [5] [6] [7] [8] [ ] [ ] [ ] [ ] [ ] [ ] [ ] [ ]
                Array.Copy(this.array, 0, newArray, this.array.Length - this.head, this.tail);          // newArray의 (array배열 크기 - 전단위치) 위치에 array의 0 위치부터 후단위치 까지의 데이터를 복사한다.
                this.head = 0;                                                                          // 전단 위치를 0으로 초기화해주고
                this.tail = this.Count;                                                                 // 후단의 위치를 Count 로
            }

            this.array = newArray;                                                                      // array를 newArray로 덮어씌워준다.
        }

    }
}
