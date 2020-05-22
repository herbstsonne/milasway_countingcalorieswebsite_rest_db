using System;
using System.Collections.Generic;
using System.Linq;
using MilasFitnessUI.Models;

namespace MilasFitnessUI.Services
{
    public class CountCalorieService
    {
        public List<FoodInDay> allFoodInDays;

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
