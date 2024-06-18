using Microsoft.AspNetCore.Mvc;
using OnlineShopWebApp.Interfaces;
using OnlineShopWebApp.Models;
using OnlineShopWebApp.Repositories;

namespace OnlineShopWebApp.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class UserController : Controller
	{
		private readonly IUsersRepository _usersRepository;
		private readonly IRolesRepository _rolesRepository;

		public UserController(IUsersRepository usersRepository, IRolesRepository rolesRepository)
		{
			_usersRepository = usersRepository;
			_rolesRepository = rolesRepository;
		}

		public IActionResult Users()
		{
			var users = _usersRepository.GetUsers();
			return View(users);
		}

		public IActionResult GetUser(int id)
		{
			var user = _usersRepository.GetUserById(id);
			return View(user);
		}

		public IActionResult DeleteUser(int id)
		{
			var user = _usersRepository.GetUserById(id);
			_usersRepository.DelUser(user);
			return RedirectToAction("Users");
		}

		public IActionResult AddUser()
		{
			return View();
		}

		[HttpPost]
		public IActionResult AddUser(UserRegInfo userRegData)
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

			if (userRegData.Email != null)
				user.Email = userRegData.Email;

			_usersRepository.AddUser(user);

			return RedirectToAction("Users");
		}

		public IActionResult EditUser(int id)
		{
			var user = _usersRepository.GetUserById(id);
			var userEditData = new UserEditInfo();
			userEditData.Login = user.Login;
			userEditData.UserId = user.Id;

			if (user.Email != "-")
				userEditData.Email = user.Email;

			return View(userEditData);
		}

		[HttpPost]
		public IActionResult EditUser(UserEditInfo userEditData)
		{
			if (!ModelState.IsValid)
			{
				return View(userEditData);
			}

			var users = _usersRepository.GetUsers();
			var user = _usersRepository.GetUserById(userEditData.UserId);

			if(user.Login == userEditData.Login)
			{
                ModelState.AddModelError("", "Невозможно сменить логин на тот, который вы уже используете!");
                return View(userEditData);
            }

			if (users.Any(x => x.Login == userEditData.Login))
			{
				ModelState.AddModelError("", "Такой логин уже существует!");
				return View(userEditData);
			}


			user.Login = userEditData.Login;

			if (string.IsNullOrWhiteSpace(userEditData.Email))
				user.Email = "-";
			else
				user.Email = userEditData.Email;

			return RedirectToAction("Users");
		}

		public IActionResult ChangePassword(int id)
		{
			ViewData["UserID"] = id;
			return View();
		}

		[HttpPost]
		public IActionResult ChangePassword(int id, UserChangePassword userChangePassword)
		{
			if (!ModelState.IsValid)
			{
				return View(userChangePassword);
			}

			var user = _usersRepository.GetUserById(id);
			user.Password = userChangePassword.Password;

			return RedirectToAction("Users");
		}

		public IActionResult ChangeAccess(int id)
		{
			var user = _usersRepository.GetUserById(id);
			var roles = _rolesRepository.GetRoles();
			ViewData["userRole"] = user.Role.Name;
			ViewData["UserID"] = user.Id;
			return View(roles);
		}

		[HttpPost]
		public IActionResult ChangeAccess(int id, string role)
		{
			var user = _usersRepository.GetUserById(id);
			var userRole = _rolesRepository.GetRoleByName(role);
			user.Role = userRole;
			return RedirectToAction("Users");
		}
	}
}
