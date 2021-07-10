﻿using System.ComponentModel.DataAnnotations;

namespace MealsMvc.Models
{
    public class Ingredient
    {
        public int ID { get; set; }

        [Required]
        public int FoodID { get; set; }

        [Required]
        public double Size { get; set; }

        [Required]
        public int SizeTypeID { get; set; }

        [Required]
        public int PrepTypeID { get; set; }

        public int MaxSize { get; set; }

        public bool Optional { get; set; }

        //foreign key to Recipe
        public Recipe Recipe { get; set; }

        //public int RecipeID;
        public Food Food { get; set; }

        public PrepType PrepType { get; set; }

        public SizeType SizeType { get; set; }
    }
}
