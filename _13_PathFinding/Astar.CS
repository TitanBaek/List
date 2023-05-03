using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13_PathFinding
{
    public class Astar
    {
		/******************************************************
		 * A* 알고리즘
		 * 
		 * 다익스트라 알고리즘을 확장하여 만든 최단경로 탐색알고리즘
		 * 경로 탐색의 우선순위를 두고 유망한 해부터 우선적으로 탐색
		 * 
		 * f = g + h / 총점수
		 * g = 걸린거리(이동거리?)
		 * h(휴리스틱) = 예상거리
		 * 
		 * F 값이 가장 작은 정점부터 탐색을 해서
		 * 탐색한 정점의 F 값을 구해주는 방식
		 * 
		 * 대각선거리를 이용하여 대각선의 휴리스틱(h)은 14로 두고 
		 * g는 10으로 둬서 계산합시다.
		 ******************************************************/

		/// <summary>
		/// 경로탐색 함수
		/// </summary>
		/// <param name="tileMap">경로를 찾고자 하는 타일맵</param>
		/// <param name="start">시작지점을 나타내는 Position 구조체</param>
		/// <param name="end">종료지점을 나타내는 Position 구조체</param>
		/// <param name="path">출력전용 Path 를 담을 List</param>
		/// <returns></returns>
		/// 

		const int CostStraight = 10;
		const int CostDiagonal = 14;

        static Position[] Direction =
        {
            new Position(  0, +1 ),			// 상
			new Position(  0, -1 ),			// 하
			new Position( -1,  0 ),			// 좌
			new Position( +1,  0 ),			// 우
			new Position( -1, +1 ),		    // 좌상
			new Position( -1, -1 ),		    // 좌하
			new Position( +1, +1 ),		    // 우상
			new Position( +1, -1 ),		    // 우하
		};


        public static bool PathFinding(bool[,] tileMap, Position start,Position end, out List<Position>? path)
		{
			int ySize = tileMap.GetLength(0);
			int xSize = tileMap.GetLength(1);

			bool[,] visited = new bool[ySize, xSize];			// 방문여부를 담을 다차원 배열
			ASNode[,] nodes = new ASNode[ySize, xSize];			// 노드들을 담을 다차원 배열
			PriorityQueue<ASNode,int> nextPointPQ = new PriorityQueue<ASNode,int>();

			// 0. 시작 정점 생성하여 추가하기
			ASNode startNode = new ASNode(start, null, 0, Heuristic(start,end));   // 부모 정점이 없는 아이
																				   // 

			nodes[startNode.pos.y, startNode.pos.x] = startNode;
			nextPointPQ.Enqueue(startNode, startNode.f);

			while(nextPointPQ.Count > 0)
			{
				// 1. 다음으로 탐색할 정점 꺼내기
				ASNode nextNode = nextPointPQ.Dequeue();

				// 2. 방문한 정점은 방문표시하기
				visited[nextNode.pos.y, nextNode.pos.x] = true;

				// 3. 이제 탐색할 정점이 도착지일 경우 도착했다고 판단하여 경로를 반환
				if(nextNode.pos.x == end.x && nextNode.pos.y == end.y) 
				{
					Position? pathPoint = end;
					path = new List<Position>();

					while(pathPoint != null)
					{
						Position pos = pathPoint.GetValueOrDefault();		// Null이 아니면 집어넣고 그게 아니면 Default 값 집어넣음 
						path.Add(pos);
						pathPoint = nodes[pos.y, pos.x].parent;
					}

					path.Reverse(); // 경로는 path에 거꾸로 삽입이 되어있기 때문에 Reverse 메소드를 사용한다.
					return true;
				}

				// 4. Astar 탐색을 진행한다.
				// 방향탐색
				for(int i = 0; i < Direction.Length; i++)
                {
                    int x = nextNode.pos.x + Direction[i].x;
                    int y = nextNode.pos.y + Direction[i].y;


					// 4-1. 탐색하면 안되는 경우는 제외해주자
					
					if( x < 0 || x >= xSize || y < 0 || y >= ySize) // 맵을 벗어났을 경우, x와 y가 0보다 작거나 각 x,y 사이즈 보다 클 때
					{
						continue;
					} else if (tileMap[y,x] == false)// 탐색할 수 없는 정점일 경우
                    {
						continue;
                    } else if (visited[y,x] == true)// 이미 방문한 정점일 경우
					{
						continue;
					}

					// 4-2 점수 계산
					int g = nextNode.g + ((nextNode.pos.x == x || nextNode.pos.y == y) ? CostStraight : CostDiagonal);
					int h = Heuristic(new Position(x, y), end);
					ASNode newNode = new ASNode(new Position(x, y), nextNode.pos, g, h);

					// 4-3 정점의 갱신이 필요한 경우만 새로운 정점으로 할당해줘야함
					if (nodes[y,x] == null || nodes[y,x].f > newNode.f) // 점수가 계산되어 넣어지지 않은 정점이거나 newNode보다 가중치가 더 높은 정점인 경우
					{
						nodes[y,x] = newNode;
						nextPointPQ.Enqueue(newNode, newNode.f);
					}
                }
			}

			path = null;
			return false;
		}


			// 휴리스틱(최상의 경로를 추정하는 순위값 휴리스틱에 의해 경로 탐색의 효율이 결정) 값을 구하는 함수 : 
		private static int Heuristic(Position start, Position end)
		{
			int xSize = Math.Abs(start.x - end.x);		// 가로로 가야하는 횟수
			int ySize = Math.Abs(start.y - end.y);      // 세로로 가야하는 횟수

			// 맨해든 거리 : 가로 세로를 통해 이동하는 거리
			// return CostStraight * (xSize + ySize);

			// 유클리드 거리 : 대각선을 통해 이동하는 거리
			return CostStraight * (int)Math.Sqrt(xSize * xSize + ySize * ySize);
		}

		// 정점을 나타내는 노드 클래스
		private class ASNode
		{
			public Position pos;            // 현재 정점의 좌표값을 담을 구조체 Position
            public Position? parent;         // 이 정점을 탐색한 부모 정점( Nullable )
            public int f;                   // f(x) = g(x) + h(x) : 총거리
			public int g;                   // 현재까지의 거리 즉 지금까지의 경로 가중치
			public int h;                   // 휴리스틱 : 앞으로 목표지점까지 예상되는 거리( 추정 경로 가중치 )
		
			public ASNode(Position pos,Position? parent,int g, int h)
			{
				this.pos = pos;
				this.parent = parent;
				this.g = g;
				this.h = h;
				this.f = g + h;

			}
		}
    }

	// 좌표값을 담을 구조체 Position
    public struct Position
    {
        public int x;
        public int y;

		public Position(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
    }
}

