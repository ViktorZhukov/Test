using BookStore.Models;
using System.Collections.Generic;

namespace BookStore.ViewModels
{
    public class ApplicationUserViewModel
    {
        private readonly ApplicationContext db;
        public IEnumerable<ApplicationUser> Users { get; set; }
    }
}
