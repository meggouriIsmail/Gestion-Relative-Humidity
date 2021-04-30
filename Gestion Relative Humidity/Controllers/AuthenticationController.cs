using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Gestion_Relative_Humidity.ViewModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Relative_Humidity.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IUnitOfWork<User> _user;

        public AuthenticationController(IUnitOfWork<User> user)
        {
            _user = user;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserModel model, string returnUrl = null)
        {
            if (ModelState.IsValid)
            {
                if (ValidateUser(model))
                {
                    var claims = new List<Claim>
                    {
                        new Claim("user", model.Email),
                        new Claim("role", "user")
                    };

                    await HttpContext.SignInAsync(new ClaimsPrincipal(new ClaimsIdentity(claims, "Cookies", "user", "role")));

                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return Redirect("/humidity/index");
                    }
                }

                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
                }
            }

            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        private bool ValidateUser(UserModel model)
        {
            var users = _user.Entity.GetAll();

            foreach(var user in users)
            {
                if (user.Email == model.Email && user.Password == model.Password)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
