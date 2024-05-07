using System.Data;

namespace CrudUsingCommandBuilder
{
    public class Program
    {

        static void Main(string[] args)
        {
            ShowMenu showMenu = new ShowMenu();
          
            showMenu.Menu();

            //DataAdapterPractice  dap = new DataAdapterPractice();
            //DataSet data = dap.GetData();
            //foreach (DataRow row in data.Tables[0].Rows)
            //{
            //    Console.WriteLine($" Id : {row[0].ToString()}, Name : {row[1].ToString()}, Section: {row[2].ToString()}");
             


            //}

            Console.ReadLine();
        }
    }
}
