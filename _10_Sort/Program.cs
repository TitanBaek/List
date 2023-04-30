namespace _10_Sort
{
    internal class Program
    {
        /******************************************************
		 * 선형 정렬
		 * 
		 * 1개의 요소를 재위치시키기 위해 전체를 확인하는 정렬
		 * n개의 요소를 재위치시키기 위해 n개를 확인하는 정렬
		 * 시간복잡도 : O(N^2)
		 ******************************************************/

        // <선택정렬>
        // 데이터 중 가장 작은 값부터 하나씩 선택하여 정렬
        // 1. 일단 자료구조 내에서 가장 작은 값을 찾아내서 맨 앞으로 위치시킴
        // 2. 위를 반복함
        public static void SelectionSort(IList<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (list[j] < list[minIndex])
                        minIndex = j;
                }
                Swap(list, i, minIndex);
            }
        }

        // <삽입정렬>
        // 데이터를 하나씩 꺼내어 정렬된 자료 중 적합한 위치에 삽입하여 정렬
        public static void InsertionSort(IList<int> list)
        {
            for (int i = 1; i < list.Count; i++)
            {
                int key = list[i];
                int j;
                for (j = i - 1; j >= 0 && key < list[j]; j--)
                {
                    list[j + 1] = list[j];
                }
                list[j + 1] = key;
            }
        }

        // <버블정렬>
        // 서로 인접한 데이터를 비교하여 정렬
        // 선형정렬중 버블정렬이 가장 많이 쓰인다..
        public static void BubbleSort(IList<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = 1; j < list.Count; j++)
                {
                    if (list[j - 1] > list[j])
                        Swap(list, j - 1, j);
                }
            }
        }


        /******************************************************
		 * 분할정복 정렬
		 * 
		 * 1개의 요소를 재위치시키기 위해 전체의 1/2를 확인하는 정렬
		 * n개의 요소를 재위치시키기 위해 n/2개를 확인하는 정렬
		 * 시간복잡도 : O(NlogN)
		 ******************************************************/

        // <힙정렬>
        // 힙을 이용하여 우선순위가 가장 높은 요소부터 가져와 정렬
        public static void HeapSort(IList<int> list)
        {
            PriorityQueue<int, int> pq = new PriorityQueue<int, int>();

            for (int i = 0; i < list.Count; i++)
            {
                pq.Enqueue(list[i], list[i]);
            }

            for (int i = 0; i < list.Count; i++)
            {
                list[i] = pq.Dequeue();
            }
        }


        // <합병정렬>
        // 데이터를 2분할하여 정렬 후 합병
        // 처음엔 시작 index와 끝 index를 매개변수로 전달 받음

        // 8개 크기의 리스트를 전달 받고
        // 매개변수로 left = 0
        //           right = 7 을 전달 받으면
        public static void MergeSort(IList<int> list, int left, int right)
        {
            if (left == right) return;  // left 와 right 가 같으면 Return

            int mid = (left + right) / 2;       // left 와 right를 더해 나누기 2를 하면 중간값을 얻을 수 있음
            MergeSort(list, left, mid);         // [1] left와 중간 값으로 재귀호출 0 / 3 [2] 0 / 1  [3] 0 / 0
            MergeSort(list, mid + 1, right);    // [4] 2 / 7 
            Merge(list, left, mid, right);
        }

        public static void Merge(IList<int> list, int left, int mid, int right)
        {
            List<int> sortedList = new List<int>();
            int leftIndex = left;
            int rightIndex = mid + 1;

            // 분할 정렬된 List를 병합
            while (leftIndex <= mid && rightIndex <= right)
            {
                if (list[leftIndex] < list[rightIndex])
                    sortedList.Add(list[leftIndex++]);
                else
                    sortedList.Add(list[rightIndex++]);
            }

            if (leftIndex > mid)    // 왼쪽 List가 먼저 소진 됐을 경우
            {
                for (int i = rightIndex; i <= right; i++)
                    sortedList.Add(list[i]);
            }
            else  // 오른쪽 List가 먼저 소진 됐을 경우
            {
                for (int i = leftIndex; i <= mid; i++)
                    sortedList.Add(list[i]);
            }

            // 정렬된 sortedList를 list로 재복사
            for (int i = left; i <= right; i++)
            {
                list[i] = sortedList[i - left];
            }
        }


        // <퀵정렬>
        // 하나의 피벗을 기준으로 작은값과 큰값을 2분할하여 정렬
        public static void QuickSort(IList<int> list, int start, int end)
        {
            if (start >= end) return;

            int pivotIndex = start;
            int leftIndex = pivotIndex + 1;
            int rightIndex = end;

            while (leftIndex <= rightIndex) // 엇갈릴때까지 반복
            {
                // pivot보다 큰 값을 만날때까지
                while (list[leftIndex] <= list[pivotIndex] && leftIndex < end)
                    leftIndex++;
                while (list[rightIndex] >= list[pivotIndex] && rightIndex > start)
                    rightIndex--;

                if (leftIndex < rightIndex)     // 엇갈리지 않았다면
                    Swap(list, leftIndex, rightIndex);
                else    // 엇갈렸다면
                    Swap(list, pivotIndex, rightIndex);
            }

            QuickSort(list, start, rightIndex - 1);
            QuickSort(list, rightIndex + 1, end);
        }


        private static void Swap(IList<int> list, int left, int right)
        {
            int temp = list[left];
            list[left] = list[right];
            list[right] = temp;
        }


        static void Main(string[] args)
        {
            Console.WriteLine(1/2);
        }
    }
}