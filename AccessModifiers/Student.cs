using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiers
{
    public class Student
    {

        // Creating Fields
        private string _name;
        private int _rollNumber;
        private decimal _tuitionFee;
        private decimal _feePaid;

        public Student(string name, int rollNumber, decimal tuitionFee, decimal feePaid)
        {
            _name = name;
         _rollNumber=rollNumber;
        _tuitionFee=tuitionFee;
        _feePaid = feePaid;
    }
        // Properties
      

        // Methods - Actions

        
        public string PaymentDetails()

        {

            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Name  = {0}{1}", _name, Environment.NewLine);

            sb.AppendFormat("RollNumber  = {0}{1}", _rollNumber, Environment.NewLine);

            sb.AppendFormat("Tuitionfee  = {0}{1}", _tuitionFee, Environment.NewLine);

            sb.AppendFormat("Feepaid  = {0}{1}", _feePaid, Environment.NewLine);

            return sb.ToString();

        }
        // Method to track fee balance
        public string CheckFeeBalance()
        {
            decimal FeeBalance = _feePaid - _tuitionFee;
            if (FeeBalance > 0)
            {
                return ($"{FeeBalance} paid excessively");
                //return TuitionFee - FeePaid;
            }
            else if (FeeBalance == 0)
            {
                return $"no fee due";
                // return FeeBalance;
            }
            else
            {

               // Console.WriteLine($"{TuitionFee - FeePaid} yet to pay");
                 return $"{_tuitionFee - _feePaid} yet to pay";
            }
            //return TuitionFee - FeePaid;
        }

        // Method to make a payment
       
    }
}

