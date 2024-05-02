namespace MentorTasks
{
    public class NumberToBits
    {
        public static string NumToBits(int number)
        {
            string result = "";
            while (number > 0)
            {
                int remainder = number % 2;
                result = Convert.ToString(remainder) + result;
                number /= 2;
            }
            return result;

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Number to convert into bits");
            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(NumToBits(number));
        }
    }
}
