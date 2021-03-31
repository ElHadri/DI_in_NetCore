using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace Minimum_app
{
    // The component in charge of configuring the request pipeline and handling all requests made to the application.
    public class c_Startup
    {
        // Actions to perform when the server is launched.
        // specify how the ASP.NET application will respond to individual HTTP requests in the form of middleware.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("This is a first web app...");
            });
        }
    }
}
