using CountingCalories.Domain.Services.Interfaces;
using CountingCalories.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CountingCalories.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountCalorieController : Controller
    {
        private readonly IFoodPerDayApiService _countCaloriesService;

        public CountCalorieController(IFoodPerDayApiService countCaloriesService)
        {
            _countCaloriesService = countCaloriesService;
        }

        //api/countcalorie/dd.MM.yyyy
        [HttpGet("{date}")]
        public FoodPerDayView Get(string date)
        {
            return _countCaloriesService.GetFoodPerDayByDate(date);
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
        public IActionResult Put(FoodPerDayView foodPerDay)
        {
            _countCaloriesService.UpdateFoodPerDay(foodPerDay);
            return Ok();
        }
    }
}
