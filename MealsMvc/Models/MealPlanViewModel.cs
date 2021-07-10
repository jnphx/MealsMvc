using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MealsMvc.Models
{
    public class MealPlanViewModel
    {
        public string Message { get; set; } = "Initial Request";
        public double TotalServings { get; set; }
        public string CurrentPlanName { get; set; }
        public IList<MealPlan> MealPlans { get; set; }
        public MealPlan MealPlan { get; set; }
        public List<SelectListItem> Options { get; set; }
        public int SelectedMealPlanId { get; set; }
        public MealPlanRecipe MealPlanRecipe { get; set; }
        public int MealCount;
    }
}
