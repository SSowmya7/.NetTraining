using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlPractice
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Section { get; set; }
       

        public Student() { }
        public Student(int id, string name, string section)
        {
            Id = id;
            Name = name;
            Section = section;
         
        }

    }
}
