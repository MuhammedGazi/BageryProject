using Microsoft.AspNetCore.Identity;

namespace Bagery.Core.Entities
{
    public class AppRole : IdentityRole<int>
    {
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
