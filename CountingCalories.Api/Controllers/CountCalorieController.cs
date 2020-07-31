using System;
using System.Collections;
using System.Collections.Generic;
using CountingCalories.Domain.Repository.Contract;
using CountingCalories.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
    }
}
