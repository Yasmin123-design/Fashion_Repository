using ClothesStore.Models;
using ClothesStore.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ClothesStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> User;
        private readonly SignInManager<ApplicationUser> sign;
        public AccountController(UserManager<ApplicationUser> user , SignInManager<ApplicationUser> signIn)
        {
            User = user;
            sign = signIn;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser application = new ApplicationUser {
                    Address = register.Address,
                    UserName = register.UserName,
                    PasswordHash = register.Password,
                    Age = register.Age
                };
                // save in db
                IdentityResult result = await User.CreateAsync(application, register.Password);
                if(result.Succeeded)
                {
                    // create cookie
                    await sign.SignInAsync(application, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

            }
            return View(register);
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Login(LoginVM register)
        {
            if(ModelState.IsValid)
            {
                ApplicationUser application = await User.FindByNameAsync(register.UserName);
                if(application != null)
                {
                    bool found = await User.CheckPasswordAsync(application, register.Password);
                    if(found)
                    {
                        // create cookie
                        await sign.SignInAsync(application, false);
                        return RedirectToAction("Index", "Home");
                    }
                }
                ModelState.AddModelError("", "username or password not correct");
            }
            return View(register);
        }
        public IActionResult Logout()
        {
            sign.SignOutAsync();
            return RedirectToAction("Register");
        }



        public IActionResult Index()
        {
            return View();
        }
    }
}
