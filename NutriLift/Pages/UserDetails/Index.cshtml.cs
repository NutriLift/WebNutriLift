using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NutriLift.Models;
using NutriLift.Services;

namespace NutriLift.Pages.UserDetails
{
    //Login Page
    public class IndexModel : PageModel
    {
        readonly IUserDetailsService userDetailsService;
        public IndexModel(IUserDetailsService userDetailsService)
        {
            this.userDetailsService = userDetailsService;
        }

        public ActionResult OnGet()
        {
            return Page();
        }

        [BindProperty] // This property will be used in cshtml for binding
        public UserDetailsModel userDetailsModel { get; set; }

        public ActionResult OnPost(UserDetailsModel userDetailsModel)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = userDetailsService.ValidateUser(userDetailsModel.UserName, userDetailsModel.Password);
            //For testing purpose, redirecting to UserList page if authenticated successfully
            //else redirecting to FoodName List
            if (user)
                return RedirectToPage("/UserDetails/UserList");
            else
                return RedirectToPage("/FoodName/Index"); //return Page();
        }

    }
}
