using ConfigManager.Models;
using Microsoft.EntityFrameworkCore;

namespace ConfigManager
{
    public class ConfigManagerDatabaseContext : DbContext
    {
        public DbSet<Host> Hosts { get; set; }

        public ConfigManagerDatabaseContext(DbContextOptions options) : base(options)
        {
            //...
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}