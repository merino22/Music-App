using AssistantManager.Core.Entities;
using AssistantManager.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AssistantManager.Infrastructure.Repositories
{
    public class GroceryListEFRepository : IRepository<GroceryList>
    {
        private readonly AssistantDatabaseContext _context;

        public GroceryListEFRepository(AssistantDatabaseContext context)
        {
            _context = context;
        }

        public GroceryList Add(GroceryList entity)
        {
            var entry = _context.GroceryLists.Add(entity);
            _context.SaveChanges();
            return entry.Entity;
        }

        public GroceryList Delete(GroceryList entity)
        {
            var entry = _context.GroceryLists.Remove(entity);
            _context.SaveChanges();
            return entry.Entity;
        }

        public IEnumerable<GroceryList> Get()
        {
            return _context.GroceryLists;
        }

        public GroceryList Get(string name)
        {
            return _context.GroceryLists.Include(x => x.Ingredients).SingleOrDefault(x => x.Name == name);
        }

        public GroceryList Get(int id)
        {
            return _context.GroceryLists.Include(x => x.Ingredients).SingleOrDefault(x => x.Id == id);
        }

        public GroceryList Update(GroceryList entity)
        {
            var entry = _context.GroceryLists.Update(entity);
            _context.SaveChanges();
            return entry.Entity;
        }

    }
}
