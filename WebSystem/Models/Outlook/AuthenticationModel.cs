using System.ComponentModel.DataAnnotations;

namespace WebSystem.Models.Outlook
{
    public class AuthenticationModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        [Required]
        [Display(Name = "Nombre Usuario")]
        public string UserNameText { get; set; }
        [Required]
        [Display(Name = "Contraseña")]
        public string PasswordText { get; set; }
    }
}
