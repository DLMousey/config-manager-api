using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConfigManager.Models;
using ConfigManager.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ConfigManager.Services.Implementation
{
    public class HostService : IHostService
    {
        private readonly ConfigManagerDatabaseContext _context;

        public HostService(ConfigManagerDatabaseContext context)
        {
            _context = context;
        }
        
        public async Task<List<Host>> FindAll()
        {
            return await _context.Hosts.ToListAsync();
        }

        public async Task<Host> Find(Guid id)
        {
            return await _context.Hosts.FindAsync(id);
        }

        public async Task Create(Host host)
        {
            await _context.AddAsync(host);
            await _context.SaveChangesAsync();
        }
    }
}