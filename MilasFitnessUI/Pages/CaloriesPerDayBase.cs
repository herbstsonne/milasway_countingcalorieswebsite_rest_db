using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using MilasFitnessUI.Models;
using MilasFitnessUI.Services;


namespace MilasFitnessUI.Pages
{
    public class CaloriesPerDayBase : ComponentBase
    {
        public string Name { get; set; }
        public FoodInDay FoodToday { get; set; }
        public List<Food> AllExistingFood { get; set; }
        public FoodEntry FoodEntry { get; set; }
        public string CurrentDate { get; set; }

        [Inject]
        public CountCalorieService _CalorieService { get; set; }

        [Inject]
        public FoodService _FoodService { get; set; }

        protected override void OnInitialized()
        {
            FoodEntry = new FoodEntry() { Amount = 0, Food = new Food() };
            FoodToday = _CalorieService.GetFoodOfDay(DateTime.Now) ??
                        new FoodInDay()
                        {
                            Day = DateTime.Now,
                            WhatIAte = new List<FoodEntry>()
                        };
            AllExistingFood = _FoodService.GetAllFood();
            CurrentDate = DateTime.Now.ToShortDateString();

            base.OnInitialized();
        }

        public void AddFoodEntry()
        {
            FoodEntry.Food = AllExistingFood.FirstOrDefault(f => f.Name.Equals(Name));
            FoodEntry.Calories = CalculateCalories(FoodEntry);
            FoodToday.WhatIAte.Add(FoodEntry);
            FoodEntry = new FoodEntry() { Amount = 0, Food = new Food() };

            StateHasChanged();
        }

        public int SumUpCaloriesOfToday()
        {
            var sum = 0;
            foreach (var e in FoodToday.WhatIAte)
            {
                sum += e.Calories;
            }
            return sum;
        }

        private int CalculateCalories(FoodEntry foodEntry)
        {
            var relative = foodEntry.Amount / 100.0f;
            return (int)(relative * (foodEntry.Food?.CaloriesPer100g ?? 0.0f));
        }
    }
}
