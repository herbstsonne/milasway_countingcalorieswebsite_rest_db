using System.Collections.Generic;

namespace CountingCalories.Domain.ViewModels
{
    public class FoodPerDayView
    {
        public List<FoodEntryView> AllFoodEntries { get; set; }
        public string Day { get; set; }
    }
}
