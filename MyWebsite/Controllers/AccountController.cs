using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyWebsite.Data;
using MyWebsite.Models;
using MyWebsite.ViewModels;
using System.Net.WebSockets;

namespace MyWebsite.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> signInManager;

        private readonly UserManager<AppUser> userManager;

        private readonly AppDbContext _context;

        public AccountController(SignInManager<AppUser> signInManager,UserManager<AppUser> userManager,AppDbContext context)
        {
           this.signInManager = signInManager;
            this.userManager = userManager;
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM model)
        {
            if(ModelState.IsValid)
            {
                // Login
                var result = await signInManager.PasswordSignInAsync(model.Username!, model.Password!, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("","Invalid Login");
                return View();
            }
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser()
                {
                    Name = registerVM.Name,
                    Email = registerVM.Email,
                    Address= "",
                    UserName=registerVM.Username,
                    CreatedDate = DateTime.Now
                };

                var result=await userManager.CreateAsync(user,registerVM.Password!);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Client");
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("",error.Description);
                }

                return  RedirectToAction("Index", "Home");
            }
            return View(registerVM);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }


        public async Task<IActionResult> Information()
        {
            var userID = userManager.GetUserId(User);
            var userDN=await userManager.FindByIdAsync(userID!);
            return View(new UserVM
            {
                ID= userDN!.Id,
                Name=userDN.Name,
                Email=userDN.Email,
                PhoneNumber=userDN.PhoneNumber,
                Address= userDN.Address,
                CreatedDate=userDN.CreatedDate,
                Password=userDN.PasswordHash,
                ImageUser=userDN.ImageUser
            });
        }
        public async Task<IActionResult> Edit()
        {
            var userID = userManager.GetUserId(User);
            var userDN = await userManager.FindByIdAsync(userID!);
            return View(new UserVM
            {
                ID = userDN!.Id,
                Name = userDN.Name,
                Email = userDN.Email,
                PhoneNumber = userDN.PhoneNumber,
                Address = userDN.Address,
                CreatedDate = userDN.CreatedDate,
                Password = userDN.PasswordHash,
                ImageUser = userDN.ImageUser
            });
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UserVM user)
        {
            var userID = userManager.GetUserId(User);
            var userDN = await userManager.FindByIdAsync(userID!);

            if (userDN == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                userDN.Name = user.Name;
                userDN.Email = user.Email;
                userDN.Address = user.Address;
                userDN.PhoneNumber = user.PhoneNumber;
                userDN.ImageUser = user.ImageUser;

                if (!string.IsNullOrEmpty(user.Password))
                {
                    if (userManager.PasswordHasher.VerifyHashedPassword(userDN, userDN.PasswordHash, user.Password) != PasswordVerificationResult.Success)
                    {
                        ModelState.AddModelError("", "Old password is incorrect");
                        return View(user);
                    }
                  
                    else
                    {
                        if(!string.IsNullOrEmpty(user.NewPassword))
                        {
                            var newPasswordHash = userManager.PasswordHasher.HashPassword(userDN, user.NewPassword);
                            userDN.PasswordHash = newPasswordHash;
                        }
                        else
                        {
                            ModelState.AddModelError("", "New password is required");
                            return View(user);
                        }
                        
                    }
                }

                var result = await userManager.UpdateAsync(userDN);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
                else
                {
                    return RedirectToAction("Information", "Account");
                }
            }
            return View(user);
        }


    }
}
