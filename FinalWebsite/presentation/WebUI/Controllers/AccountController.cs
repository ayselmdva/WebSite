using FinalWebsite.Data.Entities;
using FinalWebsite.WebUI.View_Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;

namespace FinalWebsite.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) { return View(); }
            AppUser newUser = new AppUser()
            {
                UserName = registerVM.UserName,
                Name = registerVM.Name,
                Email = registerVM.Email,
                
            };
            var result = await _userManager.CreateAsync(newUser, registerVM.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                    return View();
                }
            }

            await _userManager.AddToRoleAsync(newUser, "member");

            var token = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);

			var confirmationUrl = Url.Action("ConfirmEmail", "Account", new { userId = newUser.Id, token = token }, Request.Scheme);
			SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
			{
				Port = 587,
				Credentials = new NetworkCredential("maysel353@gmail.com", "fpqzhxrtrphoitbf"),
				EnableSsl = true,
			};
			MailMessage mailMessage = new MailMessage("maysel353@gmail.com", newUser.Email, "Email Confirmation", $@"<a href={confirmationUrl}>Verify Email</a>");
			mailMessage.IsBodyHtml = true;

			smtpClient.Send(mailMessage);

			await _signInManager.SignInAsync(newUser, false);
            return RedirectToAction("ProcessPayment", "Payment");
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) { return View(); }
            if (loginVM.UserNameOrEmail.Contains("@"))
            {
                var user = await _userManager.FindByEmailAsync(loginVM.UserNameOrEmail);
                if (user == null)
                {
                    NotFound();
                    return View();
                }
                var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, true, true);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Error");
                    return View();
                }
            }
            else
            {
                var user = await _userManager.FindByNameAsync(loginVM.UserNameOrEmail);
                if (user == null)
                {
                    NotFound();
                    return View();
                }
                var result = await _signInManager.PasswordSignInAsync(user,loginVM.Password,true,true);
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", "Error");
                    return View();
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();

            var confirm = await _userManager.ConfirmEmailAsync(user, token);
            if (confirm.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}