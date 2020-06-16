using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountingCalories.UI.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CaloriesPer100g { get; set; }
    }
}
