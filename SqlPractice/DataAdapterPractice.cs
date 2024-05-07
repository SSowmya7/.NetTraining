using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlPractice
{
    public class DataAdapterPractice
    {

        SqlConnection cn = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Students;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        DataSet ds = new DataSet();
        SqlDataAdapter da;

        public DataSet GetData()
        {
          //  da = new SqlDataAdapter("select * from student_table",cn);     
           // da.Fill(ds);
           // return ds;


            da = new SqlDataAdapter("Select * from student_table", cn);// open - operation -- close
            da.Fill(ds);
            //cn.Close();
            return ds;
        }

    }
}
