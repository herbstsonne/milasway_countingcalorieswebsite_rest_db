using CountingCalories.UI.Models;
using CountingCalories.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountingCalories.UI.ViewModels
{
    public class ViewFoodEntry
    {
        private FoodEntry _foodEntry;
        private List<Food> _allFood;

        public ViewFoodEntry(FoodEntry foodEntry, List<Food> allFood)
        {
            _foodEntry = foodEntry;
            _allFood = allFood;
        }

        public Food Food
        {
            get {
                return _allFood.FirstOrDefault(f => f.Id == _foodEntry.FoodId);
            }
            set {
                _foodEntry.FoodId = value.Id;
                _foodEntry.FoodName = value.Name;
            }
        }
        public int Amount 
        {
            get
            {
                return _foodEntry.Amount;
            }
            set {
                _foodEntry.Amount = value;
            }
        }

        public int Calories
        {
            get
            {
                return _foodEntry.Calories;
            }
            set
            {
                _foodEntry.Calories = value;
            }
        }
    }
}
