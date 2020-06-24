using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using CountingCalories.UI.Models;
using CountingCalories.UI.Services;
using System.Threading.Tasks;

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
    }
}
