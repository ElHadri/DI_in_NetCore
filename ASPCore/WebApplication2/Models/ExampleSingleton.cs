using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApplication2.Interfaces;

namespace WebApplication2.Models
{
    public class ExampleSingleton : IExampleSingleton
    {
        public Guid ExampleId { get; set; }
        public Guid ScopedExampleId { get; set; }
        public Guid TransientExampleId { get; set; }

        // Pour éviter runtime error à cause de la mauvaise dépendance
        public ExampleSingleton(/*IExampleTransient transient, IExampleScoped scoped*/)
        {
            ExampleId = Guid.NewGuid();
            ScopedExampleId = Guid.NewGuid() /*scoped.ExampleId*/;
            TransientExampleId = Guid.NewGuid() /*transient.ExampleId*/;
        }
    }
}
