using System.Collections.Generic;
using System.Linq;
using CountingCalories.Domain.Entities;
using CountingCalories.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace CountingCalories.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private CountingCaloriesContext _db;

        public FoodController(CountingCaloriesContext db)
        {
            _db = db;
        }

        // GET: api/<FoodController>
        [HttpGet]
        public IEnumerable<FoodEntity> Get()
        {
            var allFood = from f in _db.Food select f;
            return allFood;
        }

        // GET api/<FoodController>/5
        [HttpGet("{name}")]
        public FoodEntity Get(string name)
        {
            return _db.Food.FirstOrDefault(f => f.Name == name);
        }

        // POST api/<FoodController>
        [HttpPost]
        public void Post(FoodEntity food)
        {
            _db.Food.Add(food);
            _db.SaveChanges();
        }

        // PUT api/<FoodController>
        [HttpPut]
        public void Put(List<FoodEntity> allFood)
        {
            _db.Food.UpdateRange(allFood);
            _db.SaveChanges();
        }

        // DELETE api/<FoodController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var food = _db.Food.Find(id);
            _db.Food.Remove(food);
            _db.SaveChanges();
        }
    }
}
