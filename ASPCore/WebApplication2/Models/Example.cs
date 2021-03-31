using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApplication2.Interfaces;

namespace WebApplication2.Models
{
    public class Example : IExampleScoped, IExampleSingleton, IExampleTransient, IExampleSingletonInstance
    {
        public Guid ExampleId { get; set; }

        //********************************************************************************
        // Just to avoid error 
        public Guid ScopedExampleId => throw new NotImplementedException();
        public Guid TransientExampleId => throw new NotImplementedException();
        public Guid SingletonExampleId => throw new NotImplementedException();
        //********************************************************************************


        public Example()
        {
            ExampleId = Guid.NewGuid();
        }
        public Example(Guid exampleId)
        {
            ExampleId = exampleId;
        }
    }
}

