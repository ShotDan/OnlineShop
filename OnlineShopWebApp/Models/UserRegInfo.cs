using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class UserRegInfo
    {
        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Имя должно содержать от 4 до 20 символов")]
        public string? Login { get; set; }

        [StringLength(25, MinimumLength =5, ErrorMessage ="Пароль должен содержать от 5 до 25 символов")]
        [Required(ErrorMessage = "Не указан пароль")]
        public string? Password { get; set; }

        [Compare("Password", ErrorMessage = "Пароли не совпадают!")]
        public string? RepeatPassword { get; set; }

        [EmailAddress(ErrorMessage = "Введите корректный email!")]
        public string? Email { get; set; }
    }
}
