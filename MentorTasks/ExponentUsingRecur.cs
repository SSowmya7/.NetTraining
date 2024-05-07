namespace MentorTasks
{
    public  class ExponentUsingRecur
    {
        public static int  PowerCalc(int baseNumber, int exp)
        {
            if (exp > 0)
            {
                return baseNumber * (PowerCalc(baseNumber, (exp - 1)));
        }
            else if (exp < 0)
            {
                return 1;
            }
            return 1;
     }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the base Number");
            int baseNumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Exponent Number");
            int exponent = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"the power of {baseNumber} raised to the {exponent} is");
            Console.WriteLine(PowerCalc(baseNumber, exponent));
           
        }
    }
}
