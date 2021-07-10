using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MealsMvc.Models
{
    public class GroceryAisle
    {
        public int GroceryAisleID { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Food> Foods { get; set; }
    }
}
