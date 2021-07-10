using Microsoft.EntityFrameworkCore;
using MealsMvc.Models;

namespace MealsMvc.Data
{
    public class MealsMvcContext : DbContext
    {
        public MealsMvcContext(DbContextOptions<MealsMvcContext> options)
            : base(options)
        {
        }
       
        public DbSet<MealsMvc.Models.MealPlan> MealPlans { get; set; }
        public DbSet<MealsMvc.Models.Recipe> Recipes {get; set; }
        public DbSet<MealsMvc.Models.Step> Steps { get; set; }
        public DbSet<MealsMvc.Models.Ingredient> Ingredients { get; set; }
        public DbSet<MealsMvc.Models.SizeType> SizeTypes { get; set; }
        public DbSet<MealsMvc.Models.PrepType> PrepTypes { get; set; }
        public DbSet<MealsMvc.Models.GroceryAisle> GroceryAisles { get; set; }
        public DbSet<MealsMvc.Models.Food> Foods { get; set; }
        public DbSet<MealsMvc.Models.MealPlanRecipe> MealPlanRecipes { get; set; }
        public DbSet<MealsMvc.Models.UserSettings> UserSettings { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MealPlan>().ToTable("MealPlan");
            modelBuilder.Entity<MealPlanRecipe>().ToTable("MealPlanRecipe");
            modelBuilder.Entity<Recipe>().ToTable("Recipe");
            modelBuilder.Entity<Step>().ToTable("Step");
            modelBuilder.Entity<Ingredient>().ToTable("Ingredient");
            modelBuilder.Entity<Food>().ToTable("Food");
            modelBuilder.Entity<PrepType>().ToTable("PrepType");
            modelBuilder.Entity<SizeType>().ToTable("SizeType");
            modelBuilder.Entity<GroceryAisle>().ToTable("GroceryAisle");
            modelBuilder.Entity<UserSettings>().ToTable("UserSettings");
        } 
    }
}
