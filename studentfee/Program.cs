namespace studentfee
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //instantiate a utility class
            Utility utility = new Utility();

            // creating different student instances
            Student regular = new Regular();
            Student scholarship = new Scholarship();

            // making fee payments for different categoery students
           Console.WriteLine(utility.FeePayment(regular, 1000));
            Console.WriteLine(utility.FeePayment(scholarship, 500));

        }
    }
}
