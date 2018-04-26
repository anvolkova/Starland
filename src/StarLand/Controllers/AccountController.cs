using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using StarLand.Models;
using StarLand.Services;
using StarLand.ViewModels;

namespace StarLand.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> _userManagerService;
        private SignInManager<IdentityUser> _signinManagerService;
        private RoleManager<IdentityRole> _roleManagerService;
        private IDataService<Profile> _profileDataService;

        public AccountController(UserManager<IdentityUser> userManagerService,
            SignInManager<IdentityUser> signinManagerService,
            RoleManager<IdentityRole> roleManagerService,
            IDataService<Profile> profileService)
        {
            _userManagerService = userManagerService;
            _signinManagerService = signinManagerService;
            _roleManagerService = roleManagerService;
            _profileDataService = profileService;
        }
       
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(AccountRegisterViewModel vm)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser(vm.Username);
                user.Email = vm.Email;
                IdentityResult result = await _userManagerService.CreateAsync(user, vm.Password);
                if (result.Succeeded)
                {
                    await _userManagerService.AddToRoleAsync(user, "Customer");
                    Profile newProfile = new Profile {
                        Username = vm.Username,
                        Email = vm.Email 
                    };
                    _profileDataService.Create(newProfile);
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(vm);
        }
       
        [HttpGet]
        public IActionResult Login(string returnUrl = "")
        {
            AccountLoginViewModel vm = new AccountLoginViewModel
            {
                ReturnUrl = returnUrl
            };
            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(AccountLoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var result = await _signinManagerService.PasswordSignInAsync(vm.Username, vm.Password, false, false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(vm.ReturnUrl))
                    {
                        return Redirect(vm.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            ModelState.AddModelError("", "User name or Password is incorrect");
            return View(vm);
        }
                
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signinManagerService.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }     
      
    }
}
