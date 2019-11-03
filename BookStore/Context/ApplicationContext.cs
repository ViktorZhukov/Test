using BookStore.Models;
using Microsoft.AspNet.Identity.EntityFramework;

public class ApplicationContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationContext() : base("IdentityDb") { }  
    public static ApplicationContext Create()
    {
        return new ApplicationContext();
    }
}