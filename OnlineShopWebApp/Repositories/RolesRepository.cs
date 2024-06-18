using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Repositories
{
    public class RolesRepository : IRolesRepository
    {
        private List<Role> _roles = new List<Role>() { new Role { Name = "Admin" }, new Role { Name = "User" } };

        public void AddRole(Role role)
        {
            _roles.Add(role);
        }

        public List<Role> GetRoles()
        {
            return _roles;
        }

        public Role GetRoleById(int id)
        {
            return _roles.Find(x => x.Id == id);
        }

        public Role GetRoleByName(string name)
        {
            return _roles.Find(x => x.Name == name);
        }

        public void DelRole(Role role)
        {
            if (role != null)
                _roles.Remove(role);
        }

        public bool CheckRoleExists(string name)
        {
            return _roles.Any(x => x.Name == name);
        }
    }
}
