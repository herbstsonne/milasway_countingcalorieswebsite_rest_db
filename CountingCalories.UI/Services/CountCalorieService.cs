using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using CountingCalories.UI.Models;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

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
