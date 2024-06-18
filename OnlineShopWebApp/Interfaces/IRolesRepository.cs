using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Interfaces
{
    public interface IRolesRepository
    {
        List<Role> GetRoles();
        void AddRole(Role role);
        void DelRole(Role role);
        Role GetRoleById(int id);
        Role GetRoleByName(string name);
        bool CheckRoleExists(string name);
    }
}
