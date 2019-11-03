namespace BookStore.Migrations
{
    using BookStore.Context;
    using BookStore.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
        /*
        protected override void Seed(BookContext context)
        {
            var Books = new List<Book> {

            new Book { Name = "Война и мир", Author = "Л. Толстой", Price = 220, Count = 3 },
            new Book { Name = "Отцы и дети", Author = "И. Тургенев", Price = 180, Count = 2 },
            new Book { Name = "Чайка", Author = "А. Чехов", Price = 150, Count = 1 }
            };
            context.SaveChanges();
        }*/
    }
}
