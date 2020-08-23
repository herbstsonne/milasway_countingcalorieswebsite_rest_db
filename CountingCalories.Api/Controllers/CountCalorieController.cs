using System;
using CountingCalories.Domain.Repository.Contract;
using CountingCalories.Domain.ViewModels;
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
            try
            {
                _dao.AddFoodPerDay(foodPerDay);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        //api/countcalorie
        [HttpPut]
        public IActionResult Put(FoodEntryView foodEntry)
        {
            try
            {
                _dao.AddFoodEntry(foodEntry);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _dao.DeleteFoodEntry(id);
                return Ok();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                return BadRequest();
            }
        }
    }
}
