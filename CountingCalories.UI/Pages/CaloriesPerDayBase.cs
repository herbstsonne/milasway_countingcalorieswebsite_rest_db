using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using CountingCalories.UI.Services;
using CountingCalories.UI.Models;
using System.Threading.Tasks;
using CountingCalories.UI.ViewModels;

namespace CountingCalories.UI.Pages
{
    public class CaloriesPerDayBase : ComponentBase
    {
        public List<Food> AllFoodItems { get; set; }
        public string Name { get; set; }
        private FoodEntry FoodEntry { get; set; }
        public ViewFoodEntry ViewFoodEntry { get; set; }
        public string CurrentDate { get; set; }
        public FoodPerDay FoodToday { get; set; }

        [Inject]
        public CountCalorieService _CalorieService { get; set; }

        [Inject]
        public FoodService _FoodService { get; set; }

        protected override void OnInitialized()
        {
            FoodEntry = new FoodEntry() { Amount = 0, FoodId = 0 };
            FoodToday = new FoodPerDay()
                        {
                            Day = DateTime.Now.Date.ToString("dd.MM.yyyy"),
                            AllFoodEntries = new List<FoodEntry>()
                        };
            CurrentDate = DateTime.Now.ToShortDateString();
            AllFoodItems = new List<Food>();
            ViewFoodEntry = new ViewFoodEntry(FoodEntry, AllFoodItems);
            base.OnInitialized();
        }

        protected override async Task OnInitializedAsync()
        {
            AllFoodItems = await _FoodService.GetAllFood();
            if(AllFoodItems.Any())
                Name = AllFoodItems.ElementAt(0)?.Name;

            FoodToday = await _CalorieService.GetFoodOfDay(DateTime.Now.Date) ?? FoodToday;
            ViewFoodEntry = new ViewFoodEntry(FoodEntry, AllFoodItems);
            ViewFoodEntry.Calories = CalculateCalories(ViewFoodEntry);
            base.OnInitialized();
        }

        public void AddFoodEntry()
        {
            ViewFoodEntry.Food = AllFoodItems.FirstOrDefault(f => f.Name.Equals(Name));
            ViewFoodEntry.Calories = CalculateCalories(ViewFoodEntry);
            FoodToday.AllFoodEntries.Add(FoodEntry);
            FoodEntry.FoodInDayId = FoodToday.Id;

            _CalorieService.AddFoodOfDay(FoodToday, FoodToday.AllFoodEntries);

            FoodEntry = new FoodEntry() { Amount = 0, FoodId = 0 };
            ViewFoodEntry = new ViewFoodEntry(FoodEntry, AllFoodItems);

            StateHasChanged();
        }

        public int SumUpCaloriesOfToday()
        {
            var sum = 0;
            foreach (var e in FoodToday.AllFoodEntries)
            {
                sum += e.Calories;
            }
            return sum;
        }

        private int CalculateCalories(ViewFoodEntry foodEntry)
        {
            var relative = foodEntry.Amount / 100.0f;
            return (int)(relative * (foodEntry.Food?.CaloriesPer100g ?? 0.0f));
        }
    }
}
