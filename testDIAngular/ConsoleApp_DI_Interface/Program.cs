using System;
using System.Collections;

using Microsoft.Extensions.DependencyInjection;

namespace ConsoleApp_DI_Interface
{
    class Program
    {
        static void Main()
        {
            var services = new ServiceCollection();
            services.AddTransient<IXMLWriter, XMLWriter>();
            services.AddTransient<IXMLWriter, XMLWriter2>();
            services.AddTransient<IJSONWriter, JSONWriter>();
            services.AddTransient<IJSONWriter, JSONWriter2>();
            var provider = services.BuildServiceProvider();

            //***************************************************************************
            //var registeredXMLServices = provider.GetServices<IXMLWriter>();
            //foreach (var svc in registeredXMLServices)
            //{
            //    svc.WriteXML();
            //}
            //***************************************************************************


            //***************************************************************************
            //var myServiceArray = new ServiceDescriptor[services.Count];
            //// Copy the services into an array.
            //services.CopyTo(myServiceArray, 0);
            //IEnumerator myEnumerator = myServiceArray.GetEnumerator();
            //Console.WriteLine("The Implementation Types in the array are");
            //while (myEnumerator.MoveNext())
            //{
            //    var myService1 = (ServiceDescriptor)myEnumerator.Current;
            //    Console.WriteLine(myService1.ImplementationType);
            //}
            //***************************************************************************

            //***************************************************************************
            foreach (var svc in services)
            {
                Console.WriteLine($"Type: {svc.ImplementationType} \n" +
                $"Lifetime: {svc.Lifetime} \n" +
                $"Service Type: {svc.ServiceType}");
            }
            //***************************************************************************

            Console.WriteLine("Dependency Injection Demo (2)");
            Console.WriteLine("Mapping Interfaces to instance classes");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Please, select message format (1):XML // (2):JSON");
            var res = Console.ReadLine();
            if (res == "1")
            {
                var XMLInstance = provider.GetService<IXMLWriter>();
                XMLInstance.WriteXML();
            }
            else
            {
                var JSONInstance = provider.GetService<IJSONWriter>();
                JSONInstance.WriteJSON();
            }

            Console.ReadLine();
        }
    }


    public interface IXMLWriter
    {
        void WriteXML();
    }
    public interface IJSONWriter
    {
        void WriteJSON();
    }


    public class XMLWriter : IXMLWriter
    {
        public void WriteXML()
        {
            Console.WriteLine("<message>Writing in XML Format</message>");
        }
    }
    public class JSONWriter : IJSONWriter
    {
        public void WriteJSON()
        {
            Console.WriteLine("{'message': 'Writing in JSON Format'}");
        }
    }

    public class XMLWriter2 : IXMLWriter
    {
        public void WriteXML()
        {
            Console.WriteLine("<message>Writing in XML Format (2)</message>");
        }
    }
    public class JSONWriter2 : IJSONWriter
    {
        public void WriteJSON()
        {
            Console.WriteLine("{'message': 'Writing in JSON Format (2)'}");
        }
    }
}
