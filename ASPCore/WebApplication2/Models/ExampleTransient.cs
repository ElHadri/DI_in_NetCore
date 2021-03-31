using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApplication2.Interfaces;

namespace WebApplication2.Models
{
    public class ExampleTransient : IExampleTransient
    {
        public Guid ExampleId { get; set; }
        public Guid SingletonExampleId { get; set; }
        public Guid ScopedExampleId { get; set; }

        public ExampleTransient(IExampleSingleton singleton, IExampleScoped scoped)
        {
            ExampleId = Guid.NewGuid();
            SingletonExampleId = singleton.ExampleId;
            ScopedExampleId = scoped.ExampleId;
        }
    }
}
