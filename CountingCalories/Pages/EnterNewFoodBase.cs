using Microsoft.AspNetCore.Components;
using CountingCalories.Models;
using CountingCalories.Services;

namespace CountingCalories.Pages
{
    public class EnterNewFoodBase : ComponentBase
    {
        protected Food NewFood;

        [Inject] private FoodService FoodService { get; set; }

        public EnterNewFoodBase(FoodService foodService)
        {
            FoodService = foodService;
            NewFood = new Food();
        }

        protected void OnInitialized()
        {
            NewFood = new Food();
            base.OnInitialized();
        }

        public void Save()
        {
            if (NewFood == null)
                return; // JS: return value is missing
            FoodService.SaveFood(NewFood);

            NewFood = new Food();
            StateHasChanged();
        }
    }
}