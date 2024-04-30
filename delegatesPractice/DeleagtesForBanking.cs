using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegatesPractice
{
    public class DeleagtesForBanking
    {
        public delegate void AccountHandler(decimal amount);
        public class Account
        {
            private decimal _balance;
            private string _name;
            public Account(string name, decimal balance)
            {
                _name = name;
                _balance = balance;
            }
            public void Deposit(decimal amountToDeposit)
            {
                try
                {
                    if (amountToDeposit > 0)
                    {

                        _balance += amountToDeposit;
                        Console.WriteLine(_name, _balance);

                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            public void WithDraw(decimal amountToWithDraw)
            {
                try
                {
                    if (amountToWithDraw > 0 && amountToWithDraw <= _balance)
                    {
                        _balance -= amountToWithDraw;

                       Console.WriteLine(_name, _balance);
                    }
                    
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                   
                }
            }
            public void Print()
            {
                Console.WriteLine($"Account Holder Name: {_name}\n" +
               $"Account Balance: {_balance}");

            }
        }
        class Program
        {
            static void Main(string[] args)
            {

                Account account = new Account("sowmya", 1000);

                AccountHandler accObj1, accObj2, accObj3;

                accObj1 = new AccountHandler(account.Deposit);
               accObj2 = new AccountHandler(account.WithDraw);


                

                //Multicasting a delegate
                accObj3 = accObj1 + accObj2;

               

                accObj1(200); // single casting

                accObj2(3000); // single casting

                accObj3(300); // multi casting

                Console.ReadKey();
            }
        }
    }
}
