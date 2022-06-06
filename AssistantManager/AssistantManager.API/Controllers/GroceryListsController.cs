using AssistantManager.API.DataTransferObjects;
using AssistantManager.Core.Entities;
using AssistantManager.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssistantManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroceryListsController : ControllerBase
    {
        private readonly IService<GroceryList> _groceryListService;
        private readonly IService<Ingredient> _ingredientService;

        public GroceryListsController(IService<GroceryList> groceryListService, IService<Ingredient> ingredientService)
        {
            _groceryListService = groceryListService;
            _ingredientService = ingredientService;
        }

        [HttpGet] //Listar todas las grocery lists
        public ActionResult<IEnumerable<GroceryListDTO>> Get()
        {
            return Ok(_groceryListService.Get().Select(x => new GroceryListDTO
            {
                Id = x.Id,
                Name = x.Name
            }).ToList()
            );
        }

        [HttpGet("{name}")] //Obtener ingredientes de una grocery list dado su nombre
        public ActionResult<IEnumerable<IngredientDTO>> Get(string name)
        {
            var result = _groceryListService.Get(name);
            if (result.Success)
            {
                return Ok(result.Value.Ingredients.Select(x => new IngredientDTO
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList());
            }
            return NotFound(result.ErrorMessage);
        }

        [HttpPost] //Crear una grocery list nueva y vacía
        public ActionResult<GroceryListDTO> Post([FromBody] GroceryListDTO newList)
        {
            var result = _groceryListService.Add(new GroceryList
            {
                Name = newList.Name
            });
            return result.Success ? Ok(new GroceryListDTO
            {
                Id = result.Value.Id,
                Name = result.Value.Name
            }) : BadRequest(result.ErrorMessage);
        }

        [HttpPut] //Agregar ingredientes a una lista
        public ActionResult<IEnumerable<IngredientDTO>> AddIngredient([FromBody] ListIngredientsDTO listIngredients)
        {
            var list = _groceryListService.Get(listIngredients.ListName);

            if (list.Success)
            {
                listIngredients.Ingredients.ToList()
                    .ForEach( ingredient => list.Value.Ingredients
                    .Add(_ingredientService.Get(ingredient).Value));

                var result = _groceryListService.Update(list.Value);
                return Ok(result.Value.Ingredients.Select(x => new IngredientDTO
                {
                    Id = x.Id,
                    Name = x.Name
                }));
            }
            return NotFound(list.ErrorMessage);
        }

        [HttpPut("{name}")] //Eliminar ingredientes de una lista
        public ActionResult<IEnumerable<IngredientDTO>> RemoveIngredient([FromBody] ListIngredientsDTO listIngredients)
        {
            var list = _groceryListService.Get(listIngredients.ListName);

            if (list.Success)
            {
                listIngredients.Ingredients.ToList()
                    .ForEach(ingredient => list.Value.Ingredients
                    .Remove(_ingredientService.Get(ingredient).Value));

                var result = _groceryListService.Update(list.Value);
                return Ok(result.Value.Ingredients.Select(x => new IngredientDTO
                {
                    Id = x.Id,
                    Name = x.Name
                }));
            }
            return NotFound(list.ErrorMessage);
        }

    }
}