using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NutriLift.Models;
using NutriLift.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NutriLift.Pages.FoodName
{
    public class IndexModel : PageModel
    {
        private readonly IFoodService foodService;

        public IndexModel(IFoodService foodService)
        {
            this.foodService = foodService;
        }

        public List<FoodNameModel> FoodName { get;set; }

        public async Task<IActionResult> OnGetAsync()
        {
            FoodName = await foodService.GetAllFoodsAsync();
            return Page();
        }
    }
}
