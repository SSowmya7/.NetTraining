
namespace ArrayMethods
{
    using System;
    public class D1ArrayMethods
    {
        private readonly Array _numbers;

        public D1ArrayMethods(Array numbers)
        {
            _numbers = numbers;
        }

        public void PerformArrayOperations()
        {
            Console.WriteLine();
            // Length property
            Console.WriteLine($"Length: {_numbers.Length}");
            //GetValue method
            Console.WriteLine($"Value at index 4: {_numbers.GetValue(4)}");

            // SetValue method
            _numbers.SetValue(42, 3);
            Console.WriteLine($"Value at index 3 after SetValue: {_numbers.GetValue(3)}");

            // CopyTo method
            int[] copy = new int[25];
            _numbers.CopyTo(copy, 0);
            Console.WriteLine("Copied array:");
            foreach (int num in copy)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            // Clone method
            int[] clone = (int[])_numbers.Clone();
            Console.WriteLine("Cloned array:");
            foreach (int num in clone)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            // Sort method
            Array.Sort(_numbers);
            Console.WriteLine("Sorted array:");
            foreach (int num in _numbers)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            // IndexOf method
            int index = Array.IndexOf(_numbers, 5);
            Console.WriteLine($"Index of 5: {index}");

            // Clear method
            Array.Clear(_numbers, 0, _numbers.Length);
            Console.WriteLine("Array after Clear:");
            foreach (int num in _numbers)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();

            // Reverse method
            Array.Reverse(clone);
            Console.WriteLine("Reversed clone array:");
            foreach (int num in clone)
            {
                Console.Write(num + " ");
            }
        }
    }

    public class D2ArrayMethods
    {
        private readonly Array _numbers;
        public D2ArrayMethods(Array numbers)
        {
            _numbers = numbers;
        }
        public void PerformArrayOperations()
        {
            Console.WriteLine($"Length of 2D array: {_numbers.Length}");

            // GetLength method
            Console.WriteLine($"Number of rows in 2D array: {_numbers.GetLength(0)}");
            Console.WriteLine($"Number of columns in 2D array: {_numbers.GetLength(1)}");

            // GetValue method
            Console.WriteLine($"Value at index [1, 2]: {_numbers.GetValue(1, 2)}");

            // SetValue method
            _numbers.SetValue(10, 1, 1);
            Console.WriteLine($"Value at index [1, 1] after SetValue: {_numbers.GetValue(1, 1)}");

           

            // Clone method
            int[,] clone = (int[,])_numbers.Clone();
            Console.WriteLine("Cloned 2D array:");
            for (int i = 0; i < clone.GetLength(0); i++)
            {
                for (int j = 0; j < clone.GetLength(1); j++)
                {
                    Console.Write(clone[i, j] + " ");
                }
                Console.WriteLine();
            }

           
          
            // Clear method
            Array.Clear(_numbers, 0, _numbers.Length);
            Console.WriteLine("2D array after Clear:");
            for (int i = 0; i < _numbers.GetLength(0); i++)
            {
                for (int j = 0; j < _numbers.GetLength(1); j++)
                {
                    Console.Write(_numbers.GetValue(i, j) + " ");
                }
                Console.WriteLine();
            }

            
        }

    }

    public class JaggedArray
    {
        private readonly Array jaggedArray;

      
        public void PerformOperations()
        {
           
        int[][] jaggedArray = new int[3][];

            jaggedArray[0] = [1, 3, 5, 7, 9];
            jaggedArray[1] = [0, 2, 4, 6];
            jaggedArray[2] = [11, 22];

            int[][] jaggedArray2 =
            [
                [1, 3, 5, 7, 9],
    [0, 2, 4, 6],
    [11, 22]
            ];

           
            jaggedArray2[0][1] = 77;

           
            jaggedArray2[2][1] = 88;

            int[][,] jaggedArray3 =
            [
                new int[,] { {1,3}, {5,7} },
    new int[,] { {0,2}, {4,6}, {8,10} },
    new int[,] { {11,22}, {99,88}, {0,9} }
            ];

            Console.Write("{0}", jaggedArray3[0][1, 0]);
            Console.WriteLine(jaggedArray3.Length);
        }
    }
    public class Program
    {

        static void Main(string[] args)
        {
            int[] numbers = { 3, 1, 4, 1, 5, 9, 2, 6, 5 };
            int[,] numbers2 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            D1ArrayMethods d1arrayMethods = new D1ArrayMethods(numbers);
            D2ArrayMethods d2arrayMethods = new D2ArrayMethods(numbers2);
            d1arrayMethods.PerformArrayOperations();
            d2arrayMethods.PerformArrayOperations();
            JaggedArray jArray = new JaggedArray();

            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
