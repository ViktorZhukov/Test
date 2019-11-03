using System;

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
