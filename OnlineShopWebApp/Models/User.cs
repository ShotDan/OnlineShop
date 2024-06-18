using System.ComponentModel.DataAnnotations;

namespace OnlineShopWebApp.Models
{
    public class User
    {
        private static int nextId = 1;
        public int Id { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }
        public string Email { get; set; } = "-";
        public bool RememberMe { get; set; }
        public Role? Role { get; set; }

        public User()
        {
            Id = nextId;
            nextId++;
        }
    }
}
