using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Sapnil.Data;


namespace Sapnil.Controllers
{
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _siginManager;

        public AdminController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _siginManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if(ModelState.IsValid)
            {
               IdentityUser newUser = new IdentityUser {
                   UserName = model.Email,
                   Email = model.Email
               };

               IdentityResult result = await _userManager.CreateAsync(newUser, model.Password);

               if(result.Succeeded)
               {
                   await _siginManager.SignInAsync(newUser, isPersistent:false);
                   return RedirectToAction("Create", "Sale");
               }

               foreach(var error in result.Errors)
               {
                   ModelState.AddModelError("", error.Description);
               }
            }
            return View(model);

        }
        public IActionResult Login( string ReturnUrl)
        {
            LoginVM model = new LoginVM {
                ReturnUrl = ReturnUrl
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if(ModelState.IsValid)
            {
                var result = await _siginManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe,false);
                if(result.Succeeded)
                {
                    if(!string.IsNullOrEmpty(model.ReturnUrl))
                    {
                        return LocalRedirect(model.ReturnUrl);
                    }
                    return RedirectToAction("Create","Sale");
                }
                ModelState.AddModelError("","Invalid Login Info.");
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _siginManager.SignOutAsync();
            return RedirectToAction("Index","Home");

        }

    }
}