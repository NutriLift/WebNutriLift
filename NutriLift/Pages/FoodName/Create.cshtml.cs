using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NutriLift.Models;
using NutriLift.Services;
using System.Threading.Tasks;

namespace NutriLift.Pages.FoodName
{
    public class CreateModel : PageModel
    {
        private readonly IFoodService foodService;

        public CreateModel(IFoodService foodService)
        {
            this.foodService = foodService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public FoodNameModel FoodName { get; set; }
        
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await foodService.CreateFoodAsync(FoodName);

            return RedirectToPage("./Index");
        }
    }
}
