using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentfee
{
    public class Utility
    {
        public string FeePayment(Student student,decimal amount)
        {
          return   student.MakePayment(amount);
        }
    }
}
