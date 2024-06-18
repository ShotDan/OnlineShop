using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class UserChangePassword
    {
        [StringLength(25, MinimumLength = 5, ErrorMessage = "Пароль должен содержать от 5 до 25 символов")]
        [Required(ErrorMessage = "Не указан пароль")]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "Пароли не совпадают!")]
        public string? RepeatPassword { get; set; }
    }
}
