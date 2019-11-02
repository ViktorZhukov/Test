using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.ViewModels
{
    public class BookModel
    {
        public int Id { get; set; }//Primary Key
        public string Name { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }

        public int Count { get; set; }
    }
}
