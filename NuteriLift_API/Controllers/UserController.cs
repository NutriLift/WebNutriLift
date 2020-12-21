using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NuteriLift_API.Entities;
using NuteriLift_API.Models;
using NuteriLift_API.Repository;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NuteriLift_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IRepository<UserDetails> userDetails;
        public UserController(IRepository<UserDetails> userDetailsRepo)
        {
            this.userDetails = userDetailsRepo;
        }

        [HttpPost("Register")]
            public async Task CreateUser ([FromBody] UserModel userModel)
        {
            var User = new UserDetails()
            {
                UD_UserName = userModel.UserName,
                UD_FirstName = userModel.FirstName,
                UD_FamilyName = userModel.LastName,
                UD_BirthDate = userModel.DOB.Date,
                UD_Gender = userModel.Gender,
                //UD_CreatedDate = DateTime.Now,
                UD_IsAdmin = userModel.IsAdmin,
                UD_IsActive = true
            };
            await userDetails.CreateAsync(User);

               
        }
    }
}
