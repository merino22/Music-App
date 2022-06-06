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

        public DbSet<GroceryList> GroceryLists { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Reminder> Reminders { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Song> Songs { get; set; }
    }
}