using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WAM_SocialMediaSite_02.Models;

namespace WAM_SocialMediaSite_02.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<PostClass> posts { get; set; }
        public DbSet<User> users { get; set; }
    }
}