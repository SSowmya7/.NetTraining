using System.Security.Principal;

namespace bankingv4
{
    public class Program
    {
       
       

        public enum MenuOption
        {
            AddNewAccount = 1,
            Deposit ,
            Withdraw,
            Transfer,
            Print,
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

        public static void DoAddNewAccount(Bank bank)
        {
            Console.WriteLine("enter the name of account holder");
            string name = Console.ReadLine();
            Console.WriteLine("enter the starting balance");
            decimal balance = Convert.ToDecimal(Console.ReadLine());
            if (balance < 0)
            {
                Console.WriteLine(" Starting balance must be greater than zero "); return;
            }
            
                bank.Addaccount(new Account(name, balance));
            
        }
        public static Account FindAccount(Bank fromBank)
        {
            Console.WriteLine("Enter account name:");
            String name = Console.ReadLine();
            Account result = fromBank.Getaccount(name);
            if (result == null)
            {
                Console.WriteLine($"No account found with name {name}");
            }
            return result;
        }
        public static void DoDeposit(Bank toBank)
        {
            Account toAccount = FindAccount(toBank);
            if(toAccount == null) { return; }
            Console.Write("Enter amount to deposit: ");
            decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
            if (depositAmount < 0) { Console.WriteLine("invalid amount");return; };
            DepositTransactions depositTransactions = new DepositTransactions(toAccount, depositAmount);
          
            toBank.ExcecuteTransaction(depositTransactions);

        }

      

        public static void DoWithDraw(Bank fromBank)
        {
            Account fromAccount = FindAccount(fromBank);
            if (fromAccount == null) { return; }
            Console.Write("Enter amount to withdraw: ");
            decimal withdrawAmount = Convert.ToDecimal(Console.ReadLine());
            if (withdrawAmount < 0) { Console.WriteLine("invalid amount");return; };
            WithDrawTransactions withDrawTransactions = new WithDrawTransactions(fromAccount, withdrawAmount);
           
           fromBank.ExcecuteTransaction(withDrawTransactions);





        }
        public static void DoTransfer(Bank inbank)
        {
            Account toAccount = FindAccount(inbank);
            Account fromAccount = FindAccount(inbank);

            if (toAccount == null || fromAccount == null) { return; }
            Console.Write("Enter amount to transfer: ");
            decimal transferAmount = Convert.ToDecimal(Console.ReadLine());
            if (transferAmount < 0) { Console.WriteLine("invalid amount"); return; };
            TransferTransaction transferTransactions = new TransferTransaction(fromAccount,toAccount , transferAmount);
           
            inbank.ExcecuteTransaction(transferTransactions);

        }
       
        public static void DoPrint(Bank bank)
        {
           Account accountdetails  = FindAccount(bank);
            if(accountdetails == null) { return; }
            Console.WriteLine("Name = " + accountdetails.Name+" " + "balance = " + accountdetails.Balance);
        }
        static void Main(string[] args)
        {
            Bank bank = new Bank();

            MenuOption choice = ReadUserOption();


            while (choice != MenuOption.Exit)
            {


                switch (choice)
                {
                    case MenuOption.AddNewAccount:
                        DoAddNewAccount(bank);
                        break;

                    case MenuOption.Deposit:
                        DoDeposit(bank);

                        break;
                    case MenuOption.Withdraw:
                        DoWithDraw(bank);
                        break;
                    case MenuOption.Transfer:
                        DoTransfer(bank);
                        break;
                    case MenuOption.Print:
                        DoPrint(bank);
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



           
        }

    }
}
