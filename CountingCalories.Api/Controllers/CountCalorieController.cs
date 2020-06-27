using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        //api/countcalorie/{datetime}
        [HttpGet]
        public FoodInDay Get(DateTime date)
        {
            return _db.FoodInDays.FirstOrDefault(f => f.Day.Equals(date));
        }

        //api/countcalorie/id
        [HttpPost("{id}")]
        public void Post(FoodInDay food)
        {
            _db.FoodInDays.Add(food);
            _db.SaveChanges();
        }
    }
}
