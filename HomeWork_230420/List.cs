using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_230420
{
    /*
     *  1. 선형리스트 구현 - msdn C#의 List 참고
     *     인덱서[], Add, Remove,RemoveAt, Find, FindIndex, Count 등등
     * 
     *  2. 배열, 선형리스트 기술면접 정리
     */
    internal class List<T> : IEnumerable<T>
    {
        private int arraySize;
        private int DefaultCapacity = 10;
        private T[] array;
        public int Count { get { return arraySize; } }   // Count getter & setter
        public int Capacity { get { return this.array.Length; } }    // Capacity getter & setter

        public T this[int index]                            // Indexer
        {
            get
            {
                if (index < 0 || index >= this.arraySize)
                    throw new ArgumentOutOfRangeException();
                return array[index];
            }
            set
            {
                if (index < 0 || index >= this.arraySize)
                    throw new ArgumentOutOfRangeException();
                array[index] = value;
            }
        }

        public List()
        {
            this.array = new T[DefaultCapacity];
            this.arraySize = 0;
        }

        public void Add(T item)
        {
            if (this.arraySize < Capacity)
            {
                array[this.arraySize++] = item;
            }
            else
            {
                UpgradeArray();
                array[this.arraySize++] = item;
            }
        }

        public void UpgradeArray()
        {
            int Capacity = this.array.Length * 2;
            T[] newArray = new T[Capacity];
            Array.Copy(this.array, 0, newArray, 0, this.arraySize);
            this.array = newArray;
        }

        public bool Remove(T item)
        {
            int itemIndex = IndexOf(item);
            if (itemIndex >= 0)
            {
                RemoveAt(itemIndex);
                return true;
            }
            return false;

        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(this.array, item, 0, this.arraySize);
        }

        public void RemoveAt(int index)
        {
            if (index > this.arraySize)
            {
                throw new AbandonedMutexException();        // Exception
            }
            this.arraySize--;

            //  [0][1][2][3][4][5][6][7][8]
            //            @
            //    (소스배열 , 잘라올 인덱스 위치 , 덮어쓸 배열, 덮어쓸 위치, 덮어쓸 자료의 양)
            Array.Copy(this.array, index + 1, this.array, index, this.arraySize - index);

        }

        public int FindIndex(Predicate<T> match)
        {
            for (int i = 0; i < this.arraySize; i++)
            {
                if (match(array[i]))
                    return i;
            }
            return -1;

        }

        public T? Find(Predicate<T> match)
        {
            if (match == null)
                throw new ArgumentNullException("match");

            for (int i = 0; i < this.arraySize; i++)
            {
                if (match(array[i]))
                {
                    return array[i];
                }
            }
            return default(T);  // 해당 자료형의 기본값 리턴

        }

        public T? FindLast(Predicate<T> match)
        {
            if (match == null)
                throw new ArgumentNullException("match");

            for (int i = this.arraySize; i >= 0; i--)
            {
                if (match(array[i]))
                {
                    return array[i];
                }
            }
            return default(T);  // 해당 자료형의 기본값 리턴

        }

        public int FindLastIndex(Predicate<T> match)
        {
            for (int i = this.arraySize; i >= 0; i--)
            {
                if (match(array[i]))
                    return i;
            }
            return -1;

        }


        public void Insert(int index, T item)
        {
            if (index < 0 || index > this.arraySize)
                throw new ArgumentOutOfRangeException("index");

            this.arraySize++;
            if (this.arraySize > this.Capacity)
            {
                UpgradeArray();
            }
            Array.Copy(this.array, index, this.array, index + 1, this.arraySize - index);
            this.array[index] = item;

        }


        public void Clear()
        {
            T[] newArray = new T[DefaultCapacity];
            this.array = newArray;

        }

        // List<T> 에 Enumerator 구현
        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);                                        // Enumerator 반환
        }                                                                       
                                                                                
        IEnumerator IEnumerable.GetEnumerator()                                 
        {                                                                       
            return new Enumerator(this);                                        // Enumerator 반환
        }                                                                       
                                                                                
        public struct Enumerator : IEnumerator<T>                               // IEnumerator 인터페이스의 Enumerator 구조체
        {                                                                       
            private List<T> list;                                               // List 
            private int index;                                                  // index
            private T current;                                                  // List의 값이 들어갈 current
            public T Current { get { return current; } }                        // current Getter

            object IEnumerator.Current { get { return current; } } 
            public Enumerator(List<T> list)                                     // Enumerator 생성자
            {
                this.list = list;                                               
                this.index = 0;
                this.current = default(T);
            }

            public void Dispose()                                               // 무시
            {
                //throw new NotImplementedException();
            }

            public bool MoveNext()                                              // 반복기에서 호출되는 함수
            {
                if(this.index < this.list.Count)                                // Index가 List의 크기보다 작을 경우엔
                {
                    this.current = this.list[index++];                          // 현재 current에 list[index] 값을 넣어주고 ++ 를 통해 후위증감 해준다.
                                                                                // 이래야지만 .. 반복기가 돌아갈때 인덱스:0 부터 값이 전달 됨
                    return true;                                                // true 반환
                }
                this.current = default(T);                                      // index가 List의 크기를 넘어가는 경우 current를 해당 자료형의 default 값으로
                return false;                                                   // 그리고 false 반환
            }

            public void Reset()                                                 // 초기화
            {
                this.index = 0;
                this.current = default(T);
            }
        }
    }
}
