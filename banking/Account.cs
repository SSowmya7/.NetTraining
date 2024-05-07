using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace banking
{
    public class Account
    {
        private decimal _balance;
        private string _name;
        public Account(string name , decimal balance) { 
            _name = name;
            _balance = balance;
        }
        public bool Deposit(decimal amountToDeposit)
        {
            try
            {
                if (amountToDeposit > 0)
                {

                    _balance += amountToDeposit;

                    return true;
                }
                return false;
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public bool WithDraw(decimal amountToWithDraw)
        {
            try
            {
                if (amountToWithDraw > 0 && amountToWithDraw <= _balance)
                {
                    _balance -= amountToWithDraw;
                  
                    return true;
                }
                return false;
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);

                return false;
            }
        }
        public string Print()
        {
            return $"Account Holder Name: {_name}\n" +
           $"Account Balance: {_balance}"; 
           
        }
    }
}


