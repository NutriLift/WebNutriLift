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
            public async void CreateUser ([FromBody] UserModel userModel)
        {
            var User = new UserDetails()
            {
                UserName = userModel.UserName,
                FirstName = userModel.FirstName,
                FamilyName = userModel.LastName,
                BirthDate = userModel.DOB.Date,
                Gender = userModel.Gender,
                //CreatedDate = DateTime.Now,
                IsAdmin = userModel.IsAdmin,
                IsActive = true
            };
            await userDetails.CreateAsync(User);

               
        }
    }
}
