using System.ComponentModel.DataAnnotations;

namespace MealsMvc.Models
{
    public class Step
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        //Foreign key to Recipe
        //public int RecipeID { get; set; }
    }
}
