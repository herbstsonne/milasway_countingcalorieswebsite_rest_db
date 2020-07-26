using CountingCalories.Domain.Services;
using CountingCalories.Domain.ViewModels;
using Microsoft.AspNetCore.Components;

namespace CountingCalories.UI.Pages
{
    public class EnterNewFoodBase : ComponentBase
    {
        public FoodView NewFood;

        [Inject]
        public FoodService _FoodService { get; set; }

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
            _FoodService.SaveFood(NewFood);

            NewFood = new FoodView();
            StateHasChanged();
        }
    }
}
