using Microsoft.AspNetCore.Components;
using CountingCalories.UI.Models;
using CountingCalories.UI.Services;

namespace CountingCalories.UI.Pages
{
    public class EnterNewFoodBase : ComponentBase
    {
        public Food NewFood;

        [Inject]
        public FoodService _FoodService { get; set; }

        public EnterNewFoodBase()
        {
            NewFood = new Food();
        }

        protected override void OnInitialized()
        {
            NewFood = new Food();
            base.OnInitialized();
        }

        public void Save()
        {
            if (NewFood == null)
                return;
            _FoodService.SaveFood(NewFood);

            NewFood = new Food();
            StateHasChanged();
        }
    }
}
