using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssistantManager.Core.Entities
{
    public class Ingredient
    {
        public Ingredient()
        {
            this.GroceryLists = new List<GroceryList>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<GroceryList> GroceryLists { get; set; }
    }
}
