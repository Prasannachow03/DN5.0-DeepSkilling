namespace DSA
{
    public static class Searching
    {
        // Linear Search - checks every element one by one
        // Time Complexity: O(n)
        public static int LinearSearch(int[] arr, int target)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == target)
                    return i; // found at index i
            }
            return -1; // not found
        }

        // Binary Search - only works on SORTED arrays
        // Time Complexity: O(log n)
        public static int BinarySearch(int[] arr, int target)
        {
            int lo = 0, hi = arr.Length - 1;

            while (lo <= hi)
            {
                int mid = (lo + hi) / 2;

                if (arr[mid] == target)
                    return mid;           // found
                else if (arr[mid] < target)
                    lo = mid + 1;         // search right half
                else
                    hi = mid - 1;         // search left half
            }
            return -1; // not found
        }
    }
}