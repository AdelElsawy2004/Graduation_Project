using System.ComponentModel.DataAnnotations;

namespace Graduation_Project.Dtos
{
    public class LoginDto
    {
        [EmailAddress]
        public string Email { get; set; }
        public string  password { get; set; }
    }
}
