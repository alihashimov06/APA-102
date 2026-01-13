using _34_Front_To_BackSqlConnection.Models;
using _34_Front_To_BackSqlConnection.Utilities.Enums;
using _34_Front_To_BackSqlConnection.ViewModels;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MimeKit;
using MimeKit.Text;
using System.Threading.Tasks;

namespace _34_Front_To_BackSqlConnection.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVM);
            }

            AppUser appUser = new()
            {
                Name = registerVM.Name,
                Surname = registerVM.Surname,
                UserName = registerVM.UserName,
                Email = registerVM.Email
            };



            IdentityResult result = await _userManager.CreateAsync(appUser, registerVM.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View();
            }

            await _userManager.AddToRoleAsync(appUser, UserRoles.Member.ToString());

            string token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);

            string confirmationLink = Url.Action(nameof(ConfirmationEmail),"Account",
                new { appUserId = appUser.Id,token},
                Request.Scheme,Request.Host.ToString());

            // create email message
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse("alihashimov2006az@gmail.com"));
            email.To.Add(MailboxAddress.Parse(appUser.Email));
            email.Subject = "Verify Email";

            string body = string.Empty;

            using StreamReader reader = new StreamReader("wwwroot/Templates/verify.html");
            body = reader.ReadToEnd();

            body = body.Replace("{{link}}", confirmationLink);
            body = body.Replace("{{username}}", appUser.UserName);

            email.Body = new TextPart(TextFormat.Html) { Text = body };

            // send email
            using var smtp = new SmtpClient();
            smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            smtp.Authenticate("alihashimov2006az@gmail.com", "zzfyxhaalgutohpx");
            smtp.Send(email);
            smtp.Disconnect(true);

            return RedirectToAction(nameof(VerifyEmail));
        }

        public IActionResult VerifyEmail()
        {
            return View();
        }

        public async Task<IActionResult> ConfirmationEmail(string appUserId, string token)

        {
            if (appUserId == null || token == null) return BadRequest();

            AppUser appUser = await _userManager.FindByIdAsync(appUserId);
            if (appUser == null) return NotFound();

            IdentityResult result = await _userManager.ConfirmEmailAsync(appUser, token);
            if (!result.Succeeded) return BadRequest();

            return RedirectToAction(nameof(Login));
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM, string? returnURL)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            AppUser appUser = await _userManager.Users
                .FirstOrDefaultAsync(u => u.UserName == loginVM.UserNameOrEmail || u.Email == loginVM.UserNameOrEmail);
            if (appUser == null)
            {
                ModelState.AddModelError(string.Empty, "Username or Email or password is incorrect");
                return View();
            }

            var result = await _signInManager.PasswordSignInAsync(appUser, loginVM.Password, loginVM.RememberMe, true);
             
            if (result.IsLockedOut)
            {
                ModelState.AddModelError(string.Empty, "Your account is locked out. Please try again later.");
                return View();
            }

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Username or Email or password is incorrect");
                return View();
            }

            if(returnURL == null)
            {
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            

            return Redirect(returnURL);


        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        //public async Task<IActionResult> CreateRoles()
        //{
        //    foreach (UserRoles item in Enum.GetValues(typeof(UserRoles)))
        //    {
        //        if (!await _roleManager.RoleExistsAsync(item.ToString())) 
        //        {
        //            await _roleManager.CreateAsync(new IdentityRole { Name = item.ToString() });
        //        }
        //    }
        //    return RedirectToAction(nameof(HomeController.Index), "Home");
        //}
    }
}
