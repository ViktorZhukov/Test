using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }//Primary Key
        public string Person { get; set; }
        public string Adress { get; set; }
        public int BookId { get; set; }//Primary Key
        public DateTime Date { get; set; }
    }
}
