using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountingCalories.Models
{
    public class Food
    {
        public Food(String name, Int32 caloriesPer100G)
        {
            Name = name;
            CaloriesPer100G = caloriesPer100G;
        }

        public int Id { get; set; }
        public string Name { get; private set; }
        public int CaloriesPer100G { get; set; }
    }
}