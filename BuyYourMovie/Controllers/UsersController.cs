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
        UserData data;

        public UsersController(IConfiguration _configuration)
        {
            configuration = _configuration;
            data = new UserData(configuration);
        }
        // GET: api/users
        [Route("token")]
        [HttpGet("{token}")]
        public User Get(string token)
        {   return data.GetByToken(token);  }

        // GET api/users/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/users
        [HttpPost]
        public User Post([FromBody]User value)
        {   return (data.Post(value)) ? data.GetByToken(value.userEmail) : null;   }

        // PUT api/users/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
