using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class UserLoginInfo
    {
        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Имя должно содержать от 4 до 20 символов")]
        public string? Login { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        public string? Password { get; set; }
        public bool? RememberMe { get; set; }
    }
}
