using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;

namespace OnlineShopWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IRolesRepository _rolesRepository;

        public AccountController(IUsersRepository usersRepository, IRolesRepository rolesRepository)
        {
            _usersRepository = usersRepository;
            _rolesRepository = rolesRepository;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserLoginInfo userLoginData)
        {
            if (!ModelState.IsValid)
            {
                return View(userLoginData);
            }

            var user = _usersRepository.GetUserByLogin(userLoginData.Login);

            if (user == null)
            {
                ModelState.AddModelError("", "Неправильный логин или пароль");
                return View(userLoginData);
            }

            if (userLoginData.Password != user.Password)
            {
                ModelState.AddModelError("", "Неправильный логин или пароль");
                return View(userLoginData);
            }

            HttpContext.Session.SetString("LoggedInMessage", "Вы успешно вошли в свой аккаунт");
            _usersRepository.ChangeUser(user.Id);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Reg()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Reg(UserRegInfo userRegData)
        {
            if (!ModelState.IsValid)
            {
                return View(userRegData);
            }

            var users = _usersRepository.GetUsers();

            if (users.Any(x => x.Login == userRegData.Login))
            {
                ModelState.AddModelError("", "Такой логин уже существует!");
                return View(userRegData);
            }

            User user = new User();
            user.Login = userRegData.Login;
            user.Password = userRegData.Password;
            user.Role = _rolesRepository.GetRoleByName("User");
            _usersRepository.AddUser(user);

            return RedirectToAction("Login", "Account");
        }
    }
}
