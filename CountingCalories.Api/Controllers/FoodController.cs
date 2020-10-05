using System.Collections.Generic;
using CountingCalories.Domain.Repository.Contract;
using CountingCalories.Domain.Services.Interfaces;
using CountingCalories.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CountingCalories.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IFoodApiService _foodService;

        public FoodController(IFoodApiService foodService)
        {
            _foodService = foodService;
        }

        // GET: api/<FoodController>
        [HttpGet]
        public IEnumerable<FoodView> Get()
        {
            return _foodService.GetAllFood();
        }

        // GET api/<FoodController>/5
        [HttpGet("{name}")]
        public FoodView Get(string name)
        {
            return _foodService.GetFoodByName(name);
        }

        // POST api/<FoodController>
        [HttpPost]
        public void Post(FoodView food)
        {
            _foodService.AddFood(food);
        }

        // PUT api/<FoodController>
        [HttpPut]
        public void Put(List<FoodView> allFood)
        {
            _foodService.UpdateAllFood(allFood);
        }

        // DELETE api/<FoodController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _foodService.DeleteFoodById(id);
        }
    }
}
