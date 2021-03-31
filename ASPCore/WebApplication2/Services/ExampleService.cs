using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using WebApplication2.Interfaces;

namespace WebApplication2.Services
{
    public class ExampleService
    {
        public IExampleTransient TransientExample { get; }
        public IExampleScoped ScopedExample { get; }
        public IExampleSingleton SingletonExample { get; }
        public IExampleSingletonInstance SingletonInstanceExample { get; }

        public ExampleService(
            IExampleTransient transientExample, 
            IExampleScoped scopedExample, 
            IExampleSingleton singletonExample, 
            IExampleSingletonInstance instanceExample)
        {
            TransientExample = transientExample;
            ScopedExample = scopedExample;
            SingletonExample = singletonExample;
            SingletonInstanceExample = instanceExample;
        }
    }
}

