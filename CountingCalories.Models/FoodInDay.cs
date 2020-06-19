using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountingCalories.UI.Models
{
    public class FoodInDay
    {
        public int Id { get; set; }
        public List<FoodEntry> TotalCalories { get; set; }
        public DateTime Day { get; set; }
    }
}
