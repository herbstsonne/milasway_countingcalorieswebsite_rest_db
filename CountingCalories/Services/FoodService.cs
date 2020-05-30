using System.Collections.Generic;
using CountingCalories.Models;

namespace CountingCalories.Services
{
    public class FoodService
    {
        private List<Food> allFood;

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
