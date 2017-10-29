using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BuyYourMovie.Models;

namespace BuyYourMovie.DataLayer 
{
    public class MovieAndActorsContext : DbContext
    {
        public MovieAndActorsContext(DbContextOptions<MovieAndActorsContext> options) : base(options)
        {

        }

        public DbSet<MovieAndActorsModel> MovieAndActors { get; set; }
    }
}
