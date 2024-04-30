using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace banking
{
    public class DepositTransactions
    {

        private Account _account;
        private decimal _amount;
        private bool _excecuted = false;
        private bool _success = true;
        private bool _reversed = false;

        public bool Success
        {
            get { return _success; }
        }

        public bool Excecuted { get { return _excecuted; } }
        public bool Reversed { get { return _reversed; } }

        public DepositTransactions()
        {

        }
        public DepositTransactions(Account account, decimal amount)
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
            _success = _account.Deposit(_amount);
            Print();
           
        }

        public void Rollback()
        {
            if (!_excecuted)
            {
                throw new Exception("transaction has not been excecuted");
            }
            if (_reversed)
            {
                throw new Exception("transaction has been reversed");
            }
            //  rollback 

            if (_excecuted && !_reversed)
            {
                _account.WithDraw(_amount);
                _reversed = true;
            }
           
        }
        public void  Print()
        {
            if (_success)
            {
                Console.WriteLine("Deposited " + _amount +
                    " transaction successfull");
                Console.WriteLine(_account.Print());
               
            }
            if (_reversed)
            {

                Console.WriteLine("Transaction has been reversed");

            }
        }
    }
}
