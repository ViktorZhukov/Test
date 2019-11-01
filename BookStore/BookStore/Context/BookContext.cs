using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using BookStore.Models;

namespace BookStore.Context
{
    public class BookContext : DbContext//работа с БД (создаем контекст)
    {
        public DbSet<Book> Books { get; set; }//получаем коллекцию Книг из БД
        public DbSet<Purchase> Purchases { get; set; }//получаем коллекцию Покупок из БД



    }
}
