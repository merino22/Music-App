using AssistantManager.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace AssistantManager.Infrastructure
{
    public class AssistantDatabaseContext : DbContext
    {
        public AssistantDatabaseContext(DbContextOptions<AssistantDatabaseContext> options) 
            : base(options)
        {
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }
    }
}