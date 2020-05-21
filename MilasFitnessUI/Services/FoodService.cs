using System.Collections.Generic;
using MilasFitnessUI.Models;

namespace MilasFitnessUI.Services
{
    public class FoodService
    {
        public List<Food> allFood { get; set; }

        public FoodService()
        {
            allFood = new List<Food>();
        }

        public void SaveFood(Food food)
        {
            allFood.Add(food);
            //RestAPI Call
        }

        public List<Food> GetAllFood()
        {
            return allFood;
        }
    }
}
