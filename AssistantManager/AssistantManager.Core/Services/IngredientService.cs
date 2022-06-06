using AssistantManager.Core.Entities;
using AssistantManager.Core.Interfaces;
using AssistantManager.Core.Models;
using System.Linq.Expressions;

namespace AssistantManager.Core.Services
{
    public class IngredientService : IService<Ingredient>
    {
        private readonly IRepository<Ingredient> _ingredientRepository;

        public IngredientService(IRepository<Ingredient> ingredientRepository)
        {
            _ingredientRepository = ingredientRepository;
        }

        public IEnumerable<Ingredient> Get()
        {
            return _ingredientRepository.Get();
        }
      
        public Result<Ingredient> Add(Ingredient entity)
        {
            //validar que no exista el nombre del ingrediente
            if (_ingredientRepository.Get().Any(x => x.Name == entity.Name))
            {
                return new Result<Ingredient>($"Ingrediente {entity.Name} ya existe");
            }
            var entry = _ingredientRepository.Add(entity);
            return new Result<Ingredient>(entry);
        }

        public Result<Ingredient> Get(string name) //Devuelve el ingrediente en base a su nombre
        {
            var ingredient = _ingredientRepository.Get(name);
            if (ingredient == null) //si el ingrediente no existía, lo agrega a la tabla
            {
                ingredient = new Ingredient
                {
                    Name = name
                };
                ingredient = _ingredientRepository.Add(ingredient);
            }
            return new Result<Ingredient>(ingredient);
        }

        public Result<Ingredient> Delete(string name)
        {
            var entity = _ingredientRepository.Get(name);
            if (entity == null)
            {
                return new Result<Ingredient>($"Ingrediente {name} no existe");
            }
            return new Result<Ingredient>(_ingredientRepository.Delete(entity));
        }

        public Result<Ingredient> Update(Ingredient entity)
        {
            throw new NotImplementedException();
        }

        public Result<Ingredient> Get(int id)
        {
            throw new NotImplementedException();
        }
    }
}
