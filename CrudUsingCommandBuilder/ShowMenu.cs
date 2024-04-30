using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CrudUsingCommandBuilder
{
    public class ShowMenu
    {
        static StudentsUtility studentsUtility = new StudentsUtility();
        public enum MenuOption
        {
            Add = 1,
            Update,
            DisplayStudents,
            DisplayStudentsById,
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
        public void Menu()
        {



            MenuOption choice = ReadUserOption();

            while (choice != MenuOption.Exit)
            {
                switch (choice)
                {
                    case MenuOption.Add:

                        studentsUtility.DoAdd();
                        break;
                    case MenuOption.Update:

                        studentsUtility.DoUpdate();
                        break;

                    case MenuOption.DisplayStudents:

                        studentsUtility.DoDisplayAllStudents();
                        break;

                    case MenuOption.DisplayStudentsById:

                        studentsUtility.DoDisplayById();
                        break;
                    case MenuOption.Delete:

                        studentsUtility.DoDelete();
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

