using Microsoft.EntityFrameworkCore;
using BuyYourMovie.Models;

namespace BuyYourMovie.DataLayer
{
    public class ActorsContext : DbContext
    {
        public ActorsContext(DbContextOptions<ActorsContext> options) : base(options)
        {

        }

        public DbSet<ActorsModel> Actors { get; set; }
    }
}
