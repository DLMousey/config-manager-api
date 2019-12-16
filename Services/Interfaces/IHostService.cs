using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConfigManager.Models;

namespace ConfigManager.Services.Interfaces
{
    public interface IHostService
    {
        Task<List<Host>> FindAll();

        Task<Host> Find(Guid id);

        Task Create(Host host);
    }
}