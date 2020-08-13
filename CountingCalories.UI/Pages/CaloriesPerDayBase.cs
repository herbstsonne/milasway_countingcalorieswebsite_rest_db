using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using CountingCalories.Domain.Services;
using CountingCalories.Domain.ViewModels;

namespace CountingCalories.UI.Pages
{
    public class CaloriesPerDayBase : ComponentBase
    {
        public List<FoodView> AllFoodItems { get; set; }
        public string Name { get; set; }
        protected FoodEntryView FoodEntry { get; set; }
        public string CurrentDate { get; set; }
        public FoodPerDayView FoodToday { get; set; }

        [Inject]
        public CountCalorieService _CalorieService { get; set; }

        [Inject]
        public FoodService _FoodService { get; set; }

        protected override void OnInitialized()
        {
            FoodEntry = new FoodEntryView() { Amount = 0, FoodId = 0 };
            FoodToday = new FoodPerDayView()
                        {
                            Day = DateTime.Now.Date.ToString("dd.MM.yyyy"),
                            AllFoodEntries = new List<FoodEntryView>()
                        };
            CurrentDate = DateTime.Now.ToShortDateString();
            AllFoodItems = new List<FoodView>();
            base.OnInitialized();
        }

        protected override async Task OnInitializedAsync()
        {
            AllFoodItems = await _FoodService.GetAllFood();
            if(AllFoodItems.Any())
                Name = AllFoodItems.ElementAt(0)?.Name;

            FoodToday = await _CalorieService.GetFoodOfDay(DateTime.Now.Date) ?? FoodToday;
            FoodEntry = new FoodEntryView(); 
            FoodEntry.Calories = CalculateCalories(FoodEntry);
            await base.OnInitializedAsync();
        }

        public async Task AddFoodEntry()
        {
            var food = AllFoodItems.FirstOrDefault(f => f.Name.Equals(Name));
            FoodEntry.FoodName = food.Name;
            FoodEntry.FoodId = food.FoodId;
            FoodEntry.Calories = CalculateCalories(FoodEntry);
            FoodToday.AllFoodEntries.Add(FoodEntry);

            var entry = await _CalorieService.GetFoodOfDay(DateTime.Now);
            if (entry != null)
            {
                await _CalorieService.UpdateFoodOfDay(entry, FoodEntry);
            }
            else
            {
                await _CalorieService.AddFoodOfDay(FoodToday, FoodEntry);
            }

            FoodEntry = new FoodEntryView() { Amount = 0, FoodId = 0 };

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

        private int CalculateCalories(FoodEntryView foodEntry)
        {
            var food = AllFoodItems.FirstOrDefault(f => f.Name.Equals(Name));
            var relative = foodEntry.Amount / 100.0f;
            return (int)(relative * (food?.CaloriesPer100G ?? 0.0f));
        }
    }
}
