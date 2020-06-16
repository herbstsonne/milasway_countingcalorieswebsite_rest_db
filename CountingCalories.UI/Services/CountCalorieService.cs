using System;
using System.Collections.Generic;
using System.Linq;
using CountingCalories.UI.Models;

namespace CountingCalories.UI.Services
{
    public class CountCalorieService
    {
        private List<FoodInDay> allFoodInDays;

        public CountCalorieService()
        {
            allFoodInDays = new List<FoodInDay>();
        }

        public void AddFoodOfDay(FoodInDay food)
        {
            allFoodInDays.Add(food);
        }
        public FoodInDay GetFoodOfDay(DateTime date)
        {
            return allFoodInDays.FirstOrDefault(f => f.Day.Equals(date));
        }
    }
}
