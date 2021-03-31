using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Minimum_app
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Runs a web application and block the calling thread until host shutdown.
            c_BuildWebHost(args).Run();
        }

        //create a new web host that uses the Startup class just created.
        public static IWebHost c_BuildWebHost(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args).UseStartup<c_Startup>().Build();
        }
    }
}

