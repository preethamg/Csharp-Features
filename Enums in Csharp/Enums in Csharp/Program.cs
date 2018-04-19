using System;
using System.Collections.Generic;


namespace Enums_in_Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> empList = new List<Employee>();
            empList.Add(new Employee { Name = "Ganesh", Age = 23, Salary = 65000, Gender = Gender.Male });
            empList.Add(new Employee { Name = "Anusha", Age = 24, Salary = 50000, Gender = Gender.Female });
            empList.Add(new Employee { Name = "Bane", Age = 25, Salary = 45000, Gender = Gender.Undefined });

            foreach (var employee in empList)
            {
                Console.WriteLine("EmployeeName={0}, Gender={1}, Salary={2}, Age={3}",
                    employee.Name, employee.Gender, employee.Salary, employee.Age);
                Console.WriteLine();
            }

            //This Method Gives the Values associated with each enum
            int[] enumValue =(int[])Enum.GetValues(typeof(Gender));
            foreach (var enumVal in enumValue)
            {
                Console.WriteLine(enumVal);
            }

            Console.WriteLine();


            //This Method Gives the Names associated with each enum
            string[] enumnames = (string[])Enum.GetNames(typeof(Gender));
            foreach (var enumName in enumnames)
            {
                Console.WriteLine(enumName);
            }

            Console.ReadKey();
        }
    }

    /*Enums are strongly typed constants which can be used in many 
     situatios in code which improves code readibility and maintainability.
     Enums maps the values internally to int datatype starting from 0*/

    public enum Gender
    {
        Male,
        Female,
        Undefined
    }

    public class Employee
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public int Salary { get; set; }

        public Gender Gender { get; set; }
    }

}
