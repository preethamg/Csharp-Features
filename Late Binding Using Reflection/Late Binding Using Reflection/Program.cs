using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Late_Binding_Using_Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Reflection is used to inspect and access assembly's metadata during runtime*/

            Assembly executingAssembly = Assembly.GetExecutingAssembly();
            Type customer = executingAssembly.GetType("Late_Binding_Using_Reflection.Customer");
            var customerInstance = Activator.CreateInstance(customer);
            MethodInfo getFullName = customer.GetMethod("GetFullName");
            string[] parameters = new String[2];
            parameters[0] = "Ganesh";
            parameters[1] = "Preetham";
            string fullName = (string)getFullName.Invoke(customerInstance, parameters);
            Console.WriteLine("FullName = {0}", fullName);
            Console.ReadKey();
        }
    }
    public class Customer
    {
        public string GetFullName(string firstName, string lastName)
        {
            return (firstName + " " + lastName);
        }
    }
}
