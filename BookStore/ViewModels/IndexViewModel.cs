using BookStore.Context;
using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.ViewModels
{
    public class IndexViewModel
    {
        private readonly BookContext db;
        public IEnumerable<Book> Books { get; set; }
        public IEnumerable<BookModel> bookModels { get; set; }

    }
}
