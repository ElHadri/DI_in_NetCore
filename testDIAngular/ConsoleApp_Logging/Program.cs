using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ConsoleApp_Logging
{
    class Program
    {
        static void Main()
        {
            // Enabling logging in the ServiceCollection via AddLogging()
            var services = new ServiceCollection().AddSingleton<IXMLWriter, XMLWriter>()
                                                  .AddLogging(loggingBuilder =>
                                                  {
                                                      loggingBuilder.AddConsole();
                                                      loggingBuilder.AddDebug();
                                                      //loggingBuilder.AddFilter<ConsoleLoggerProvider>("LoggingSample",LogLevel.Error);
                                                  });

            var serviceProvider = services.BuildServiceProvider();

            // Create a logger class from ILoggerFactory
            // and print an initial set of messages.
            var iLoggerFactory = serviceProvider.GetService<ILoggerFactory>();
            var logger = iLoggerFactory.CreateLogger<Program>();

            logger.LogCritical("Critical format message from Program");
            logger.LogDebug("Debug format message from Program");
            logger.LogError("Error format message from Program");
            logger.LogInformation("Information format message from Program");
            logger.LogTrace("Trace format message from Program");
            logger.LogWarning("Warning format message from Program");


            //Instantiation of XMLInstance
            var XMLInstance = serviceProvider.GetService<IXMLWriter>();
            XMLInstance.WriteXML();
            XMLInstance.WriteXMLWithSeverityLevel();

            logger.LogDebug("Process finished!");

            // Test the register of AddLoggin()
            //foreach (var svc in services)
            //{
            //Console.WriteLine($"Type: {svc.ImplementationType} \n" +
            //$"Lifetime: {svc.Lifetime} \n" +
            //$"Service Type: {svc.ServiceType}");
            //}
        }
    }

    public interface IXMLWriter
    {
        void WriteXML();
        void WriteXMLWithSeverityLevel();
    }

    public class XMLWriter : IXMLWriter
    {
        private readonly ILogger<XMLWriter> _logger;

        public XMLWriter(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<XMLWriter>();
        }

        public void WriteXML()
        {
            _logger.LogDebug("<msg> First Message (LogDebug / SeverityLevel: Information) </ msg > ");
        }

        public void WriteXMLWithSeverityLevel()
        {
            _logger.LogDebug("<msg> Second Message (LogDebug / SeverityLevel: Information </ msg > ");
        }
    }

}
