namespace CountingCalories.Domain.Entities
{
    public class FoodEntryEntity : BaseEntity
    {
        public override int Id { get; set; }
        public string FoodPerDayDate { get; set; }
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public int Amount { get; set; }
        public int Calories { get; set; }
    }
}
