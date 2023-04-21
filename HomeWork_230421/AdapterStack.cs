using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_230421
{
    internal class AdapterStack<T>
    {
        private List<T> container;
        
        public AdapterStack()
        {
            container = new List<T>();
        }

        public void Push(T item)
        {
            container.Add(item);
        }

        public T Pop()
        {
            if (container.Count == 0)
                throw new InvalidOperationException();

            T result = container[container.Count - 1];
            container.RemoveAt(container.Count - 1);
            return result;

        }
        
        public T Peek()
        {
            if (container.Count == 0)
                throw new InvalidOperationException();

            T result = container[container.Count - 1];
            return result;
        }
    }
}
