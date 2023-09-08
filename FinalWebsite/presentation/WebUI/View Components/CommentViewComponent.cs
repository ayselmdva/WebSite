/*using FinalWebsite.Data.Entities;
using FinalWebsite.WebUI.View_Models;
using JwtExample.Data.DataAccess;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FinalWebsite.WebUI.View_Components
{
	public class CommentViewComponent
	{
		private readonly AppDbContext _appDbContext;
		private readonly UserManager<AppUser> _userManager;

		public CommentViewComponent(AppDbContext appDbContext, UserManager<AppUser> userManager)
		{
			_appDbContext = appDbContext;
			_userManager = userManager;
		}

		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
            CommentVM vm = new CommentVM();
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                vm = new CommentVM() { ProductId = id, ApplicationUserId = user.Id };
                return View(vm);
            }
            return View(vm);
        }
	}
}
*/