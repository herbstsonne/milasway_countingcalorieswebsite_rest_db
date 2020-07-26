using System;
using System.Collections.Generic;
using System.Text;

namespace CountingCalories.Domain.ViewModels
{
    public class FoodView
    {
        public string Name { get; set; }
        public int CaloriesPer100G { get; set; }
    }
}
