using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BuyYourMovie.Models
{
    public class MovieWithActorModel
    {
        public MovieWithActorModel(int idActor, string actorName, string actorRole, int idMovie, string movieName, string movieGender)
        {
            this.idActor = idActor;
            this.actorName = actorName;
            this.actorRole = actorRole;

            this.idMovie = idMovie;
            this.movieName = movieName;
            this.movieGender = movieGender;
        }

        public int idActor { get; set; }
        public string actorName { get; set; }
        public string actorRole { get; set; }
        public int idMovie { get; set; }
        public string movieName { get; set; }
        public string movieGender { get; set; }


    }
}
