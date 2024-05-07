using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace StudentUsingDataReader
{
    public class SqlOperations
    {


        static crudOperations crudOperations = new crudOperations();
      
       
        public string AddStudent(Student student )
        {
            


            string sqlText = $"INSERT INTO student_table VALUES({student.Id},'{student.Name}','{student.Section})";

            Console.WriteLine(crudOperations.Modify(sqlText));



            return ( $"records added successfully");
            
        }

        public void DisplayAllStudents()
        {


            string sqlText = $"SELECT * FROM student_table";
            List<Student> students = crudOperations.getAllProducts(sqlText);
            foreach (Student student in students)
            {
                Console.WriteLine($"student id : {student.Id}");
                Console.WriteLine($"student id : {student.Name}");
                Console.WriteLine($"student id : {student.Section}");
            }

        }

        public void DisplayById(int id)
        {

            string sqlText = $"SELECT * FROM student_table WHERE ID = {id}";
            List<Student> students = crudOperations.getAllProducts(sqlText);
            foreach (Student student in students)
            {
                Console.WriteLine($"student id : {student.Id}");
                Console.WriteLine($"student id : {student.Name}");
                Console.WriteLine($"student id : {student.Section}");
            }

        }

        public string Update(Student student)
        {

            string sqlText = $"UPDATE student_table SET name = '{student.Name}',Sec = {student.Section} WHERE ID = {student.Id}";
            Console.WriteLine(crudOperations.Modify(sqlText));


            return ("updated successfully");

        }


        public string Delete(int id)
        {

            string sqlText = $"DELETE FROM student_table WHERE ID = {id}";
            Console.WriteLine(crudOperations.Modify(sqlText));



           return "Deleted Successfully";
        }
    }

}
