using System;
using System.Collections.Generic;
using System.Text;

namespace CastleWindsor_Interceptor
{
    public class Example : IExample
    {
        // Method to intercept and try to add log steps using an interceptor.
        public void PrintName(string FirstName, string LastName)
        {
            // throw new Exception();
            Console.WriteLine($"Name is {FirstName} {LastName}");
        }

        // Another method to intercept and try to add log steps using an interceptor.
        public void PrintSomethingElse()
        {
            Console.WriteLine("Something esle");
        }
    }
}
