using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace SqlPractice
{
    public class SqlOperations
    {
        SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Students;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        SqlCommand cmd;
        SqlDataReader reader;

        public string AddStudent(Student student )
        {
           
            connection.Open();

            string sqltext = $"INSERT INTO student_table (Id, Name, Sec) VALUES ({student.Id}, '{student.Name}', '{student.Section}')";
           
            cmd = new SqlCommand(sqltext, connection);
           

            int recs = cmd.ExecuteNonQuery();
            connection.Close();
            
            return ( $"{recs} records added successfully");
           

           
        }

        public void DisplayAllStudents()
        {

            string sqltext = " select * From student_table";
            connection.Open();
            cmd = new SqlCommand(sqltext, connection);
            cmd.ExecuteNonQuery();
            reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                Console.WriteLine("Student Id is:" + reader[0].ToString());
                Console.WriteLine("Student Name is:" + reader[1].ToString());
                Console.WriteLine("Student sec is:" + reader[2].ToString());
                
            }

            connection.Close();
            reader.Close();
            

        }
    
        public void DisplayById(int id)
        {
            string sqltext = $" select * From student_table where id= {id}";

            connection.Open();
            cmd = new SqlCommand(sqltext, connection);
            cmd.ExecuteNonQuery();
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine("Student Id is:" + reader[0].ToString());
                Console.WriteLine("Student Name is:" + reader[1].ToString());
                Console.WriteLine("Student sec is:" + reader[2].ToString());

            }

            connection.Close();
            reader.Close();
            
        }

        public string Update(Student student)
        {
            string sqltext = $" update student_table SET Name = '{student.Name}', Sec = '{student.Section}' where id= {student.Id}";
           
            connection.Open();
            cmd = new SqlCommand(sqltext, connection);
            cmd.ExecuteNonQuery();
            connection.Close();
            return ("updated successfully");

        }


        public string Delete(int id)
        {
            string sqltext = $" DELETE FROM student_table where id= {id}";

            connection.Open();
            cmd = new SqlCommand(sqltext, connection);
            cmd.ExecuteNonQuery();
            reader = cmd.ExecuteReader();
            connection.Close();
            reader.Close();
           
            return "Deleted Successfully";
        }
    }

}
