using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AccessModifiers
{
    public class customer
    {
        private string m_Name;
        private string m_phone;
        public customer(string name, string phone)
        {
            m_Name = name;
            m_phone = phone;
        }
       public string DisplayDetails()
        {
            return m_Name + m_phone;
        }
    }
}
