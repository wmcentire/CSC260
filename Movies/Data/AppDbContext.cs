using Microsoft.EntityFrameworkCore;
using Movies.Models;

namespace Movies.Data

{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        //will create movies table in the db using Movie.cs model
        public DbSet<Movie> Movies { get; set; }
    }
}
