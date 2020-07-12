using System;
using System.Collections.Generic;
using System.Linq;
using CountingCalories.UI.Models;
using EFGetStarted;
using Microsoft.AspNetCore.Mvc;

namespace CountingCalories.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountCalorieController : Controller
    {
        private CountingCaloriesContext _db;

        public CountCalorieController(CountingCaloriesContext db)
        {
            _db = db;
        }

        //api/countcalorie/dd.mm.yyyy
        [HttpGet("{date}")]
        public FoodPerDayEntity Get(string date)
        {
            var foodInDay = _db.FoodInDays.FirstOrDefault(f => f.Day.Equals(date));
            if (foodInDay == null)
                return new FoodPerDayEntity() { AllFoodEntries = new List<FoodEntryEntity>(), Day = DateTime.Now.ToString("dd.MM.yyyy") };
            var foodEntries = _db.FoodEntries.AsEnumerable().Where(e => e.FoodInDayId == foodInDay.Id).ToList();           
            foodInDay.AllFoodEntries = foodEntries;
            return foodInDay;
        }

        //api/countcalorie/id
        [HttpPost("{id}")]
        public void Post(FoodPerDayEntity food)
        {
            _db.FoodInDays.Add(food);
            _db.SaveChanges();
        }
        
        //api/countcalorie
        [HttpPost]
        public void Post(List<FoodEntryEntity> foodEntries)
        {
            _db.FoodEntries.AddRange(foodEntries);
            _db.SaveChanges();
        }
    }
}
