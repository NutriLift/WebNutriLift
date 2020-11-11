using System;
namespace NuteriLift_API.Models
{
    public class UserModel
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public char Gender { get; set; }
        public DateTime DOB { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EMail { get; set; }
        public bool IsAdmin { get; set; }


    }
}
