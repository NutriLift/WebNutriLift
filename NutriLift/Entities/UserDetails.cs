using System;

namespace NutriLift.Entities
{
    public class UserDetails
    {
        public Guid UserId { get; set; }
        public bool IsActive { get; set; }
        public string FirstName { get; set; }
        public string FamilyName { get; set; }
        public string UserName { get; set; }
        public byte[] UserPassword { get; set; }
        public byte[] PasswordSalt { get; set; }
        public DateTime BirthDate { get; set; }
        public char Gender { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsAdmin { get; set; }
    }
}
