using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankingv4
{
    public class Bank
    {
        private List<Account> _accounts = new List<Account>();


        public void Addaccount(Account account)
        {
            if (account.Balance >= 0)
            {
                _accounts.Add(account);
            }
           
        }
        public Account Getaccount(String name) {
            foreach(Account account in _accounts)
            {
                if (account.Name == name) return account;
            }

            return null;
        }
        public void ExcecuteTransaction(WithDrawTransactions transaction)
        {
            transaction.Excecute();
        }

        public void ExcecuteTransaction(DepositTransactions transaction)
        {
            transaction.Excecute();
        }
        public void ExcecuteTransaction(TransferTransaction transaction) {
            transaction.Excecute();
        }
    }
}
