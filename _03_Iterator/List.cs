﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_Iterator
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
            if (this.arraySize >= this.array.Length)
                UpgradeArray();

            this.array[this.arraySize++] = item;
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



        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        


        public struct Enumerator : IEnumerator<T>
        {
            private List<T> list; 
            private int index;
            private T current;
            public T Current { get { return current; } }
            object IEnumerator.Current{ get {  return current;  }  }

            public Enumerator(List<T> list)
            {
                this.list = list;
                this.index = 0;
                this.current = default(T);
            }

            public void Dispose()
            {
                // 무시.
            }

            public bool MoveNext()
            {
                if (index < list.Count)
                {
                    current = list[index++];            // 후위증가 컨셉 MoveNext
                    return true;
                }
                current = default(T);
                return false;
            }

            public void Reset()
            {
                this.index = 0;
                this.current = default(T);
            }
        }
    }
}

