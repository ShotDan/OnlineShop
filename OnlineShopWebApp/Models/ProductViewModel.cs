using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Название товара не может быть пустым")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Не указана цена товара!")]
        [Range(1, 10000000, ErrorMessage ="Цена товара должна быть от 1 до 10 000 000")]
        [RegularExpression(@"^\d+(\.\d{0,2})?$", ErrorMessage = "Некорректная цена товара!")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Описание товара не может быть пустым")]
        [MinLength(10, ErrorMessage = "Описание товара не может содержать меньше 10 символов!")]
        public string Description { get; set; }
    }
}