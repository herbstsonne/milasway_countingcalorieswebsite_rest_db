using System;
using System.Collections.Generic;
using System.Linq;
using CountingCalories.Models;

namespace CountingCalories.Services
{
    public class CountCalorieService
    {
        public List<FoodInDay> AllFoodInDays;

        public CountCalorieService()
        {
            AllFoodInDays = new List<FoodInDay>();
        }

        public void AddFoodOfDay(FoodInDay food)
        {
            AllFoodInDays.Add(food);
        }

        public FoodInDay GetFoodOfDay(DateTime date)
        {
            return AllFoodInDays.FirstOrDefault(f => f.Day.Equals(date));
        }
    }
}