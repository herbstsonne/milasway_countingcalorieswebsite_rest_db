using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CountingCalories.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CountingCalories.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        // GET: api/<FoodController>
        [HttpGet]
        public IEnumerable<Food> Get()
        {
            return null;
        }

        // GET api/<FoodController>/5
        [HttpGet("{id}")]
        public Food Get(int id)
        {
            return null;
        }

        // POST api/<FoodController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FoodController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FoodController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
