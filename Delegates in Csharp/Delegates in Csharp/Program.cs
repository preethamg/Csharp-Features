using System;
using System.Collections.Generic;


namespace Delegates_in_Csharp
{
    /*delegates are typesafe function pointers whose return type is 
     same as pointing function along with the parameters */

    public delegate bool IsEmployeePromotable(Employee employee);
    
    class Program
    {    
        static void Main(string[] args)
        {
            List<Employee> employeeList = new List<Employee>();
            employeeList.Add(new Employee { EmployeeName = "Preetham", Age = 23, Salary = 65000 });
            employeeList.Add(new Employee { EmployeeName = "Mahesh", Age = 25, Salary = 45000 });
            employeeList.Add(new Employee { EmployeeName = "Sharath", Age = 26, Salary = 55000 });
            employeeList.Add(new Employee { EmployeeName = "Manohar", Age = 30, Salary = 64000 });

            //Here in the below code we use lamda expression to create and pass the delegate as arguments to method
            DelegatesDemo.PromoteEmployee(employeeList, emp => emp.Age < 24);
            Console.ReadKey();
        }
    }
    
    public class Employee
    {
        public string EmployeeName { get; set; }

        public int Age { get; set; }
        
        public int Salary { get; set; }
    }

    public class DelegatesDemo
    {
        public static void PromoteEmployee(List<Employee> employeeList, IsEmployeePromotable isEmployeePromotable)
        {
            foreach (var employee in employeeList)
            {
                if (isEmployeePromotable(employee))
                {
                    Console.WriteLine(employee.EmployeeName + " Promoted");
                }
            }
        }
    }
}
