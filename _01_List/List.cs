using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure
{
    internal class List<T> 
    {
        private const int DefaultCapacity = 10;
        private T[] items;
        private int size;

        public List()
        {
            this.items = new T[DefaultCapacity];
            this.size = 0;
        }

        public int Count { get { return this.size; } }
        public int Capacity { get { return this.items.Length; } }
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= this.size)
                    throw new IndexOutOfRangeException();
                return items[index];
            }
            set
            {
                if (index < 0 || index >= this.size)
                    throw new IndexOutOfRangeException();
                items[index] = value;
            }
        }

        public void Add(T item)
        {
            if (size < items.Length)
            {
                this.items[this.size++] = item;
            } else
            {
                Grow();
                this.items[this.size++] = item;
            }
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

        public void RemoveAt(int index)
        {
            if(index < 0 || index >= this.size)
            {
                throw new IndexOutOfRangeException();
            }
            this.size--;
            Array.Copy(items,index + 1, items, index, size - index);
        }

        public int IndexOf(T item)
        {
            return Array.IndexOf(this.items, item , 0 , this.size);
        }

        public void Grow()
        {
            int newCapacity = items.Length * 2;
            T[] newItems = new T[newCapacity];

            Array.Copy(items,0,newItems,0,size);
            items = newItems;
        }

        public int FindIndex(Predicate<T> match)
        {
            for(int i = 0; i < this.size; i++)
            {
                if (match(items[i]))
                    return i;
            }
            return -1;
        }

        public T? Find(Predicate<T> match)
        {
            if(match == null)
                throw new ArgumentNullException("match");

            for(int i = 0; i < this.size; i++)
            {
                if (match(items[i]))
                {
                    return items[i];   
                }
            }

            return default(T);  // 해당 자료형의 기본값 리턴
        }
    }
}
