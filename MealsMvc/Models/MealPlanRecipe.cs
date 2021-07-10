using System.ComponentModel.DataAnnotations;

namespace MealsMvc.Models
{
    public class MealPlanRecipe
    {
        public int MealPlanRecipeID { get; set; }
        public int MealPlanID { get; set; }
        public int RecipeID { get; set; }
        [Required]
        public double NumberBatches { get; set; }

        public MealPlan MealPlan { get; set; }
        public Recipe Recipe { get; set; }

        public MealPlanRecipe()
        {
            NumberBatches = 1;
        }
    }
}
