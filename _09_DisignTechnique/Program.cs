namespace _09_DisignTechnique
{
    internal class Program
    {
        /******************************************************
		 * 알고리즘 설계기법 (Algorithm Design Technique)
		 * 
		 * 어떤 문제를 해결하는 과정에서 해당 문제의 답을 효과적으로 찾아가기 위한 전략과 접근 방식
		 * 문제를 풀 때 어떤 알고리즘 설계 기법을 쓰는지에 따라 효율성이 막대하게 차이
		 * 문제의 성질과 조건에 따라 알맞은 알고리즘 설계기법을 선택하여 사용
		 ******************************************************/


        public enum Place { left , Middle , right }

        static public void Hanoi()
        {
        }

        static public void Move(int count,int start,int end)
        {
            if(count == 1)
            {
                // 그냥이동
                int ring = stick[start].Pop();
                stick[end].Push(ring);
                Console.WriteLine($"{(Place)start} 스틱에서 {(Place)end} 스틱으로 {ring}이 이동");
                return;
            }
            int other = (3 - start - end);

            Move(count - 1, start, other);
            Move(1, start, end);
            Move(count - 1, other, end);
        }

        public static Stack<int>[] stick; 

        static void Main(string[] args)
        {
            /*
            int ringCount = 5;
            stick = new Stack<int>[3];
            for(int i = 0; i < stick.Length; i++)
            {
                stick[i] = new Stack<int>(); 
            }

            for (int i = ringCount; i > 0; --i){
                stick[0].Push(i);
            }

            Move(ringCount, 0, 2);
            Console.WriteLine();
            Console.WriteLine();
            */

            Backtracking backtracking = new Backtracking();
            bool[,] board = new bool[6,6];
            backtracking.NQueen(board);

        }
    }
}