using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Interfaces
{
    public interface IExampleScoped: IExampleService
    {
        Guid SingletonExampleId { get; }
        Guid TransientExampleId { get; }
    }
}
