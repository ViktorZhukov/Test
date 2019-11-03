using BookStore.Models;
using System.Data.Entity;

namespace BookStore.Context
{
    public class PurchaceContext : DbContext//работа с БД (создаем контекст)
    {        
        public DbSet<Purchase> Purchases { get; set; }//получаем коллекцию Покупок из БД



    }
}
