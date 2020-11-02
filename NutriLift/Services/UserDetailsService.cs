using NutriLift.Data;
using NutriLift.Entities;
using NutriLift.Helpers;
using NutriLift.Models;
using System.Collections.Generic;

namespace NutriLift.Services
{
    //CRUD operations using Dapper
    public class UserDetailsService : AutoMapperBase,IUserDetailsService
    {
        readonly IUserDetailsRepository userDetailsRepository;
        public UserDetailsService(IUserDetailsRepository userDetailsRepository)
        {
            this.userDetailsRepository = userDetailsRepository;
        }

        public bool ValidateUser(string userName, string password)
        {
            var user = userDetailsRepository.VerifyUserLogin(userName);
            if (user == null)
                return false;
            if (PBKDFSecurity.ValidatePassword(user.UserPassword, user.PasswordSalt, password))
                return true;
            return false;
        }

        public List<UserDetailsModel> GetAllUsers()
        {
            var userDetails = userDetailsRepository.GetAllUsers();
            var userDetailModel = mapper.Map<List<UserDetails>, List<UserDetailsModel>>(userDetails);
            return userDetailModel;
        }
    }
}
