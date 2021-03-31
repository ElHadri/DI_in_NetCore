using Microsoft.Extensions.DependencyInjection;

using System;
using System.Threading;

namespace ConsoleApp_DI
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Dependency Injection Demo");
            Console.WriteLine("Basic use of the Microsoft.Extensions.DependencyInjection Library");
            Console.WriteLine("---------------------------------------------------------------- - ");
            var services = new ServiceCollection();
            services.AddSingleton<DependencyClass2>();
            services.AddSingleton<DependencyClass1>();

            var provider = services.BuildServiceProvider();
            using (var DC1Instance = provider.GetService<DependencyClass1>())
            {
                // Merely by declaring DC1Instance
                // everything gets launched, but we also call
                // CurrentTime() just to check functionality
                DC1Instance.CurrentTime();
                // Notice also how classes are properly disposed
                // after used.
            }
            using (var DC1Instance = provider.GetService<DependencyClass1>())
            {
                Thread.Sleep(2000);
                DC1Instance.CurrentTime();
            }
            Console.ReadLine();
        }
    }

    public class DependencyClass1 : IDisposable
    {
        static private int _instanceNumber = 0;
        private readonly DependencyClass2 _DC2;

        // ctor
        public DependencyClass1(DependencyClass2 DC2instance)
        {
            ++_instanceNumber;
            _DC2 = DC2instance;
            Console.WriteLine($"Constructor of DependencyClass1 finished :  instance {_instanceNumber}");
        }
        public void CurrentTime()
        {
            string time = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
            Console.WriteLine($"Current time: {time}");
        }
        public void Dispose()
        {
            _DC2.Dispose();
            Console.WriteLine($"DependencyClass1 instance {_instanceNumber} disposed");
        }
    }


    public class DependencyClass2 : IDisposable
    {
        static private int _instanceNumber = 0;

        public DependencyClass2()
        {
            ++_instanceNumber;
            Console.WriteLine($"Constructor of DependencyClass2 finished :  instance {_instanceNumber}");
        }
        public void Dispose()
        {
            Console.WriteLine($"DependencyClass2 instance {_instanceNumber} disposed");
        }
    }


}
