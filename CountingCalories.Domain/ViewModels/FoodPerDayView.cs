using System;
using System.Collections.Generic;
using System.Text;
using CountingCalories.Domain.Entities;

namespace CountingCalories.Domain.ViewModels
{
    public class FoodPerDayView
    {
        public List<FoodEntryEntity> AllFoodEntries { get; set; }
        public string Day { get; set; }
    }
}
