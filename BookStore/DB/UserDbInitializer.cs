using BookStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.DB
{
    public class UserDbInitializer : DropCreateDatabaseAlways<ApplicationContext>
    {
        protected override void Seed(ApplicationContext dbu)
        {
            dbu.Users.Add(new ApplicationUser { Name = "Admin", Password = "Admin", Cash = 100 });
            base.Seed(dbu);
        }

    }
}
