using System.Collections.Generic;
using CountingCalories.Models;

namespace CountingCalories.Services
{
    public class FoodService
    {
        private List<Food> AllFood { get; set; }

        public FoodService()
        {
            AllFood = new List<Food>();
        }

        public void SaveFood(Food food)
        {
            AllFood.Add(food);
            //RestAPI Call
        }

        public List<Food> GetAllFood()
        {
            return AllFood;
        }
    }
}