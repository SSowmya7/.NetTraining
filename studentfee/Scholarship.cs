using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentfee
{
    public class Scholarship : Student
    {
        public override string MakePayment(decimal amount)
        {
            return " scholarship credited";
        }
    }
}
