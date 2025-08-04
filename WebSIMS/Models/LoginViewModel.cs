using System.ComponentModel.DataAnnotations;

namespace WebSIMS.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Enter Email, please")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Enter Password, please")]
        public string Password { get; set; }
    }
}
