using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using System;
using CountingCalories.Shared.ViewModels;
using CountingCalories.UI.Services;

namespace CountingCalories.UI.Pages
{
    public class FoodOverviewBase : ComponentBase
    {
        [Inject]
        public FoodService _FoodService { get; set; }

        public List<FoodView> allFood = new List<FoodView>();

        protected override async Task OnInitializedAsync()
        {
            allFood = await _FoodService.GetAllFood();
            await base.OnInitializedAsync();
        }
        public void SaveChanges()
        {
            _FoodService.Update(allFood);
            StateHasChanged();
        }

        public async void DeleteFood(FoodView food)
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
