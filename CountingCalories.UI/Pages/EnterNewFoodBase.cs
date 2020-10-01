
using CountingCalories.Shared.ViewModels;
using CountingCalories.UI.Services;
using Microsoft.AspNetCore.Components;

namespace CountingCalories.UI.Pages
{
    public class EnterNewFoodBase : ComponentBase
    {
        public FoodView NewFood;

        [Inject]
        public FoodService FoodService { get; set; }

        public EnterNewFoodBase()
        {
            NewFood = new FoodView();
        }

        protected override void OnInitialized()
        {
            NewFood = new FoodView();
            base.OnInitialized();
        }

        public void Save()
        {
            if (NewFood == null)
                return;
            FoodService.SaveFood(NewFood);

            NewFood = new FoodView();
            StateHasChanged();
        }
    }
}
