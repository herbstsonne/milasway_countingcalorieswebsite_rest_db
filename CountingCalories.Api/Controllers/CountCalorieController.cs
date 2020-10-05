using CountingCalories.Domain.Services.Interfaces;
using CountingCalories.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CountingCalories.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountCalorieController : Controller
    {
        private readonly ICountingCaloriesApiService _countCaloriesService;

        public CountCalorieController(ICountingCaloriesApiService countCaloriesService)
        {
            _countCaloriesService = countCaloriesService;
        }

        //api/countcalorie/dd.MM.yyyy
        [HttpGet("{date}")]
        public FoodPerDayView Get(string date)
        {
            return _countCaloriesService.GetFoodPerDayByDate(date);
        }

        //api/countcalorie
        [HttpGet]
        public int Get()
        {
            return _countCaloriesService.GetFoodEntryIdOfLastEntry();
        }

        //api/countcalorie/foodperday
        [HttpPost("{foodPerDay}")]
        public IActionResult Post(FoodPerDayView foodPerDay)
        {
            _countCaloriesService.AddFoodPerDay(foodPerDay);
            return Ok();
        }

        //api/countcalorie
        [HttpPut]
        public IActionResult Put(FoodEntryView foodEntry)
        {
            _countCaloriesService.AddFoodEntry(foodEntry);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _countCaloriesService.DeleteFoodEntry(id);
            return Ok();
        }
    }
}
