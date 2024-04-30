using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankingv4
{
    public class TransferTransaction
    {


        private Account _sourceAccount;
        private Account _destinationAccount;

        private decimal _amount;
        private bool _excecuted = false;
        private bool _success = false;
        private bool _reversed = false;
        private WithDrawTransactions _withdrawTransactions;
        private DepositTransactions _depositTransactions;
        public bool Success
        {
            get { return _success; }
        }

        public bool Excecuted { get { return _excecuted; } }
        public bool Reversed { get { return _reversed; } }

        public Account SourceAccount
        {
            get { return _sourceAccount; }
            set { _sourceAccount = value; }

        }

        public TransferTransaction(Account SourceAccount, Account DestinationAccount, decimal amount)
        {
            _sourceAccount = SourceAccount;
            _destinationAccount = DestinationAccount;
            _amount = amount;
            _withdrawTransactions = new WithDrawTransactions(_sourceAccount, _amount);
            _depositTransactions = new DepositTransactions(_destinationAccount, _amount);
        }

        public void Excecute()
        {
            if (_excecuted)
            {
                throw new Exception("Cannot excecute this transaction,it has already excecuted")
                       ;
            }
            _excecuted = true;

            // _success = _sourceAccount.WithDraw(_amount) && _destinationAccount.Deposit(_amount);
            _withdrawTransactions.Excecute();
            _depositTransactions.Excecute();
            _success = _withdrawTransactions.Success && _depositTransactions.Success;

            Print();


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
                //Console.WriteLine("rolled back");
                _sourceAccount.Deposit(_amount);
                _destinationAccount.WithDraw(_amount);
                //   Console.WriteLine(_account.Print());

            }

        }
        public void Print()
        {
            if (_success)
            {

                Console.WriteLine("Transferred amount" + _amount +
                    "transaction successfull");
                Console.WriteLine(_sourceAccount.Print() + "\n");
                Console.WriteLine(_destinationAccount.Print());
            }
            else
            {
                Console.WriteLine("Transaction failed");
            }
            if (_reversed)
            {

                Console.WriteLine("Transaction has been reversed");

            }

        }

    }
}
       