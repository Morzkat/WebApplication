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
        [HttpGet("{user, pw}")]
        public User Get(string user, string pw)
        {   return data.GetByToken(user, pw);  }
        
        // POST api/users
        [HttpPost]
        public User Post([FromBody]User value)
        {   return (data.Post(value)) ? data.GetByToken(value.userEmail, value.userPw) : null;   }

        // PUT api/users/5
        [HttpPut("{id}")]
        public User Put(int id, [FromBody]User value)
        {   return (data.Put(value, id) ? data.GetByToken(value.userEmail, value.userPw) : null);   }

        // DELETE api/users/5
        [HttpDelete("{id}")]
        public Boolean Delete(int id)
        { return data.DeleteById(id); }
    }
}
