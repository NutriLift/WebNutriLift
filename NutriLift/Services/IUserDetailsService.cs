using NutriLift.Models;
using System.Collections.Generic;

namespace NutriLift.Services
{
    public interface IUserDetailsService
    {
        bool ValidateUser(string userName, string password);
        List<UserDetailsModel> GetAllUsers();
    }
}
