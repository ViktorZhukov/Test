using BookStore.Context;
using BookStore.Models;
using BookStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Controllers
{
    public class BuyController : Controller
    {

        BookContext db = new BookContext();
        PurchaceContext dbp = new PurchaceContext();

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.BookId = id;
            return View();

        }
        [HttpPost]
        public StatusCodeResult Buy(Purchase purchase)
        {

            if (purchase == null) { return BadRequest(); }
            else
            {
                purchase.Date = DateTime.Now;
                dbp.Purchases.Add(purchase);

                Book book = db.Books.Find(purchase.BookId);
                book.Count--;
                //int count = db.Books.FirstOrDefault(p => p.Id == purchase.BookId).Count;
                // db.Books.FirstOrDefault(p => p.Id == purchase.BookId).Count = (count - 1);
                db.SaveChanges();//книги

                dbp.SaveChanges();//заказы

                return Ok();
                //return Json(purchase);

            }

        }
        public ActionResult Index()
        {
            //IEnumerable<Book> books = await db.Books.OrderBy(p => p.Price).ToListAsync();

            List<BookModel> books = db.Books
           .Select(c => new BookModel
           {
               Id = c.Id,
               Name = c.Name,
               Author = c.Author,
               Price = c.Price,
               Count = c.Count
           })
           .ToList();

            ViewBag.Books = books;
            return View();

        }

    }
}
