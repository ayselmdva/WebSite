using FinalWebsite.Data.Entities;
using JwtExample.Data.DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FinalWebsite.WebUI.Controllers
{
    public class ProfilController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

		public ProfilController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		public async Task<IActionResult> Index()
        {
            var user=await _userManager.GetUserAsync(User);
            return View();
        }
    }
}
