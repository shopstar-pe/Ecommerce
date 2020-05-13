using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.Application.Abstractions
{
    public interface IBusService
    {
        Task Publish<T>(string queue, List<T> data) where T : class, new();
    }
}
