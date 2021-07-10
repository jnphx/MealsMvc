using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MealsMvc.Data;
using MealsMvc.Models;
using System.Diagnostics;

namespace MealsMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly MealsMvcContext _context;

        public HomeController(MealsMvcContext context)
        {
            _context = context;
        }

        // GET: MealPlans
        public async Task<IActionResult> Index(int SelectedMealPlanId)
        {
            var MealPlanVM = new MealPlanViewModel();

            IQueryable<MealPlan> RecipesIQ = _context.MealPlans
                 .Include(e => e.MealPlanRecipes)
                 .ThenInclude(c => c.Recipe);

            var userSettings = await _context.UserSettings.FirstOrDefaultAsync();

            if (SelectedMealPlanId == 0)
            {
                //First time through, they haven't selected, get from UserSettings

                if (userSettings != null)
                {
                    //Read from userSettings
                    SelectedMealPlanId = userSettings.MealPlanID;
                }
            }
            else
            {
                //They selected a mealplan from the dropdown, update UserSettings.MealPlanSelection
                userSettings.MealPlanID = SelectedMealPlanId;

                if (userSettings != null)
                {
                    if (await TryUpdateModelAsync<UserSettings>(
                        userSettings,
                        "",
                        s => s.MealPlanID))
                    {
                        await _context.SaveChangesAsync();
                    }
                }
            }

            //Filter for the selected meal plan id
            //RecipesIQ = RecipesIQ.FirstOrDefault(mp => mp.MealPlanID == SelectedMealPlanId);

            MealPlanVM.MealPlan = RecipesIQ.FirstOrDefault(mp => mp.MealPlanID == SelectedMealPlanId);
            if (MealPlanVM.MealPlan != null)
            {
                MealPlanVM.CurrentPlanName = MealPlanVM.MealPlan.Name;
            }
            MealPlanVM.MealPlans = await RecipesIQ.AsNoTracking().ToListAsync();

            //Use linq to sum MealPlanRecipes.NumServings * MealPlanRecipes.PercentForMe
            var mealPlanServings = (from m in _context.MealPlans
                                    join mpr in _context.MealPlanRecipes on m.MealPlanID equals mpr.MealPlanID
                                    join r in _context.Recipes on mpr.RecipeID equals r.RecipeID
                                    where m.MealPlanID == userSettings.MealPlanID
                                    select new
                                    {
                                        r.NumberServings,
                                        mpr.NumberBatches,
                                        r.PercentForYou
                                    }).ToList();

            MealPlanVM.TotalServings = mealPlanServings.Select(g => g.NumberBatches * g.NumberServings * g.PercentForYou).Sum();

            //Update the options for mealplan select list
            using (var context = _context)
            {
                //SelectList list = new SelectList([...my collection...], "Value", "Key", SelectedID);

                MealPlanVM.Options = context.MealPlans.Select(a =>
                                            new SelectListItem
                                            {
                                                Value = a.MealPlanID.ToString(),
                                                Text = a.Name,
                                                Selected = (a.MealPlanID == SelectedMealPlanId)
                                            }
                                            ).ToList();

            }
            return View(MealPlanVM);
        }

        [HttpPost]
        public async Task<IActionResult> CheckDelete(int? MealPlanRecipeID)
        {
            MealPlanRecipe mpr = _context.MealPlanRecipes.Find(MealPlanRecipeID);

            if (mpr != null)
            {
                if (mpr.NumberBatches == 1)
                {
                    //They want to delete this
                    _context.MealPlanRecipes.Remove(mpr);
                    _context.SaveChanges();
                }
                else
                {
                    //Decrement batch count
                    --mpr.NumberBatches;
                    if (await TryUpdateModelAsync<MealPlanRecipe>(
                        mpr,
                        "",
                        s => s.NumberBatches))
                    {
                        await _context.SaveChangesAsync();
                    }
                }
            }

            return Redirect("./Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> CheckAdd(int? MealPlanRecipeID)
        {
            MealPlanRecipe mpr = _context.MealPlanRecipes.Find(MealPlanRecipeID);

            if (mpr != null)
            {
                //Increment batch count
                ++mpr.NumberBatches;
                if (await TryUpdateModelAsync<MealPlanRecipe>(
                    mpr,
                    "",
                    s => s.NumberBatches))
                {
                    await _context.SaveChangesAsync();
                }
            }

            return Redirect("./Index");
        }
    }
}
