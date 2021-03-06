﻿using System.ComponentModel.DataAnnotations;

//Users model
namespace BuyYourMovie.Models
{
    public class Movie : ModelsClass
    {
        public Movie(int id, string movieName, string movieSiponis, string movieGender, string moviePublished, string image, int starts)
        {
            this.id = id;
            this.movieName = movieName;
            this.movieSipnosis = movieSiponis;
            this.movieGender = movieGender;
            this.moviePublished = moviePublished;
            this.image = image;
            this.starts = starts;
        }
        
        //movie params
        [Key]
        public int id { get; set; }
        public string movieName { get; set; }
        public string movieSipnosis { get; set; }
        public string movieGender { get; set; }
        public string moviePublished { get; set; }
        public int starts { get; set; }
        public string image { get; }
    }
}
