using DSA;

Console.WriteLine("========== MODULE 2: Data Structures & Algorithms ==========\n");

// ===== LINKED LIST =====
Console.WriteLine("---------- LINKED LIST ----------");
var list = new SinglyLinkedList();
list.Add(10);
list.Add(20);
list.Add(30);
list.Add(40);
list.Print();

Console.WriteLine($"Search 20: {list.Search(20)}");
Console.WriteLine($"Search 99: {list.Search(99)}");

list.Delete(20);
list.Print();

// ===== LINEAR SEARCH =====
Console.WriteLine("\n---------- LINEAR SEARCH ----------");
int[] unsorted = { 64, 34, 25, 12, 22, 11, 90 };
int idx1 = Searching.LinearSearch(unsorted, 22);
Console.WriteLine($"Array:  {string.Join(", ", unsorted)}");
Console.WriteLine($"Search 22 → index {idx1}");
Console.WriteLine($"Search 99 → index {Searching.LinearSearch(unsorted, 99)}");

// ===== BINARY SEARCH =====
Console.WriteLine("\n---------- BINARY SEARCH ----------");
int[] sorted = { 2, 5, 8, 12, 16, 23, 38, 56, 72, 91 };
Console.WriteLine($"Array:  {string.Join(", ", sorted)}");
Console.WriteLine($"Search 23 → index {Searching.BinarySearch(sorted, 23)}");
Console.WriteLine($"Search 72 → index {Searching.BinarySearch(sorted, 72)}");
Console.WriteLine($"Search 99 → index {Searching.BinarySearch(sorted, 99)}");

// ===== BUBBLE SORT =====
Console.WriteLine("\n---------- BUBBLE SORT O(n²) ----------");
int[] bubbleArr = { 64, 34, 25, 12, 22, 11, 90 };
Console.WriteLine($"Before: {string.Join(", ", bubbleArr)}");
Sorting.BubbleSort(bubbleArr);
Console.WriteLine($"After:  {string.Join(", ", bubbleArr)}");

// ===== MERGE SORT =====
Console.WriteLine("\n---------- MERGE SORT O(n log n) ----------");
int[] mergeArr = { 38, 27, 43, 3, 9, 82, 10 };
Console.WriteLine($"Before: {string.Join(", ", mergeArr)}");
Sorting.MergeSort(mergeArr, 0, mergeArr.Length - 1);
Console.WriteLine($"After:  {string.Join(", ", mergeArr)}");

// ===== QUICK SORT =====
Console.WriteLine("\n---------- QUICK SORT O(n log n) ----------");
int[] quickArr = { 10, 7, 8, 9, 1, 5 };
Console.WriteLine($"Before: {string.Join(", ", quickArr)}");
Sorting.QuickSort(quickArr, 0, quickArr.Length - 1);
Console.WriteLine($"After:  {string.Join(", ", quickArr)}");

Console.WriteLine("\n========== MODULE 2 COMPLETE ==========");
