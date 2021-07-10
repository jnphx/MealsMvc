using System.ComponentModel.DataAnnotations;

namespace MealsMvc.Models
{
    public class SizeType
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
