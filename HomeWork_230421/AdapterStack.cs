using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_230421
{
    internal class AdapterStack<T>
    {
        private List<T> container;                                          // Stack 구현에 사용될 List                      
        public int Count { get {  return container.Count; } }

        public AdapterStack()                                               // AdapterStack 생성자
        {
            container = new List<T>();                                      // container, List<T>인스턴스 생성
        }

        public void Push(T item)                                            // Push 구현
        {   
            container.Add(item);                                            // List자료구조인 container 에 Item 을 Add
        }

        public T Pop()                                                      // Pop 구현
        {
            if (container[container.Count - 1] == null)                     // 예외처리
                throw new InvalidOperationException();

            T result = container[container.Count - 1];                      // Result 에 container의 마지막 인덱스의 데이터를 넣는다.                      
            container.RemoveAt(container.Count - 1);                        // 그리고, container의 마지막 인덱스를 삭제한다.
            return result;                                                  // List(container)의 마지막 값 result 반환

        }
        
        public T Peek()
        {
            if (container[container.Count - 1] == null)                     // 예외처리
                throw new InvalidOperationException();

            
            return container[container.Count - 1];                          // List(container)의 마지막 값 반환
        }
    }
}
