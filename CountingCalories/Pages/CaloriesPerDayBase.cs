using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using CountingCalories.Models;
using CountingCalories.Services;


namespace CountingCalories.Pages
{
    public class CaloriesPerDayBase : ComponentBase
    {
        public CaloriesPerDayBase(FoodService foodService, CountCalorieService calorieService, String name)
        {
            FoodService = foodService;
            CalorieService = calorieService;
            Name = name;
        }

        protected string Name { get; set; }
        protected FoodInDay FoodToday { get; set; }
        protected List<Food> AllExistingFood { get; set; }
        protected FoodEntry FoodEntry { get; set; }
        protected string CurrentDate { get; set; }

        [Inject] private CountCalorieService CalorieService { get; set; }

        [Inject] private FoodService FoodService { get; set; }

        protected void OnInitialized()
        {
            FoodEntry = new FoodEntry() {Amount = 0, Food = new Food()};
            FoodToday = CalorieService.GetFoodOfDay(DateTime.Now) ??
                        new FoodInDay()
                        {
                            Day = DateTime.Now,
                            WhatIAte = new List<FoodEntry>()
                        };
            AllExistingFood = FoodService.GetAllFood();
            CurrentDate = DateTime.Now.ToShortDateString();

            base.OnInitialized();
        }

        public void AddFoodEntry()
        {
            FoodEntry.Food = AllExistingFood.FirstOrDefault(f => f.Name.Equals(Name));
            CalculateCalories(FoodEntry);
            FoodToday.WhatIAte.Add(FoodEntry);
            FoodEntry = new FoodEntry() {Amount = 0, Food = new Food()};

            StateHasChanged();
        }

        protected int SumUpCaloriesOfToday()
        {
            var sum = 0;
            foreach (var e in FoodToday.WhatIAte)
            {
                sum += e.Calories;
            }

            return sum;
        }

        private static int CalculateCalories(FoodEntry foodEntry)
        {
            var relative = foodEntry.Amount / 100.0f;
            return (int) (relative * (foodEntry.Food?.CaloriesPer100G ?? 0.0f));
        }
    }
}