using System;
using System.Collections.Generic;
using System.Linq;
using CountingCalories.Domain.Entities;
using CountingCalories.Infrastructure;
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
                return null;
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

        //api/countcalorie/id
        [HttpPut("{id}")]
        public void Put(List<FoodEntryEntity> foodEntries)
        {
            if (!foodEntries.Any())
                return;
            var foodInDay = _db.FoodInDays.FirstOrDefault(f => f.Day == DateTime.Now.Date.ToString("dd.MM.yyyy"));//Repo!! Struktur refactorn
            if(foodInDay == null)
                return;
            foodInDay.AllFoodEntries = foodEntries;
            _db.SaveChanges();
        }
    }
}
