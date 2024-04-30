+-
    +----------+++++--namespace AccessModifiers
{
    using System.Security.Cryptography;
    using System.Text;


 

   
    internal class Program
    {
        static void Main(string[] args)
        {

            Student student2 = new Student("sowmya", 10, 1000, 500);

          

            Console.WriteLine(student2.PaymentDetails());
            Console.WriteLine(student2.CheckFeeBalance());
            customer c1 = new customer("wendy", "123-456");
            customer c2 = new customer("BOB", "456-123");

            Console.WriteLine(c1.DisplayDetails());
            Console.WriteLine(c2.DisplayDetails());
        }
    }
       
}
