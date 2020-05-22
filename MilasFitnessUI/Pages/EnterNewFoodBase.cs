﻿using Microsoft.AspNetCore.Components;
using MilasFitnessUI.Models;
using MilasFitnessUI.Services;

namespace MilasFitnessUI.Pages
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
