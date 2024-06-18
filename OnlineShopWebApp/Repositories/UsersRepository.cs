using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IRolesRepository _rolesRepository;
        private List<User> _users = new List<User>();
        public int CurrentUserId { get; private set; } = 1;

        public UsersRepository(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
            var user = new User();
            user.Login = "Denis";
            user.Password = "12345";
            user.Role = _rolesRepository.GetRoleByName("Admin");
            _users.Add(user);
        }

        public void ChangeUser(int id)
        {
            CurrentUserId = id;
        }

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public void DelUser(User user)
        {
            if (user != null)
                _users.Remove(user);
        }

        public List<User> GetUsers()
        {
            return _users;
        }

        public User GetUserByLogin(string Login)
        {
            return _users.Find(x => x.Login == Login);
        }

        public User GetUserById(int id)
        {
            return _users.Find(x => x.Id == id);
        }
    }
}
