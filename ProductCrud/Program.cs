using System;
using System.Collections;
using System.Collections.Generic;

namespace GenericsPractice
{
   

    class Program

    {

        public enum MenuOption
        {
          AddProduct = 1,
          UpdateProduct,
          DisplayProducts,
          RemoveProduct ,
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
            ProductUtility productUtility = new ProductUtility();
            MenuOption choice = ReadUserOption();


            while (choice != MenuOption.Exit)
            {
                switch (choice)
                {
                    case MenuOption.AddProduct:
                       productUtility.DoAdd();
                        break;

                    case MenuOption.UpdateProduct:
                        productUtility.DoUpdate();
                        break;
                    case MenuOption.DisplayProducts:
                        productUtility.DoDisplay();
                        break;

                    case MenuOption.RemoveProduct:
                        productUtility.DoDelete();
                        break;

                    case MenuOption.Exit:
                        Console.WriteLine("Exiting...");
                        Environment.Exit(0);
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

