using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProtocolSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using ProtocolSystem.Models.DB;
using System.Linq;

namespace ProtocolSystem.Controllers
{
    public class AccountController : Controller
    {
        private ProtocolSystemContext _context;
        public AccountController(ProtocolSystemContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(Users model)
        {
            if (ModelState.IsValid)
            {
                Users user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    user = model;
                    Roles userRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "Citizen");
                    if (userRole != null)
                        user.Role = userRole;

                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();

                    await Authenticate(user); 

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Некоректні логін і(або) пароль");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult RegisterPoliceman()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegisterPoliceman(Users model)
        {
            if (ModelState.IsValid)
            {
                Users user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    user = model;
                    Roles userRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "Policeman");
                    if (userRole != null)
                        user.Role = userRole;

                    _context.Users.Add(user);
                    await _context.SaveChangesAsync();

                    await Authenticate(user);

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Некоректні логін і(або) пароль");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                Users user = await _context.Users
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(user); 

                    return RedirectToAction("Welcome", "Home");
                }
                ModelState.AddModelError("", "Некоректні логін і(або) пароль");
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Welcome", "Home");
        }

        private async Task Authenticate(Users user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> ChangePass(int? id)
        {
            var user_email = User.Identity.Name;
            var user = _context.Users.FirstOrDefault(x => x.Email == user_email);

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePass(Users user)
        {
            var user_email = User.Identity.Name;
            var user_db = _context.Users.FirstOrDefault(x => x.Email == user_email);

            user_db.Password = user.Password;
            user_db.Name = user.Name;
            user_db.Surname = user.Surname;
            user_db.DrivingLicenceId = user.DrivingLicenceId;
            user_db.DateOfBirth = user.DateOfBirth;
            user_db.Citizenship = user.Citizenship;

            _context.Update(user_db);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}