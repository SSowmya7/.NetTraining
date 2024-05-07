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
namespace CrudUsingCommandBuilder
{
    public class SqlOperations
    {
        SqlConnection connection = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Students;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        SqlDataAdapter adapter;
        
       
        SqlCommandBuilder commandBuilder;
        DataSet dataSet = new DataSet();

       

        public SqlOperations()
        {
            dataset();
        }


        public DataSet dataset()
        {
            adapter = new SqlDataAdapter("Select * from student_table", connection);
            adapter.Fill(dataSet);
            commandBuilder = new SqlCommandBuilder(adapter);
            return dataSet;
        }
        public string AddStudent(Student student )
        {
            

            DataRow newRow = dataSet.Tables[0].NewRow();
            newRow["Id"] = student.Id;
            newRow["Name"] = $"{student.Name}";
            newRow["Sec"] = $"{student.Section}";
            dataSet.Tables[0].Rows.Add(newRow);

            commandBuilder = new SqlCommandBuilder(adapter);
            adapter.Update(dataSet);

           
            return ( $"records added successfully");
            
        }

        public void DisplayAllStudents()
        {
           

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                Console.WriteLine("Student Id is: {0}", row[0]);
                Console.WriteLine("Student Name is: {0}", row[1]);
                Console.WriteLine("Student Section is: {0}", row[2]);
      
            }

        }
    
        public void DisplayById(int id)
        {
            
            DataRow row = dataSet.Tables[0].Select($"ID = {id}")[0];
           
            Console.WriteLine("Student Id is: {0}", row[0]);
            Console.WriteLine("Student Name is: {0}", row[1]);
            Console.WriteLine("Student Section is: {0}", row[2]);

        }

        public string Update(Student student)
        {
           
            DataRow row = dataSet.Tables[0].Select($"ID = {student.Id}")[0];
           
            row[1] = student.Name;
            row[2] = student.Section;
           
            adapter.Update(dataSet);
           
            return ("updated successfully");

        }


        public string Delete(int id)
        {

            DataRow row = dataSet.Tables[0].Select($"id = {id}")[0];
            row.Delete();
            
            adapter.Update(dataSet);
           
            return "Deleted Successfully";
        }
    }

}
