using System.ComponentModel.DataAnnotations;

namespace Survey1.Authentication
{
    public class LoginModel
    {
        [Required(ErrorMessage = "fullName is required")]
        public string fullName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
