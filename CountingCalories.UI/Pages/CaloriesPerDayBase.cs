using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using CountingCalories.Shared.ViewModels;
using CountingCalories.UI.Services;

namespace CountingCalories.UI.Pages
{
    public class CaloriesPerDayBase : ComponentBase
    {
        [Inject]
        public IJSRuntime JSRuntime { get; set; }

        public List<FoodView> AllFoodItems { get; set; }
        public string Name { get; set; }
        protected FoodEntryView FoodEntry { get; set; }
        public string CurrentDate { get; set; }
        public FoodPerDayView FoodToday { get; set; }

        [Inject]
        public CountCalorieService CalorieService { get; set; }

        [Inject]
        public FoodService FoodService { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            FoodEntry = new FoodEntryView() { Amount = 0, FoodId = 0 };
            FoodToday = new FoodPerDayView()
            {
                Day = DateTime.Now.Date.ToString("dd.MM.yyyy"),
                AllFoodEntries = new List<FoodEntryView>()
            };
            CurrentDate = DateTime.Now.ToShortDateString();
            AllFoodItems = new List<FoodView>();


        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            AllFoodItems = await FoodService.GetAllFood();
            if(AllFoodItems.Any())
                Name = AllFoodItems.ElementAt(0)?.Name;

            FoodToday = await CalorieService.GetFoodOfDay(DateTime.Now.Date) ?? FoodToday;
            FoodEntry = new FoodEntryView(); 
            FoodEntry.Calories = CalculateCalories(FoodEntry);
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            await base.OnAfterRenderAsync(firstRender);

            if (firstRender)
            {
                var date = new DateTime();
                var dm = date.Month + 1;
                var dj = date.Year;
                //await JSRuntime.InvokeVoidAsync("Kalender", dm, dj, "calendar");
            }

        }
        public async void DeleteEntry(FoodEntryView foodEntry)
        {
            await CalorieService.DeleteFoodEntry(foodEntry);
            FoodToday.AllFoodEntries.Remove(foodEntry);
            StateHasChanged();
        }

        public async Task AddFoodEntry()
        {
            var food = AllFoodItems.FirstOrDefault(f => f.Name.Equals(Name));
            FoodEntry.FoodName = food.Name;
            FoodEntry.FoodId = food.FoodId;
            FoodEntry.Calories = CalculateCalories(FoodEntry);
            FoodToday.AllFoodEntries.Add(FoodEntry);

            var entry = await CalorieService.GetFoodOfDay(DateTime.Now);
            if (entry != null)
            {
                await CalorieService.UpdateFoodOfDay(entry, FoodEntry);
            }
            else
            {
                await CalorieService.AddFoodOfDay(FoodToday, FoodEntry);
            }
            FoodEntry.EntryId = await CalorieService.GetFoodEntryIdOfLastEntry();

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
