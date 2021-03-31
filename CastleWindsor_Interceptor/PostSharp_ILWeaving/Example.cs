using PostSharp_ILWeaving;

using System;
using System.Collections.Generic;
using System.Text;

namespace CastleWindsor_Interceptor
{
    public class Example : IExample
    {
        [LoggingWeaverAspect]
        public void PrintName(string FirstName, string LastName)
        {
            // throw new Exception();
            Console.WriteLine($"Name is {FirstName} {LastName}");
        }

        public void PrintSomethingElse()
        {
            Console.WriteLine("Something esle");
        }
    }
}
