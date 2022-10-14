using System.ComponentModel.DataAnnotations;

namespace Survey1.Authentication
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "fullName is required")]
        public string fullName { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

    }
}
