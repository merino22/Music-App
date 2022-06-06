using AssistantManager.Core.Entities;
using AssistantManager.Core.Interfaces;
using AssistantManager.Core.Models;
using System.Linq.Expressions;

namespace AssistantManager.Core.Services
{
    public class GroceryListService : IService<GroceryList>
    {
        private readonly IRepository<GroceryList> _groceryListRepository;

        public GroceryListService(IRepository<GroceryList> groceryListRepository)
        {
            _groceryListRepository = groceryListRepository;
        }

        public Result<GroceryList> Add(GroceryList entity)
        {
            // validar que no se repita nombre de lista
            if (_groceryListRepository.Get().Any(x => x.Name == entity.Name))
            {
                return new Result<GroceryList>($"Lista {entity.Name} ya existe");
            }
            var entry = _groceryListRepository.Add(entity);
            return new Result<GroceryList>(entry);
        }

        public IEnumerable<GroceryList> Get()
        {
            return _groceryListRepository.Get();
        }

        public Result<GroceryList> Update(GroceryList entity)
        {
            var list = _groceryListRepository.Update(entity);
            return new Result<GroceryList>(list);
        }

        public Result<GroceryList> Get(string name)
        {
            var list = _groceryListRepository.Get(name);
            return list == null ? new Result<GroceryList>($"La lista {name} no existe")
                : new Result<GroceryList>(list);
        }

        public Result<GroceryList> Delete(string name)
        {
            var entity = _groceryListRepository.Get(name);
            if(entity == null)
            {
                return new Result<GroceryList>($"Lista {name} no existe");
            }
            return new Result<GroceryList>(_groceryListRepository.Delete(entity));
        }

        public Result<GroceryList> Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
