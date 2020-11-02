using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NutriLift.Services;
using System.Collections.Generic;

namespace NutriLift.Pages.UserDetails
{
    public class UserListModel : PageModel
    {
        readonly IUserDetailsService userDetailsService;
        public UserListModel(IUserDetailsService userDetailsService)
        {
            this.userDetailsService = userDetailsService;
        }

        [BindProperty]
        public IList<Models.UserDetailsModel> userDetailsModel { get; set; }

        public IActionResult OnGet()
        {
            userDetailsModel = userDetailsService.GetAllUsers();
            return Page();
        }

    }
}
