using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BookStore.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Web;
using System.Data.Entity;
using BookStore.ViewModels;
using System.Net;
using BookStore.Context;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        //List<Book> bookModels;
        List<BookModel> books;
        BookContext db = new BookContext();
        ApplicationContext dbu = new ApplicationContext();

        [HttpGet]
        public async Task<ActionResult> Buy(int id)
        {
            return await Task.Run(() =>
            {
                ViewBag.BookId = id;
                return View();
            });
        }
        [HttpPost]
        public async Task<JsonResult> Buy(Purchase purchase)
        {
            return await Task.Run(() =>
            {
                if (purchase == null) { return Json(BadRequest()); }
                else
                {
                    purchase.Date = DateTime.Now;
                    db.Purchases.Add(purchase);
                  
                    int count = db.Books.FirstOrDefault(p => p.Id == purchase.BookId).Count;
                    db.Books.FirstOrDefault(p => p.Id == purchase.BookId).Count = (count - 1);
                    db.SaveChanges();

                    return Json(Ok());
                    //return Json(purchase);

                }
            });
        }

        public async Task<ActionResult> Index()
        {
            //IEnumerable<Book> books = await db.Books.OrderBy(p => p.Price).ToListAsync();
            return await Task.Run(() =>
            {
                List<BookModel> books = db.Books
               .Select(c => new BookModel { Id = c.Id, Name = c.Name, Author = c.Author, Price = c.Price, Count = c.Count })
               .OrderBy(p => p.Price)
               .ToList();

                ViewBag.Books = books;
                return View();
            });
        }

    }
}
