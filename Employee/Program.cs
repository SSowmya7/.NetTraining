using System.Collections;

namespace Employee
{
    public class Program
    {
       // static EmployeeOperations employeeOperations= new EmployeeOperations();
        static EmployeeUtility employeeUtility= new EmployeeUtility();
        public enum MenuOption
        {
            Add = 1,
            Update,
            DisplayEmployees,
            Delete,
            Exit
        }
        public static MenuOption ReadUserOption()
        {
           foreach (MenuOption option in Enum.GetValues(typeof(MenuOption)))
           {

                    Console.WriteLine($"{(int)option}. {option}");
               
            }
            Console.Write("Enter your choice: ");
            int options = Convert.ToInt32(Console.ReadLine());

            return (MenuOption)options;


        }
       

      
       

       
        static void Main(string[] args)
        {
          
            MenuOption choice = ReadUserOption();

            while(choice != MenuOption.Exit) {
                 switch (choice)
                {
                    case MenuOption.Add:

                        employeeUtility.DoAdd();
                        break;
                     case MenuOption.Update:
                        
                       employeeUtility.DoUpdate();
                      
                        
                        break;
                    case MenuOption.DisplayEmployees:
                        employeeUtility.DoDisplay();
                        break;
                    case MenuOption.Delete:
                        employeeUtility.DoDelete();
                        break;
                    case MenuOption.Exit:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;

                        
                }
                choice = ReadUserOption();
            }
        }
    }
}
