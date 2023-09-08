using FinalWebsite.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalWebsite.WebUI.Areas.Manage.Controllers
{
	[Area(nameof(Manage))]
	[Authorize(Roles = "admin")]
	public class AdminController : Controller
	{
		private readonly UserManager<AppUser> _usermanager;
		private readonly SignInManager<AppUser> _signinmanager;
		private readonly RoleManager<IdentityRole> _rolemanager;

		public AdminController(SignInManager<AppUser> signinmanager, UserManager<AppUser> usermanager, RoleManager<IdentityRole> rolemanager)
		{
			_signinmanager = signinmanager;
			_usermanager = usermanager;
			_rolemanager = rolemanager;
		}

		public async Task<IActionResult> Index()
		{
			/*AppUser admin = new AppUser()
			{
				UserName = "admin",
				Name = "admin",
				Email = "memmedovaaysel501@gmail.com"
			};
			var result = await _usermanager.CreateAsync(admin, "Admin123");
			if (!result.Succeeded)
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError("", item.Description);
				}
				return Json(":(");
			}*/




			/*await _rolemanager.CreateAsync(new IdentityRole { Name = "admin" });*/
			/*await _rolemanager.CreateAsync(new IdentityRole { Name = "member" });*/


			/*var user = await _usermanager.FindByNameAsync("admin");
			await _usermanager.AddToRoleAsync(user, "admin");
			await _signinmanager.SignInAsync(user, false);*/


			return Json(":)");
		}
	}
}