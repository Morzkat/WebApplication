using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using BuyYourMovie.DataLayer;
using BuyYourMovie.Models;

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

        // GET api/movies/ByGender?movieGender
        [Route("ByGender")]
        [HttpGet("{movieGender}")]
        public IEnumerable<Movie> Get(string movieGender)
        {    return data.GetByGender(movieGender);    }

        // POST api/movies
        [HttpPost]
        public Boolean Post([FromBody]Movie value)
        {   return data.Post(value);   }

        // PUT api/movies/5
        [HttpPut("{id}")]
        public Boolean Put(int id, [FromBody]Movie value)
        {   return data.Put(value, id);    }

        // DELETE api/movies/5
        [HttpDelete("{id}")]
        public Boolean Delete(int id)
        {
            return data.DeleteById(id);
        }
    }
}
