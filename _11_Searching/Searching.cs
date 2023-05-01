using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_Searching
{
    internal class Searching
    {
        // <순차 탐색>
        public static int SequentialSearch<T>(in IList<T> list, in T item) where T : IComparable<T>
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (item.CompareTo(list[i]) == 0)
                    return i;
            }
            return -1;
        }

        // <이진 탐색>
        // BinarySearch의 경우 
        // Sort가 된 상황에서만 결과가 올바르게 나올 수 있음
        // low 와 high 
        public static int BinarySearch<T>(in IList<T> list, in T item) where T : IComparable<T>
        {
            return BinarySearch(list, item, 0, list.Count);
        }

        public static int BinarySearch<T>(in IList<T> list, in T item, int index, int count) where T : IComparable<T>
        {
            if (index < 0)
                throw new IndexOutOfRangeException();
            if (count < 0)
                throw new ArgumentOutOfRangeException();
            if (index + count > list.Count)
                throw new ArgumentOutOfRangeException();

            int low = index;
            int high = index + count - 1;
            while (low <= high)
            {
                int middle = (int) low + high >> 1; // 비트연산자를 사용하면 겁나 빠르다.
                int compare = list[middle].CompareTo(item);

                if(compare < 0) // 찾으려는 아이템이 middle 보다 작다
                {
                    low = middle + 1;
                } else if(compare > 0) // 찾으려는 아이템이 middle 보다 높다
                {
                    high = middle - 1;
                } else
                {
                    return middle;
                }

            }

            return -1;
        }

        // 그래프 탐색의 대표적인 알고리즘 2가지
        // DFS, BFS 두 방식의 구현방법과 차이점 알아보기

        // DFS : 깊이 우선 탐색 (Depth First Search)
        // 그래프의 분기를 만났을 때 최대한 깊이 내려간 뒤
        // 더이상 깊이 갈 곳이 없을 경우 다음 분기를 탐색함
        // 백트래킹 방식, 찌르고 보는 방식
        // 분할정복으로 구현됨

        public static void DFS(bool[,] graph,int start,out bool[] visited, out int[] parents)
        {
            visited = new bool[graph.GetLength(0)]; // 1차 배열 크기
            parents = new int[graph.GetLength(0)];

            for(int i = 0; i < graph.GetLength(0); i++)     // 초기화 과정
            {
                visited[i] = false;
                parents[i] = -1;
            }
            SearchNode(graph, start, visited, parents);
        }

        private static void SearchNode(bool[,] graph,int start, bool[] visited, int[] parents)
        {
            visited[start] = true;
            for (int i = 0; i < graph.GetLength(0); i++) // 전체 정점들을 순회
            {
                if (graph[start,i] && !visited[i]) // 연결되어 있는 정점이며 방문한적 없는 정점인 경우 
                {
                    parents[i] = start;
                    SearchNode(graph, start, visited, parents);
                }
            }
        }

        // BFS : 너비 우선 탐색 (Breath First Search)
        // 그래프의 분기를 만났을 때 모든 분기를 하나 씩 저장하고 저장한 분기를 한 번씩 거치면서 탐색함
        // 한 층 한 층 내려가는 방식
        // Queue로 구현 가능!
        public static void BFS(bool[,] graph,int start,out bool[] visited,out int[] parents)
        {
            visited = new bool[graph.GetLength(0)]; // 1차 배열 크기
            parents = new int[graph.GetLength(0)];

            for (int i = 0; i < graph.GetLength(0); i++)     // 초기화 과정
            {
                visited[i] = false;
                parents[i] = -1;
            }

            Queue<int> bfsQueue = new Queue<int>(); // 큐 사용

            bfsQueue.Enqueue(start);
            while (bfsQueue.Count > 0)
            {
                int next = bfsQueue.Dequeue();
                visited[next] = true;
                for (int i = 0; i < graph.GetLength(0); i++) // 전체 정점들을 순회
                {
                    if (graph[start, i] && !visited[i]) // 연결되어 있는 정점이며 방문한적 없는 정점인 경우 
                    {
                        parents[i] = start;
                        bfsQueue.Enqueue(i);
                    }
                }
            }

        }

    }
}
