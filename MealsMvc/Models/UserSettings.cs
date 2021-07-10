﻿using System.ComponentModel.DataAnnotations;

namespace MealsMvc.Models
{
    public class UserSettings
    {
        public int ID { get; set; }

        [Required]
        public int MealPlanID { get; set; }

        public MealPlan MealPlan { get; set; }
    }
}
