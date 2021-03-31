using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApplication2.Interfaces;

namespace WebApplication2.Models
{
    public class ExampleScoped : IExampleScoped
    {
        public Guid ExampleId { get; set; }
        public Guid SingletonExampleId { get; set; }
        public Guid TransientExampleId { get; set; }

        public ExampleScoped(/*IExampleTransient transient, IExampleSingleton singleton*/)
        {
            ExampleId = Guid.NewGuid();
            SingletonExampleId = Guid.NewGuid(); /* singleton.ExampleId;*/
            TransientExampleId = Guid.NewGuid(); /* transient.ExampleId;*/
        }
    }
}
