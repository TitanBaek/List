using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_Searching
{
    public class Graph
    {
        /******************************************************
        * 그래프 (Graph) : 경로탐색 / 길찾기 / Map
        * 
        * 정점의 모음과 이 정점을 잇는 간선의 모음의 결합
        * 한 노드에서 출발하여 다시 자기 자신의 노드로 돌아오는 순환구조를 가짐
        * 간선의 방향성에 따라 단방향 그래프, 양방향 그래프가 있음
        * 간선의 가중치에 따라   연결 그래프, 가중치 그래프가 있음
        ******************************************************/
        // 트리는 그래프와 비슷하지만.. 순환구조가 아님
        // 순환구조 = 한번 거쳐온 길이 아닌 다른 길이 있어야 ..

        // <인접행렬 그래프>
        // 그래프 내의 각 정점의 인접 관계를 나타내는 행렬
        // 2차원 배열을 [출발정점, 도착정점] 으로 표현
        // 장점 : 인접여부 접근이 빠름
        // 단점 : 메모리 사용량이 많음

        // 예시 - 양방향 연결 그래프
        // 그래프는 간선(edges)의 개수가 정해져있지 않다
        // 그래프는 자가 회신이 가능하다

        // 인접 행렬 그래프
        // 그래프 내의 각 정점의 인접 관계를 나타내는 행렬이다
        // 2차원 배열을 [출발정점,도착정점] 으로 표현한다.
        // 장점 : 인접여부 접근이 빠르다.                                                                     ( 시간복잡도 : O(1) )
        // 단점 : 하나의 간선에 대한 정보를 저장하기 위해서 모든 간선의 정보 자리를 확보해야함, 메모리 사용량이 많다( 공간복잡도 : O(N^2)
        //       
        // 시간복잡도 O(1) , 공간복잡도 O(N^2)
        // 우선시 되긴 함

        static bool[,] matrixGraph1 = new bool[5, 5]
        {
            // '0에서 0은 못가고 1,2,3,4 는 갈 수 있다' 란 뜻
            { false, true, true, true, true },
            { true, false, true, false, true },
            { true, true, false, false, false },
            { true, false, false, false, true },
            { true, true, false, true, false }
        };
         
        // 인접 행렬 가중치 그래프
        const int INF = int.MaxValue;
        static int[,] matrixGraph2 = new int[5, 5]
        {
            // -1 값은 단절되어 있다는걸 뜻 함
            { 0, 132, 16, INF, INF },
            { 12, 132, 16, INF, INF },
            { 0, 132, 16, INF, INF },
            { 0, 132, 16, INF, INF },
            { 0, 132, 16, INF, INF }
        };

        public static void Test()
        {
            if (matrixGraph1[0, 3])
                Console.WriteLine("가요");
            else 
                Console.WriteLine("못가요");
        }

        // 인접 리스트 그래프
        // 그래프 내의 각 정점의 인접 관계를 표현하는 리스트
        // 인접한 간선만을 리스트에 추가하여 관리
        // 장점 : 메모리 사용량이 적다
        // 단점 : 인접여부를 확인하기 위해 리스트  탐색이 필요하다.
        // 시간복잡도 O(N), 공간복잡도 O(N)

        List<List<int>> listGraph; // 이것이 바로 연결 그래프
        List<List<(int, int)>> listGraph2; // 가중치 그래프

        public void CreateGraph()
        {
            listGraph = new List<List<int>>();
            for (int i = 0; i < listGraph.Count; i++)
            {
                listGraph.Add(new List<int>());             // 각 노드들 생성
            }
            listGraph[0].Add(1);
            listGraph[1].Add(0);
            listGraph[1].Add(3);


        }

    }
}
