using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using MilasFitnessUI.Models;
using MilasFitnessUI.Services;

namespace MilasFitnessUI.Pages
{
    public class FoodOverviewBase : ComponentBase
    {
        [Inject]
        public FoodService _FoodService { get; set; }

        public List<Food> allFood;

        protected override void OnInitialized()
        {
            allFood = _FoodService.GetAllFood();
            base.OnInitialized();
        }
    }
}
