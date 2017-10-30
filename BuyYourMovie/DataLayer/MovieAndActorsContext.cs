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

        public IEnumerable<MovieWithActorModel> getMoviesAndActors(MovieAndActorsContext _context, ActorsContext _actorContext, MoviesContext _movieContext)
        {
            List<MovieWithActorModel> m = new List<MovieWithActorModel>();
            var result = from movieAndActors in _context.MovieAndActors
                         join actor in _actorContext.Actors on movieAndActors.idActor equals actor.id
                         join movie in _movieContext.Movies on movieAndActors.idMovie equals movie.id
                         select new
                         {
                             idActor = actor.id,
                             actorName = actor.actorName,
                             actorRole = actor.actorRole,
                             idMovie = movie.id,
                             movieName = movie.movieName,
                             movieGender = movie.movieGender
                         };

            if (result != null)
            {
                foreach (var r in result)
                {
                    MovieWithActorModel temp = new MovieWithActorModel
                        (
                            r.idActor,
                            r.actorName,
                            r.actorRole,
                            r.idMovie,
                            r.movieName,
                            r.movieGender
                        );
                    m.Add(temp);
                }
            }

            return m;
        }

    public MovieWithActorModel getMoviesAndActorsById(int id, MovieAndActorsContext _context, ActorsContext _actorContext, MoviesContext _movieContext)
    {
        MovieWithActorModel m = null;
        var result = from movieAndActors in _context.MovieAndActors
                     join actor in _actorContext.Actors on movieAndActors.idActor equals actor.id
                     join movie in _movieContext.Movies on movieAndActors.idMovie equals movie.id
                     where movie.id == id 
                     select new
                     {
                         idActor = actor.id,
                         actorName = actor.actorName,
                         actorRole = actor.actorRole,
                         idMovie = movie.id,
                         movieName = movie.movieName,
                         movieGender = movie.movieGender
                     };

        if (result != null)
        {
            foreach (var r in result)
            {
                m = new MovieWithActorModel
                    (
                        r.idActor,
                        r.actorName,
                        r.actorRole,
                        r.idMovie,
                        r.movieName,
                        r.movieGender
                    );
            }
        }

        return m;
    }
    }
    }

