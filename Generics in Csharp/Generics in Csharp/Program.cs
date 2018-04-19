using System;


namespace Generics_in_Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            GenericsClass genericsClass = new GenericsClass();
            if (genericsClass.AreEqual<string>("Programming", "Coding")) {
                Console.WriteLine("Both are equal"); 
            }
            else
            {
                Console.WriteLine("Both are not equal");
            }

            if (genericsClass.AreEqual<int>(5,5))
            {
                Console.WriteLine("Both are equal");
            }
            else
            {
                Console.WriteLine("Both are not equal");
            }

            Console.ReadKey();
        }
    }
    public class GenericsClass
    {
        /*Generics helps to decouple code from datatypes 
         Here in the below example arequeal method compares two parameters of 
         multiple types*/

        public bool AreEqual<T>(T param1, T param2)
        {
            if (param1.Equals(param2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
