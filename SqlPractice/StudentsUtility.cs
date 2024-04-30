using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlPractice
{
    public class StudentsUtility
    {
        public static SqlOperations SqlOperations =  new SqlOperations();

        public void DoAdd()
        {

            Student obj = new Student();

            Console.WriteLine("Enter the Id");
            obj.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the name of the Student");
            obj.Name = Console.ReadLine();
            Console.WriteLine("Enter the section of the Student");
            obj.Section = Console.ReadLine();


            Console.WriteLine(SqlOperations.AddStudent(obj));

        }

        public void DoDisplayAllStudents()
        {
            SqlOperations.DisplayAllStudents();
        }

      public void DoDisplayById()
        {
            Console.WriteLine("Enter the Id");
            int id = Convert.ToInt32(Console.ReadLine());   
            SqlOperations.DisplayById(id);
        }

        public void DoUpdate()
        {
            Student obj = new Student();

            Console.WriteLine("Enter the id of the student to be updated");
            obj.Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the name of the Student");
            obj.Name = Console.ReadLine();
            Console.WriteLine("Enter the section of the Student");
            obj.Section = Console.ReadLine();

            Console.WriteLine(SqlOperations.Update(obj));
        }
        public void DoDelete()
        {
            Console.WriteLine("Enter the id of the student to be updated");
             int Id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(SqlOperations.Delete(Id));
        }
    }
}
