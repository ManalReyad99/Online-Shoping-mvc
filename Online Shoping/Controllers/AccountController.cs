using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Online_Shoping.Models;
using Online_Shoping.ViewModels;
using System.Threading.Tasks;

namespace Online_Shoping.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(AccountRegisterViewModel newuser)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = newuser.username;
                user.PasswordHash = newuser.password;
                user.Address = newuser.Address;

             IdentityResult result= await userManager.CreateAsync(user, user.PasswordHash);
                if(result.Succeeded)
                {

                    await signInManager.SignInAsync(user,false);
                    return RedirectToAction("index", "Home");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }

                }

            }
            return View(newuser);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Register");
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AccountLoginViewModel loginAccount)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await userManager.FindByNameAsync(loginAccount.username);
                if(user !=null)
                {
                   Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user, loginAccount.password, loginAccount.isPresist, false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "password is invaild");


                    }
                }
                else
                {
                    ModelState.AddModelError("", "Username is invaild");
                }
            }
            return View(loginAccount);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult RegisterAdmin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> RegisterAdmin(AccountRegisterViewModel newuser)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = newuser.username;
                user.PasswordHash = newuser.password;
                user.Address = newuser.Address;

                IdentityResult result = await userManager.CreateAsync(user, user.PasswordHash);
                if (result.Succeeded)
                {
                  IdentityResult roleresult= await userManager.AddToRoleAsync(user, "Admin");
                    if (roleresult.Succeeded)
                    {
                        await signInManager.SignInAsync(user, false);
                        return RedirectToAction("index", "Home");
                    }
                    else
                    {
                        foreach (var item in roleresult.Errors)
                        {
                            ModelState.AddModelError("", item.Description);
                        }
                    }
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }

                }

            }
            return View(newuser);
        }

    }
}
