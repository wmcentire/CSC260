using Microsoft.EntityFrameworkCore;
using GameLibrary.Models;

namespace GameLibrary.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        //will create movies table in the db using Movie.cs model
        public DbSet<Game> games { get; set; }
    }
}
