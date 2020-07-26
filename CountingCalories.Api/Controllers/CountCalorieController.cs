using System.Collections.Generic;
using CountingCalories.Domain.Repository.Contract;
using CountingCalories.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CountingCalories.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountCalorieController : Controller
    {
        private readonly ICountCalorieRepositoryDao _dao;

        public CountCalorieController(ICountCalorieRepositoryDao dao)
        {
            _dao = dao;
        }

        //api/countcalorie/dd.MM.yyyy
        [HttpGet("{date}")]
        public FoodPerDayView Get(string date)
        {
            return _dao.GetFoodPerDayByDate(date);
        }

        //api/countcalorie
        [HttpPost("{foodPerDay}")]
        public void Post(FoodPerDayView foodPerDay)
        {
            _dao.AddFoodPerDay(foodPerDay);
        }

        //api/countcalorie
        [HttpPut]
        public void Put(Dictionary<FoodEntryView, string> foodEntries)
        {
            _dao.AddFoodEntries(foodEntries);
        }
    }
}
