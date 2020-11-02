using NutriLift.Entities;
using System.Collections.Generic;

namespace NutriLift.Data
{
    public interface IUserDetailsRepository
    {
        UserDetails VerifyUserLogin(string userName);
        List<UserDetails> GetAllUsers();
    }
}
