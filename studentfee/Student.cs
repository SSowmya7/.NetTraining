using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentfee
{
    public abstract class Student
    {

        // Creating Fields
      /*  private string _name;
        private int _rollNumber;
        private decimal _tuitionFee;
        private decimal _feePaid;

        public Student(string name, int rollNumber, decimal tuitionFee, decimal feePaid)
        {
            _name = name;
            _rollNumber = rollNumber;
            _tuitionFee = tuitionFee;
            _feePaid = feePaid;
        }*/

        public abstract string MakePayment(decimal amount);
        public virtual string CheckBalance(string rno)
        {

            decimal FeeBalance = 500;
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
                    return $"yet to pay";
                }
                //return TuitionFee - FeePaid;
            }
        }
    }

