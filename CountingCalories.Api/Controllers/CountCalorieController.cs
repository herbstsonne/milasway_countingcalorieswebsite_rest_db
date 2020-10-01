using System;
using CountingCalories.Domain.Repository.Contract;
using CountingCalories.Shared.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CountingCalories.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountCalorieController : Controller
    {
        private readonly ICountCalorieRepository _dao;

        public CountCalorieController(ICountCalorieRepository dao)
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
        [HttpGet]
        public int Get()
        {
            return _dao.GetFoodEntryIdOfLastEntry();
        }

        //api/countcalorie/foodperday
        [HttpPost("{foodPerDay}")]
        public IActionResult Post(FoodPerDayView foodPerDay)
        {
            var count = _dao.AddFoodPerDay(foodPerDay);
            if (count == 0)
                throw new ArgumentException($"{foodPerDay.Day} could not be saved.");
            return Ok();
        }

        //api/countcalorie
        [HttpPut]
        public IActionResult Put(FoodEntryView foodEntry)
        {
            var count =_dao.AddFoodEntry(foodEntry);
            if (count == 0)
                throw new ArgumentException($"{foodEntry.FoodName} could not be updated.");
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var count = _dao.DeleteFoodEntry(id);
            if (count == 0)
                throw new ArgumentException($"{id} could not be deleted.");
            return Ok();
        }
    }
}
