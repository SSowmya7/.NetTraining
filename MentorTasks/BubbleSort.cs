namespace MentorTasks
{
    public class BubbleSortExample
    {
        public static void BubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n-i-1; j++) 
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j+1];
                        arr[j+1] = temp;
                      //  Console.WriteLine(arr[j]);
                        //Console.WriteLine(arr[j+1]);

                    }

                }
            }
        }
        public static void PrintArray(int[] arr)
        {
            foreach (int i in arr)
            {
                Console.WriteLine(i +" ");
            }
            Console.WriteLine();
        }
        public static void Main(string[] args)
        {
            int[] arr = { 15, 12, 37, 24, 56, 46, 78, 38, 95 };
            Console.WriteLine("Original Array");
            PrintArray(arr);
            BubbleSort(arr);
            Console.WriteLine("Sorted Array");
            PrintArray(arr);
        }

    }
}
