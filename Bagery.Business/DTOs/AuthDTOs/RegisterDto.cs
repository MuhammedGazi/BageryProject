using Microsoft.AspNetCore.Http;

namespace Bagery.Business.DTOs.AuthDTOs
{
    public class RegisterDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public IFormFile ProfileImage { get; set; }
    }
}
