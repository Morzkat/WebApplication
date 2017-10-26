using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using BuyYourMovie.DataLayer;
using BuyYourMovie.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BuyYourMovie.Controllers
{
  
    [Route("api/[controller]")]
    public class MoviesController : Controller
    {
        IConfiguration configuration;
        protected MovieData data;
        public MoviesController(IConfiguration _configuration)
        {
            configuration = _configuration;
            data = new MovieData(configuration);
        }

        // GET: api/movies
        [HttpGet]
        public IEnumerable<Movie> Get()
        {   return data.GetAll();  }

        // GET api/movies/5
        [HttpGet("{id}")]
        public Movie Get(int id)
        {   return data.GetById(id);    }

        // GET api/movies/5
        [Route("ByMovieName")]
        [HttpGet("{movieName}")]
        public IEnumerable<Movie> Get(string movieName)
        {    return data.GetByMovieName(movieName);    }


        // POST api/movies
        [HttpPost]
        public void Post([FromBody]Movie value)
        {
            Movie m = new Movie(1, "pelicula", "asdsadsadsad", "aaaa", "2015/05/26", "asdasd", 5);
            data.Post(m);
        }

        // PUT api/movies/5
        [HttpPut("{id}")]
        public bool Put(int id, [FromBody]Movie value)
        {
            return true;
        }

        // DELETE api/movies/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
