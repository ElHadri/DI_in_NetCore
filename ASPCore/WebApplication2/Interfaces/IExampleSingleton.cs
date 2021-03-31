﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Interfaces
{
    public interface IExampleSingleton : IExampleService
    {
        Guid ScopedExampleId { get; }
        Guid TransientExampleId { get; }
    }
}
