using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using CountingCalories.Models;
using CountingCalories.Services;

namespace CountingCalories.Pages
{
    public class FoodOverviewBase : ComponentBase
    {
        [Inject] private FoodService FoodService { get; set; }

        protected List<Food> AllFood;

        public FoodOverviewBase(FoodService foodService)
        {
            FoodService = foodService;
        }

        protected void OnInitialized()
        {
            AllFood = FoodService.GetAllFood();
            base.OnInitialized();
        }
    }
}