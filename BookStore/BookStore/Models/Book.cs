using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Book
    {
       public int Id { get;set; }//Primary Key
        public string Name { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
    }
}
