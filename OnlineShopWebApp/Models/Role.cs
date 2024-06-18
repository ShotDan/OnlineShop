using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class Role
    {
        private static int nextId = 1;
        public int Id { get; }

        [Required(ErrorMessage = "Не указано название роли!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Название роли должно содержать от 3 до 20 символов")]
        public string Name { get; set; }

        public Role()
        {
            Id = nextId;
            nextId++;
        }
    }
}
