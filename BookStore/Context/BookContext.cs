﻿using BookStore.Models;
using System.Data.Entity;

namespace BookStore.Context
{
    public class BookContext : DbContext//работа с БД (создаем контекст)
    {
        public DbSet<Book> Books { get; set; }//получаем коллекцию Книг из БД
        public DbSet<Purchase> Purchases { get; set; }//получаем коллекцию Покупок из БД



    }
}
