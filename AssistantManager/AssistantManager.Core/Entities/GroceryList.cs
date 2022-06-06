using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssistantManager.Core.Entities
{
    public class GroceryList
    {
        public GroceryList()
        {
            this.Ingredients = new List<Ingredient>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; }
    }
}
