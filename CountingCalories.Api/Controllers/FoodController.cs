using System.Collections.Generic;
using CountingCalories.Domain.Repository.Contract;
using CountingCalories.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CountingCalories.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodRepositoryDao _dao;

        public FoodController(IFoodRepositoryDao dao)
        {
            _dao = dao;
        }

        // GET: api/<FoodController>
        [HttpGet]
        public IEnumerable<FoodView> Get()
        {
            return _dao.GetAllFood();
        }

        // GET api/<FoodController>/5
        [HttpGet("{name}")]
        public FoodView Get(string name)
        {
            return _dao.GetFoodByName(name);
        }

        // POST api/<FoodController>
        [HttpPost]
        public void Post(FoodView food)
        {
            _dao.AddFood(food);
        }

        // PUT api/<FoodController>
        [HttpPut]
        public void Put(List<FoodView> allFood)
        {
            _dao.UpdateAllFood(allFood);
        }

        // DELETE api/<FoodController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _dao.DeleteFoodById(id);
        }
    }
}
