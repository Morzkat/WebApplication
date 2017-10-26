using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BuyYourMovie.Models;
using BuyYourMovie.DataLayer;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BuyYourMovie.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        IConfiguration configuration;
        MovieData data;

        public UsersController(IConfiguration _configuration)
        {
            configuration = _configuration;
            data = new MovieData(configuration);
        }
        // GET: api/values
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return data.GetAll();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public IEnumerable<Movie> Post([FromBody]string value)
        {
           

            return data.GetAll();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
