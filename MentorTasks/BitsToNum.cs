namespace MentorTasks
{
    public class BitsToNum
    {
        public static int BitsToNumber(string bits)
        {
            int number = 0;
            int limit = bits.Length -1;
            for (int i = limit; i >= 0; i--)
            {
                if (bits[i] != '0')
                {
                    number += (int)Math.Pow(2, (limit-i));
                   
                }
            }
            return number;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the bits string");
            string bits = Console.ReadLine();
            Console.WriteLine(BitsToNumber(bits));
        }

    }
}
