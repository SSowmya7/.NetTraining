using Microsoft.VisualBasic;

namespace banking
{
    public class Program
    {
       public static Account savings = new Account("sowmya", 1000);
       public static Account destination = new Account("asmin", 2000);
       
        public enum MenuOption
        {
            Deposit = 1,
            Withdraw ,
            Transfer,
            Print , 
            Exit 
        }

        public static MenuOption ReadUserOption()
        {
            
         
            foreach (MenuOption option in Enum.GetValues(typeof(MenuOption)))
            {
               
                Console.WriteLine($"{(int)option}. {option}");
              
            }
            Console.Write("Enter your choice: ");
            int options = Convert.ToInt32(Console.ReadLine()); 

                return (MenuOption)options;
        }
        public static void DoDeposit()
        {
            Console.Write("Enter amount to deposit: ");
            decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
            DepositTransactions depositTransactions = new DepositTransactions(savings, depositAmount);
            depositTransactions.Excecute();
           
        }
           
        public static  void DoWithDraw()
        {
            Console.Write("Enter amount to withdraw: ");
            decimal withdrawAmount = Convert.ToDecimal(Console.ReadLine());
           WithDrawTransactions withDrawTransactions = new WithDrawTransactions(savings, withdrawAmount);
           withDrawTransactions.Excecute(); 



          
           
        }
        public static void DoTransfer()
        {
            Console.Write("Enter amount to transfer: ");
            decimal transferAmount = Convert.ToDecimal(Console.ReadLine());
            TransferTransaction transferTransactions = new TransferTransaction(savings,destination, transferAmount);
            transferTransactions.Excecute();

        }
        public static void DoPrint()
        {
           Console.WriteLine(savings.Print());
        }
        static void Main(string[] args)
        {
           

            MenuOption choice = ReadUserOption();

           
            while (choice != MenuOption.Exit) 
            {
              
               
                switch (choice)
                {
                    case MenuOption.Deposit:
                        DoDeposit();
                        
                        break;
                    case MenuOption.Withdraw:
                        DoWithDraw();
                        break;
                    case MenuOption.Transfer:
                        DoTransfer();
                        break;
                    case MenuOption.Print:
                        DoPrint();
                        break;
                    case MenuOption.Exit:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                choice = ReadUserOption();

               

                Console.WriteLine();
        } 
           
          
            
           // WithDrawTransactions sowmya = new WithDrawTransactions(savings, 500);
           // DoWithDraw();
           // sowmya.Excecute();
            
            
            
           // sowmya.Rollback();
           // sowmya.Print();

           // DepositTransactions mandy = new DepositTransactions(destination, 1500);
           //mandy.Excecute();
           // mandy.Rollback();
           // mandy.Print();

           // TransferTransaction accountTransfer = new TransferTransaction(savings, destination, 500);
           // accountTransfer.Excecute();
           // accountTransfer.Rollback();
           // accountTransfer.Print();
        }

    }
}
