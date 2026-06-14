namespace DSA
{
    public static class Sorting
    {
        // Bubble Sort - compare adjacent, swap if wrong order
        // Time Complexity: O(n²)
        public static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        // swap
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                    }
                }
            }
        }

        // Merge Sort - divide array, sort each half, merge
        // Time Complexity: O(n log n)
        public static void MergeSort(int[] arr, int left, int right)
        {
            if (left >= right) return;

            int mid = (left + right) / 2;
            MergeSort(arr, left, mid);        // sort left half
            MergeSort(arr, mid + 1, right);   // sort right half
            Merge(arr, left, mid, right);      // merge both halves
        }

        private static void Merge(int[] arr, int left, int mid, int right)
        {
            var leftArr  = arr[left..(mid + 1)];
            var rightArr = arr[(mid + 1)..(right + 1)];

            int i = 0, j = 0, k = left;

            while (i < leftArr.Length && j < rightArr.Length)
                arr[k++] = leftArr[i] <= rightArr[j] ? leftArr[i++] : rightArr[j++];

            while (i < leftArr.Length)  arr[k++] = leftArr[i++];
            while (j < rightArr.Length) arr[k++] = rightArr[j++];
        }

        // Quick Sort - pick pivot, partition around it
        // Time Complexity: O(n log n) average, O(n²) worst
        public static void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pivot = Partition(arr, low, high);
                QuickSort(arr, low, pivot - 1);
                QuickSort(arr, pivot + 1, high);
            }
        }

        private static int Partition(int[] arr, int low, int high)
        {
            int pivot = arr[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (arr[j] <= pivot)
                {
                    i++;
                    (arr[i], arr[j]) = (arr[j], arr[i]);
                }
            }
            (arr[i + 1], arr[high]) = (arr[high], arr[i + 1]);
            return i + 1;
        }
    }
}