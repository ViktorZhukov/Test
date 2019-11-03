using BookStore.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Owin.Security;
using System;
using System.Security.Claims;
using System.Threading.Tasks;


namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext db = new ApplicationContext();

        //private readonly UserManager<ApplicationUser> userManager;

        private readonly ApplicationUser _user;

        //  private ApplicationUserManager _userManager;
        /* public HomeController()
               : this(new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new IdentityDbContext())))
         {
         }

         public HomeController(UserManager<ApplicationUser> userManager)
         {
             _userManager = userManager;
         }
         */
        public UserManager<ApplicationUser> _userManager;



        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                };

                IdentityResult result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("Хуй", error);
                    }
                }
            }
            return View(model);
        }

        //////////////////////////////////////////    LOGIN         /////////////////////////////////////////////////////

        private readonly IAuthenticationManager AuthenticationManager;


        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await _userManager.FindAsync(model.Email, model.Password);
                if (user == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    ClaimsIdentity claim = await _userManager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    if (String.IsNullOrEmpty(returnUrl))
                        return RedirectToAction("Index", "Home");
                    return Redirect(returnUrl);
                }
            }
            ViewBag.returnUrl = returnUrl;
            return View(model);
        }
        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login");
        }
        [HttpGet]
        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed()
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(_user.Name);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Logout", "Account");
                }
            }
            return RedirectToAction("Index", "Home");
        }
        /// ////////////////////////////////////////////  EDIT    //////////////////////////////////////////////////////

        public async Task<ActionResult> Edit()
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(_user.Name);
            if (user != null)
            {
                EditModel model = new EditModel { Cash = user.Cash };
                return View(model);
            }
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public async Task<ActionResult> Edit(EditModel model)
        {
            ApplicationUser user = await _userManager.FindByEmailAsync(_user.Name);
            if (user != null)
            {
                user.Cash = model.Cash;
                IdentityResult result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Что-то пошло не так");
                }
            }
            else
            {
                ModelState.AddModelError("", "Пользователь не найден");
            }

            return View(model);
        }
    }
}