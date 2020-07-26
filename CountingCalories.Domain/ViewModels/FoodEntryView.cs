using System;
using System.Collections.Generic;
using System.Text;

namespace CountingCalories.Domain.ViewModels
{
    public class FoodEntryView
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public int Amount { get; set; }
        public int Calories { get; set; }
    }
}
