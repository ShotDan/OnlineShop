using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class UserEditInfo
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Имя должно содержать от 4 до 20 символов")]
        public string? Login { get; set; }

        [EmailAddress(ErrorMessage = "Введите корректный email!")]
        public string? Email { get; set; }
    }
}
