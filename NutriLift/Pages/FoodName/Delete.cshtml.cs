using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NutriLift.Models;
using NutriLift.Services;
using System;
using System.Threading.Tasks;

namespace NutriLift.Pages.FoodName
{
    public class DeleteModel : PageModel
    {
        private readonly IFoodService foodService;

        public DeleteModel(IFoodService foodService)
        {
            this.foodService = foodService;
        }

        [BindProperty]
        public FoodNameModel FoodName { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FoodName = await foodService.GetFoodByIdAsync((Guid)id);

            if (FoodName == null)
            {
                return NotFound();
            }
            return Page();
        }
        public async Task<IActionResult> OnPostAsync(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            FoodName = await foodService.GetFoodByIdAsync((Guid)id);

            if (FoodName != null)
            {
                await foodService.DeleteFoodAsync((Guid)id);
            }

            return RedirectToPage("./Index");
        }
    }
}
