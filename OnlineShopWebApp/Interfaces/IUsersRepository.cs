using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Interfaces
{
    public interface IUsersRepository
    {
        int CurrentUserId { get; }
        void AddUser(User user);
        void DelUser(User user);
        List<User> GetUsers();
        User GetUserByLogin(string Login);
        User GetUserById(int id);
        void ChangeUser(int id);
    }
}
