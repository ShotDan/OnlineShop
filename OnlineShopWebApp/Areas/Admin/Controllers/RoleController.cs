using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly IRolesRepository _rolesRepository;
        private readonly IUsersRepository _usersRepository;
        public RoleController(IRolesRepository rolesRepository, IUsersRepository usersRepository) 
        { 
            _rolesRepository = rolesRepository;
            _usersRepository = usersRepository;
        }

        public IActionResult Roles()
        {
            var roles = _rolesRepository.GetRoles();
            return View(roles);
        }

        public IActionResult DelRole(int id)
        {
            var role = _rolesRepository.GetRoleById(id);
            var users = _usersRepository.GetUsers();

            if (users.Any(x => x.Role.Name == role.Name))
            {
                TempData["ErrorMessage"] = "Невозможно удалить роль, потому что она где-то используется.";
                TempData.Keep("ErrorMessage");
                return RedirectToAction("Roles");
            }

            _rolesRepository.DelRole(role);
            return RedirectToAction("Roles");
        }

        public IActionResult AddRoleIndex()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddRole(Role role)
        {
            var isRoleExist = _rolesRepository.CheckRoleExists(role.Name);

            if (isRoleExist)
            {
                ModelState.AddModelError("Name", "Такая роль уже существует!");
            }

            if (!ModelState.IsValid)
            {
                return View("AddRoleIndex", role);
            }

            _rolesRepository.AddRole(role);
            return RedirectToAction("Roles");
        }
    }
}
