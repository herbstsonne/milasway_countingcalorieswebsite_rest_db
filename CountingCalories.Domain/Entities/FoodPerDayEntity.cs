using System.Collections.Generic;

namespace CountingCalories.Domain.Entities
{
    public class FoodPerDayEntity
    {
        public int Id { get; set; }
        public List<FoodEntryEntity> AllFoodEntries { get; set; }
        public string Day { get; set; }
    }
}
