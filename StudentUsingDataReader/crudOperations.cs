using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentUsingDataReader
{
    public class crudOperations
    {
        SqlConnection connect = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Students;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        SqlCommand  command;
        SqlDataReader reader;
        List<Student> students = new List<Student>();

        public string Modify(string sqlText)
        {
            try
            {

                connect.Open();
                command = new SqlCommand(sqlText, connect);
                int recs = command.ExecuteNonQuery();
                connect.Close();
                return ($"{recs}  Rows Got Effected");

            }
            catch (SqlException ex)
            {
                return ex.Message;
            }
        }



        public List<Student>  getAllProducts(string sqlText)
        {
            try
            {

                connect.Open();
                command = new SqlCommand(sqlText, connect);
                reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    Student student = new Student
                    {
                        Id = Convert.ToInt32(reader[0]),
                       
                        Name = reader[1]?.ToString() ?? "NoNameEntered",
                        Section = reader[2].ToString()
                    };
                   // Console.WriteLine(student.Name);
                    students.Add(student);
                }
                reader.Close();
                connect.Close();
                return students;
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
                return students;
            }
        }

    }
}
