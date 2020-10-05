using System.Collections.Generic;

namespace CountingCalories.Domain.Entities
{
    public class FoodPerDayEntity : BaseEntity
    {
        public override int Id { get; set; }
        public string Day { get; set; }
        public IEnumerable<FoodEntryEntity> AllEntries { get; set; }
    }
}
