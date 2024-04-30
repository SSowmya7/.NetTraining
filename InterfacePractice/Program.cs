
namespace InterfacePractice
{
    using System;

    // Interface for an account
    public interface IAccount
    {
        string AccountNumber { get; set; }
        decimal Balance { get; set; }

        void Deposit(decimal amount);
        bool Withdraw(decimal amount);
        void DisplayBalance();
    }

    // Base class for an account
    public abstract class Account : IAccount
    {
        public string AccountNumber { get; set; }
        public decimal Balance { get; set; }

        public abstract void Deposit(decimal amount); 

        public abstract bool Withdraw(decimal amount);

        public void DisplayBalance()
        {
            Console.WriteLine($"Account Number: {AccountNumber}, Balance: {Balance}");
        }
    }

    // Child class for a savings account
    public class Savings : Account
    {
        public decimal InterestRate { get; set; }

        public override void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public override bool Withdraw(decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }
    }

    // Child class for a current account
    public class Current : Account
    {
        public decimal OverdraftLimit { get; set; }

        public override void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public override bool Withdraw(decimal amount)
        {
            if (Balance + OverdraftLimit >= amount)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }
    }

    class Program
    {
        static void Main()
        {
            //// Example usage
            //Savings savingsAccount = new Savings();
            //savingsAccount.AccountNumber = "SAV-001";
            //savingsAccount.Deposit(1000);
            //savingsAccount.DisplayBalance();

            //Current currentAccount = new Current();
            //currentAccount.AccountNumber = "CUR-001";
            //currentAccount.Deposit(500);
            //currentAccount.DisplayBalance();


            IAccount savingsAccount = new Savings();
            savingsAccount.AccountNumber = "SAV-001";
            savingsAccount.Deposit(1000);
            savingsAccount.DisplayBalance();

            IAccount currentAccount = new Current();
            currentAccount.AccountNumber = "CUR-001";
            currentAccount.Deposit(500);
            currentAccount.DisplayBalance();
        }
    }

}
