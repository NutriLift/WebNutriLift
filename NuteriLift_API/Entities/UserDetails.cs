using System;
namespace NuteriLift_API.Entities
{
    public class UserDetails
    {

        public Guid UD_PK { get; set; }
        public bool UD_IsActive { get; set; }
        public string UD_FirstName { get; set; }
        public string UD_FamilyName { get; set; }
        public string UD_UserName { get; set; }
        public byte[] UD_UserPassword { get; set; }
        public byte[] UD_PasswordSalt { get; set; }
        public DateTime UD_BirthDate { get; set; }
        public char UD_Gender { get; set; }
        public DateTime UD_CreatedDate { get; set; }
        public bool UD_IsAdmin { get; set; }

        public UserDetails()
        {

        }
    }
}
