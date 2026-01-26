using Microsoft.AspNetCore.Identity;

namespace Bagery.Core.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? LastLoginDate { get; set; }
        public bool IsActive { get; set; } = true;
        public string ProfileImagePublicId { get; set; }
        public string ProfileImageUrl { get; set; }
    }
}
