using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using CountingCalories.UI.Models;
using CountingCalories.UI.Services;
using System.Threading.Tasks;
using System;

namespace CountingCalories.UI.Pages
{
    public class FoodOverviewBase : ComponentBase
    {
        [Inject]
        public FoodService _FoodService { get; set; }

        public List<Food> allFood = new List<Food>();

        protected override async Task OnInitializedAsync()
        {
            allFood = await _FoodService.GetAllFood();
            base.OnInitialized();
        }
        public void SaveChanges()
        {
            _FoodService.Update(allFood);
            StateHasChanged();
        }

        public async void DeleteFood(Food food)
        {
            try
            {
                await _FoodService.Delete(food);
                
                allFood.Remove(food);
                StateHasChanged();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
