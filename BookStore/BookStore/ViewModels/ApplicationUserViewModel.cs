using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.ViewModels
{
    public class ApplicationUserViewModel
    {
        private readonly ApplicationContext db;
        public IEnumerable<ApplicationUser> Users { get; set; }
    }
}
