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
        [HttpGet("{token}")]
        public User Get(string token)
        {
            string userEmail = "test@test.com";
            string userPw = "1234";
            return data.GetByUserNameAndPw(userEmail, userPw);
        }

        // GET api/users/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/users
        [HttpPost]
        public IEnumerable<User> Post([FromBody]string value)
        {
           

            return data.GetAll();
        }

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
