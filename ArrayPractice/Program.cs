namespace ArrayPractice
{
    public class ArrayMethods(Array numbers)
    {
        Console.WriteLine(numbers);
        // Length property
        Console.WriteLine($"Length: {numbers.Length}");

        // GetValue method
        //Console.WriteLine($"Value at index 4: {numbers.GetValue(4)}");

        //// SetValue method
        //numbers.SetValue(42, 3);
        //Console.WriteLine($"Value at index 3 after SetValue: {numbers[3]}");

        //// CopyTo method
        //int[] copy = new int[25];
        //numbers.CopyTo(copy, 0);
        //Console.WriteLine("Copied array:");
        //foreach (int num in copy)
        //{
        //    Console.Write(num + " ");
        //}
        //Console.WriteLine();

        //// Clone method
        //int[] clone = (int[])numbers.Clone();
        //Console.WriteLine("Cloned array:");
        //foreach (int num in clone)
        //{
        //    Console.Write(num + " ");
        //}
        //Console.WriteLine();

        //// Sort method
        //Array.Sort(numbers);
        //Console.WriteLine("Sorted array:");
        //foreach (int num in numbers)
        //{
        //    Console.Write(num + " ");
        //}
        //Console.WriteLine();

        //// IndexOf method
        //int index = Array.IndexOf(numbers, 5);
        //Console.WriteLine($"Index of 5: {index}");

        //// Clear method
        //Array.Clear(numbers, 0, numbers.Length);
        //Console.WriteLine("Array after Clear:");
        //foreach (int num in numbers)
        //{
        //    Console.Write(num + " ");
        //}
        //Console.WriteLine();

        //// Reverse method
        //Array.Reverse(clone);
        //Console.WriteLine("Reversed clone array:");
        //foreach (int num in clone)
        //{
        //    Console.Write(num + " ");
        //}
    }

    public class Program
    {
      
       
        static void Main(string[] args)
        {
            // Creating a one-dimensional array
            int[] numbers = { 3, 1, 4, 1, 5, 9, 2, 6, 5 };
            ArrayPractice(numbers);
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
