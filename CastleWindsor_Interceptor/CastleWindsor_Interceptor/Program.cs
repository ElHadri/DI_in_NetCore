using Castle.Windsor;
using System;

namespace CastleWindsor_Interceptor
{
    class Program
    {
        private static IWindsorContainer _container;

        static void Main(string[] args)
        {
            _container = new WindsorContainer();
            _container.Register(new ExampleRegistration());

            var example = _container.Resolve<IExample>();
            try
            {
                example.PrintName("Adil", "El Hadri");
            } 
            catch(Exception ex)
            { }

            try
            {
                example.PrintSomethingElse();
            } 
            catch(Exception ex)
            { }
        }
    }
}

