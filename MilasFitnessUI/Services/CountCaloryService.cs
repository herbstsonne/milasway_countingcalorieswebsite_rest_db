using System;
using System.Collections.Generic;
using System.Linq;
using MilasFitnessUI.Models;

namespace MilasFitnessUI.Services
{
    public class CountCaloryService
    {
        public List<FoodInDay> allFoodInDays;

        public CountCaloryService()
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
