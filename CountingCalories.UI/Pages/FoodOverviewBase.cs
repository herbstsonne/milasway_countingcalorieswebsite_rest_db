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
        public FoodService FoodService { get; set; }

        public List<FoodView> allFood = new List<FoodView>();

        protected override async Task OnInitializedAsync()
        {
            allFood = await FoodService.GetAllFood();
            await base.OnInitializedAsync();
        }
        public void SaveChanges()
        {
            FoodService.Update(allFood);
            StateHasChanged();
        }

        public async void DeleteFood(FoodView food)
        {
            try
            {
                await FoodService.Delete(food);
                
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
