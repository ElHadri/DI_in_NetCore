using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Interfaces
{
    public interface IExampleTransient: IExampleService
    {
        Guid SingletonExampleId { get; }
        Guid ScopedExampleId { get; }
    }
}
