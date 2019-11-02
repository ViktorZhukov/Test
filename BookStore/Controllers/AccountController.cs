using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Owin.Host.SystemWeb;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Http;
using System.Web.Http.Owin;

using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

using Microsoft.Owin.Host.SystemWeb;


namespace BookStore.Controllers
{
    public class AccountController : Controller
    {

        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext()
                    .GetUserManager<ApplicationUserManager>();
            }
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                IdentityResult result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }
            }
            return View(model);
        }
    }
}