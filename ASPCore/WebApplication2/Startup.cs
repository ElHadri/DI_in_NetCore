using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using System;
using System.Diagnostics;

using WebApplication2.Helpers;
using WebApplication2.Interceptors.Filters;
using WebApplication2.Interfaces;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public static IServiceCollection _services { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // The Host inside the Main executes this method.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();
            services.AddTransient<DateTimeHelpers>();
            services.AddSingleton<SomeGlobalFilter>();

            // It is not mandatory to make it transient though, it depends on your scenario
            services.AddTransient<SomeFilter>();

            // Add framework services.
            services.AddMvc(mvc => mvc.Filters.AddService(typeof(SomeGlobalFilter)));


            //services.AddTransient<IExampleTransient, Example>();
            //services.AddScoped<IExampleScoped, Example>(); // We can customize the scope
            //services.AddSingleton<IExampleSingleton, Example>();

            services.AddTransient<IExampleTransient, ExampleTransient>();
            services.AddScoped<IExampleScoped, ExampleScoped>(); // We can customize the scope
            services.AddSingleton<IExampleSingleton, ExampleSingleton>();

            //********************************************************************************
            // To create Instance life style
            services.AddSingleton<IExampleSingletonInstance>(sp => new Example(Guid.Empty));
            //********************************************************************************

            // The class ExampleService is resolved for itself.That means, whenever we need 
            // ExampleService anywhere in the app, to be injected, it will automatically assign an
            // object of that class with all its properties
            services.AddTransient<ExampleService, ExampleService>();

            _services = services;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //  "IApplicationBuilder" interface helps us register the Middleware using the "app.Use"
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The exception is something which may occur anytime, anywhere, within the app.So, 
                // we need to register it first before everything else, so that we can easily capture the exceptions
                app.UseExceptionHandler("/Home/Error");
            }

            //*************************************************************************************************************
            var response = string.Empty; //  As the variable "response" got initialised inside the Configure, it has an application scope

            app.Use(async (context, next) =>
            {
                response += "Do something before the next middleware is invoked\n";
                await next.Invoke();
            });
            app.Use(async (context, next) =>
            {
                response += "Inside Middleware 1\n";
                await next.Invoke();
            });
            app.Use(async (context, next) =>
            {
                response += "Inside Middleware 2\n";
                await next.Invoke();
            });
            app.Run(async context =>
            {
                response += "App run\n";
                await context.Response.WriteAsync(response);
            });

            // Le reste du code suivant n'est pas conidéré par le runtime, car "app.Run" ne permet pas de passer à autres middlewares.
            // "app.Run" is the exit point which terminates the pipeline.
            // Et la réponse de la requête sera le contenu de "Response"
            //*************************************************************************************************************


            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                //pattern: "{controller=Example}/{action=TransientDependencies}/{id?}");
                endpoints.MapControllerRoute(
                    name: "example",
                    pattern: "{controller=ooo}/{action=Index}/{id?}");
            });


            //***************************************************************************
            //IExampleScoped scopedOne;
            //IExampleScoped scopedTwo;

            //var serviceProviderOrContainer = _services.BuildServiceProvider();
            //var serviceScopeFactory = serviceProviderOrContainer.GetRequiredService<IServiceScopeFactory>();

            //using (var scope = serviceScopeFactory.CreateScope())
            //{
            //    scopedOne = scope.ServiceProvider.GetService<IExampleScoped>();
            //    Debug.WriteLine(scopedOne.ExampleId);
            //    Debug.WriteLine(scopedOne.ExampleId);
            //}
            //using (var scope = serviceScopeFactory.CreateScope())
            //{
            //    scopedTwo = scope.ServiceProvider.GetService<IExampleScoped>();
            //    Debug.WriteLine(scopedTwo.ExampleId);
            //}
            //***************************************************************************

        }
    }
}
