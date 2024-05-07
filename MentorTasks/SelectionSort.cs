namespace MentorTasks
{
    public class SelectionSortExample
    {
        public static void SelectionSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[minIndex])
                    {
                        minIndex = j;
                    }
                }

                
                int temp = arr[minIndex];
                arr[minIndex] = arr[i];
                arr[i] = temp;
            }

        }
        public static void PrintArray(int[] arr)
        {
            foreach (int i in arr)
            {
                Console.WriteLine(i + " ");
            }
            Console.WriteLine();
        }
        public static void Main(string[] args)
        {
            int[] arr = { 15, 12, 37, 24, 56, 46, 78, 38, 95 };
            Console.WriteLine("Original Array");
            PrintArray(arr);
            SelectionSort(arr);
            Console.WriteLine("Sorted Array");
            PrintArray(arr);
        }

    }
}
