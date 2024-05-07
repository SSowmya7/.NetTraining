using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankingv4
{
    public class WithDrawTransactions
    {
        private Account _account;
        private decimal _amount;
        private bool _excecuted = false;
        private bool _success = false;
        private bool _reversed = false;

        public bool Success
        {
            get { return _success; }
        }

        public bool Excecuted { get { return _excecuted; } }
        public bool Reversed { get { return _reversed; } }


        public WithDrawTransactions(Account account, decimal amount)
        {
            _account = account;
            _amount = amount;
        }
        public void Excecute()
        {
            if (_excecuted)
            {
                throw new Exception("Cannot excecute this transaction,it has already excecuted")
                       ;
            }
            _excecuted = true;
            _success = _account.WithDraw(_amount);
            Print();
            // return _excecuted ;
        }

        public void Rollback()
        {
            if (!_excecuted)
            {
                Console.WriteLine("not excecuted");
                throw new Exception("transaction has not been excecuted");
            }
            if (_reversed)
            {
                Console.WriteLine("reversed");
                throw new Exception("transaction has been reversed");
            }
            _reversed = true;
            // need to do rollback 
            if (!_excecuted && _reversed)
            {
                Console.WriteLine("rolled back");
                _account.Deposit(_amount);
                //   Console.WriteLine(_account.Print());

            }
            //return _reversed;
        }
        public void Print()
        {
            if (_success)
            {

                Console.WriteLine("Withdrawn amount" + _amount +
                    "transaction successfull");
                Console.WriteLine(_account.Print());
            }
            else
            {
                Console.WriteLine("withdrawl failed");
            }
            if (_reversed)
            {

                Console.WriteLine("Transaction has been reversed");

            }
            // return _success;
        }
        //public static  void Main(string[] args)
        //{

        //}
    }
}
