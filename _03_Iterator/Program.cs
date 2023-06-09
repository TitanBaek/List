﻿using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace _03_Iterator
{
    internal class Program
    {
        /******************************************************
		 * 반복기 (Enumerator(Iterator))
		 * 
		 * 자료구조에 저장되어 있는 요소들을 순회하는 인터페이스
		 ******************************************************/
        /*
        public void Test1()
        {
            // 대부분의 자료구조가 반복기를 지원함
            // 반복기를 이용한 기능을 구현할 경우, 그 기능은 대부분의 자료구조를 호환할 수 있음
            List<int> myList = new List<int>();
            LinkedList<int> myLinked = new LinkedList<int>();
            Stack<int> stack = new Stack<int>();
            Queue<int> queue = new Queue<int>();
            SortedList<int, int> sList = new SortedList<int, int>();
            SortedSet<int> set = new SortedSet<int>();
            SortedDictionary<int, int> map = new SortedDictionary<int, int>();
            Dictionary<int, int> dic = new Dictionary<int, int>();


            // 반복기를 이용한 순회
            // foreach 반복문은 데이터집합의 반복기를 통해서 단계별로 반복
            // 즉, 반복기(Enumerator/Iterator)가 있다면 foreach 반복문으로 순회 가능
            foreach (int i in myList) { }
            foreach (int i in myLinked) { }
            foreach (int i in stack) { }
            foreach (int i in queue) { }
            foreach (int i in set) { }
            foreach (KeyValuePair<int, int> i in sList) { }
            foreach (KeyValuePair<int, int> i in map) { }
            foreach (KeyValuePair<int, int> i in dic) { }
            
            //foreach (int i in IterFunc()) { }

            List<string> strings = new List<string>();
            for (int i = 0; i < 15; i++) strings.Add($"{i}데이터");

            IEnumerator<string> iter = strings.GetEnumerator();
            iter.MoveNext();                                
            Console.WriteLine(iter.Current);
            iter.MoveNext();
            Console.WriteLine(iter.Current);

            iter.Reset();                                   // 반복기가 처음으로

            while (iter.MoveNext())
            {
                Console.WriteLine(iter.Current);
            }

        }

        public void Find(IEnumerable<int> container)
        {
            IEnumerator<int> iter = container.GetEnumerator();

            iter.Reset();
            while (iter.MoveNext())
            {
                if(iter.Current == 10)
                {
                    Console.WriteLine("10 찾음");
                }
            }
        }

        IEnumerable<int> IterFunc()
        {
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;

        }
        */

        static void Main(string[] args)
        {
            /*
            _03_Iterator.List<int> list = new _03_Iterator.List<int>();
            for (int i = 1; i <= 10; i++) list.Add(i);

            IEnumerator<int> iter = list.GetEnumerator();            
            Console.WriteLine(iter.Current);

            foreach(int i in list) Console.WriteLine(i);
            Console.WriteLine();
            while (iter.MoveNext())
            {
                Console.WriteLine(iter.Current);
            }

            Stack<int> stack = new Stack<int>();
            */

            _03_Iterator.LinkedList<int> myLinked = new _03_Iterator.LinkedList<int>();
            for(int i = 1; i <= 10; i++)
            {
                myLinked.AddLast(i);
            }

            IEnumerator<int> myEnumerator = myLinked.GetEnumerator();

            while(myEnumerator.MoveNext())
            {
                Console.WriteLine(myEnumerator.Current);
            }
            /*
            foreach(int i in myLinked)
            {
                Console.WriteLine(i);
            }
            */
        }
    }
}