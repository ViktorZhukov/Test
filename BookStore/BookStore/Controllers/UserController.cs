using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class UserController : Controller
    {
        ApplicationContext dbu = new ApplicationContext();
        public IActionResult Index()
        {
            return View();
        }

        public JsonResult Add(ApplicationUser user)
        {
            dbu.Users.Add(user);
            dbu.SaveChanges();

            return Json(Ok());
        }

    }
}