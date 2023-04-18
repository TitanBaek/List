using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_230418
{
    /*
     *  1. 선형리스트 구현 - msdn C#의 List 참고
     *     인덱서[], Add, Remove,RemoveAt, Find, FindIndex, Count 등등
     * 
     *  2. 배열, 선형리스트 기술면접 정리
     */
    internal class List<T>
    {
        private int arraySize;
        private int DefaultCapacity = 10;
        private T[] array;
        public int Count { get { return array.Length; } }   // Count getter & setter
        public int Capacity { get { return Capacity; } }    // Capacity getter & setter
        
        public T this[int index]                            // Indexer
        {
            get { return array[index]; }
            set { array[index] = value; }
        }

        public List()
        {
            this.array = new T[DefaultCapacity];
            this.arraySize = 0;
        }

        public void Add(T item)
        {
            if(this.arraySize <  DefaultCapacity)
            {
                array[this.arraySize++] = item;
            } else
            {
                UpgradeArray();
                array[this.arraySize++] = item;
            }
        }

        public void UpgradeArray()
        {
            int Capacity = this.Capacity * 2;
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
            if(index > this.arraySize)
            {
                throw new AbandonedMutexException();        // Exception
            }
            this.arraySize--;

            //  [0][1][2][3][4][5][6][7][8]
            //            @
            //    (소스배열 , 잘라올 인덱스 위치 , 덮어쓸 배열, 덮어쓸 위치, 덮어쓸 자료의 양)
            Array.Copy(this.array, index+1, this.array,index, this.arraySize - index);
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
            for (int i = this.arraySize; i >= 0 ; i--)
            {
                if (match(array[i]))
                    return i;
            }
            return -1;
        }

        public void Contains()
        {

        }

        public void Insert(int index, T item)
        {

        }

        public bool CopyTo(T[] sourceArray)
        {
            return false;
        }

        public bool ToArray(T[] array, int arrayIndex)
        {
            return false;
        }

        public void Clear()
        {
            T[] newArray = new T[DefaultCapacity];
            this.array = newArray;
        }

    }
}
