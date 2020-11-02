using System;
using System.ComponentModel.DataAnnotations;

namespace NutriLift.Models
{
    public class UserDetailsModel
    {
        public Guid UserId { get; set; }
        public bool IsActive { get; set; }
        public string FirstName { get; set; }
        public string FamilyName { get; set; }
        [DataType(DataType.EmailAddress)] // Adding EmailAddress DataType so that we dont have to manually check the format
        [Required(ErrorMessage = "UserName is required.")]
        public string UserName { get; set; }
        [DataType(DataType.Password)] // Adding Password DataType to mask the input
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }    
        public DateTime BirthDate { get; set; }
        public char Gender { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsAdmin { get; set; }
    }
}
