using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BuyYourMovie.Models;

namespace BuyYourMovie.DataLayer
{
    public class ActorContext : DbContext
    {
        public ActorContext(DbContextOptions<ActorContext> options) : base(options)
        {

        }

        public DbSet<ActorsModel> Actors { get; set; }
    }
}
