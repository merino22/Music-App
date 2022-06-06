using AssistantManager.Core.Entities;
using AssistantManager.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AssistantManager.Infrastructure.Repositories
{
    public class IngredientEFRepository : IRepository<Ingredient>
    {
        private readonly AssistantDatabaseContext _context;

        public IngredientEFRepository(AssistantDatabaseContext context)
        {
            _context = context;
        }

        public Ingredient Add(Ingredient entity)
        {
            var entry = _context.Ingredients.Add(entity);
            _context.SaveChanges();
            return entry.Entity;
        }

        public Ingredient Delete(Ingredient entity)
        {
            var entry = _context.Ingredients.Remove(entity);
            _context.SaveChanges();
            return entry.Entity;
        }

        public IEnumerable<Ingredient> Get()
        {
            return _context.Ingredients;
        }

        public Ingredient Get(string name)
        {
            return _context.Ingredients.SingleOrDefault(x => x.Name == name);
        }

        public Ingredient Get(int id)
        {
            return _context.Ingredients.SingleOrDefault(x => x.Id == id);
        }

        public Ingredient Update(Ingredient entity)
        {
            var entry = _context.Ingredients.Update(entity);
            _context.SaveChanges();
            return entry.Entity;
        }

    }
}
