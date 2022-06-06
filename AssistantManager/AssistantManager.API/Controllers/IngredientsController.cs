using AssistantManager.API.DataTransferObjects;
using AssistantManager.Core.Entities;
using AssistantManager.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AssistantManager.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IngredientsController : ControllerBase
    {
        private readonly IService<Ingredient> _ingredientService;

        public IngredientsController(IService<Ingredient> ingredientService)
        {
            _ingredientService = ingredientService;
        }

        [HttpGet] //Listado de ingredientes en su tabla
        public ActionResult<IEnumerable<IngredientDTO>> Get()
        {
            return Ok(_ingredientService.Get().Select(x => new IngredientDTO
            {
                Id = x.Id,
                Name = x.Name
            }).ToList()
            );
        }

        [HttpPost] //Agregar ingrediente a tabla
        public ActionResult<IngredientDTO> Post([FromBody] IngredientDTO newIngredient)
        {
            var result = _ingredientService.Add(new Ingredient
            {
                Name = newIngredient.Name
            });
            return result.Success ? Ok(new IngredientDTO
            {
                Id = result.Value.Id,
                Name = result.Value.Name
            }) : BadRequest(result.ErrorMessage);
        }

        [HttpDelete("{name}")] //Eliminar ingrediente de tabla
        public ActionResult Delete(string name)
        {
            var result = _ingredientService.Delete(name);
            return result.Success ? Ok(new IngredientDTO
            {
                Id = result.Value.Id,
                Name = result.Value.Name
            }) : NotFound("Ingrediente no fue encontrado");
        }
    }
}
