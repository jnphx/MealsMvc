﻿using System.ComponentModel.DataAnnotations;

namespace MealsMvc.Models
{
    public class PrepType
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
