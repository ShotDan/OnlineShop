using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace OnlineShopWebApp.Models
{
    public class UserDeliveryInfo
    {

        [Required(ErrorMessage = "Не указано имя!")]
        [StringLength(45, MinimumLength = 10, ErrorMessage = "Фио должно содержать от 10 до 50 символов")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указан email!")]
        [EmailAddress(ErrorMessage = "Введите корректный email!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Не указан телефон!")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Не указан Адрес!")]
        public string Address { get; set; }
        public string? Comment { get; set; }
    }
}
