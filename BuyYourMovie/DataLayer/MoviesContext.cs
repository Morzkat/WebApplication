using Microsoft.EntityFrameworkCore;
using BuyYourMovie.Models;

namespace BuyYourMovie.DataLayer
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options) : base(options)
        {

        }

        public DbSet<MoviesModel> Movies { get; set; }
    }
}
