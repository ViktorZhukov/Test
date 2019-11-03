using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class RegisterModel
    {
        [Required]
        public string Email { get; set; }          

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}
