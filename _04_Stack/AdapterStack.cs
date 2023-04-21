using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Stack
{
    /******************************************************
	 * 어댑터 패턴 (Adapter)
	 * 
	 * 한 클래스의 인터페이스를 사용하고자 하는 다른 인터페이스로 변환
	 ******************************************************/
    internal class AdapterStack<T>
    {
        private List<T> container;                              // Stack 구현에 사용될 List
        public AdapterStack()                                   // AdapterStack 생성자
        {
            container = new List<T>();                          // container 생성
        }

        public void Push(T item)                                // Push 구현
        {
            container.Add(item);                                // 매개변수로 전달받은 데이터를 item에 Add한다.
        }

        public T Pop()                                          // Pop 구현
        {
            T item = container[container.Count - 1];            // List(container)의 마지막 값 item에 넣고
            container.RemoveAt(container.Count - 1);            // List에선 그 값을 지워줌
            return item;                                        // item 반환
        }

        public T Peek()
        {
            return container[container.Count - 1];              // List(container)의 마지막 값 반환
        }
    }
}
