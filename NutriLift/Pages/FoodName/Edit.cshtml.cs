using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NutriLift.Models;
using NutriLift.Services;
using System;
using System.Threading.Tasks;

namespace NutriLift.Pages.FoodName
{
    public class EditModel : PageModel
    {
        private readonly IFoodService foodService;

        public EditModel(IFoodService foodService)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            try
            {
                await foodService.UpdateFoodAsync(FoodName);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!foodService.FoodNameExists(FoodName.FN_PK))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
    }
}
