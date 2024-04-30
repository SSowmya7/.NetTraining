using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee
{
    public  class EmployeeUtility
    {
        public static EmployeeOperations employeeOperations = new EmployeeOperations();
      
        public void DoAdd()
        {

            Employee obj = new Employee();


            Console.WriteLine("Enter the name of the Employee");
            obj.Name = Console.ReadLine();
            Console.WriteLine("Enter the department of the Employee");
            obj.Department = Console.ReadLine();
            Console.WriteLine("Enter the salary of the Employee");
            obj.Salary = Convert.ToDecimal(Console.ReadLine());

            employeeOperations.AddEmployee(obj);

        }

        public  void DoDisplay()
        {
            ArrayList employees = employeeOperations.DisplayAllEmployees();
            foreach (Employee emp in employees)
            {
                Console.WriteLine("employee Name: " + emp.Name);
                Console.WriteLine("employee Department: " + emp.Department);
                Console.WriteLine("employee Salary: " + emp.Salary);
            }
        }

        public  void DoDelete()
        {
            Console.WriteLine("Enter the id of the Employee to be deleted");
            int id = Convert.ToInt32(Console.ReadLine());
            employeeOperations.DeleteEmployee(id);
        }

        public  void DoUpdate()
        {
            Console.WriteLine("Enter the id of the Employee to updated");
            int id = Convert.ToInt32(Console.ReadLine());


            Employee obj = new Employee();

            Console.WriteLine("Enter the Updated name of the Employee");
            obj.Name = Console.ReadLine();
            Console.WriteLine("Enter the Updated department of the Employee");
            obj.Department = Console.ReadLine();
            Console.WriteLine("Enter the Updated salary of the Employee");
            obj.Salary = Convert.ToDecimal(Console.ReadLine());


            employeeOperations.UpdateEmployee(id, obj);


        }





    }

}
