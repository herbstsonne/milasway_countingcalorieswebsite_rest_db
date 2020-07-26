using CountingCalories.Domain.Entities;
using Microsoft.AspNetCore.Components;
using CountingCalories.UI.Services;

namespace CountingCalories.UI.Pages
{
    public class EnterNewFoodBase : ComponentBase
    {
        public FoodEntity NewFood;

        [Inject]
        public FoodService _FoodService { get; set; }

        public EnterNewFoodBase()
        {
            NewFood = new FoodEntity();
        }

        protected override void OnInitialized()
        {
            NewFood = new FoodEntity();
            base.OnInitialized();
        }

        public void Save()
        {
            if (NewFood == null)
                return;
            _FoodService.SaveFood(NewFood);

            NewFood = new FoodEntity();
            StateHasChanged();
        }
    }
}
