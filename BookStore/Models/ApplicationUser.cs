using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public int Cash { get; set; }
        public ApplicationUser()
        {
        }
    }
}
