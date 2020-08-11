namespace CountingCalories.Infrastructure.DataClasses
{
    public class FoodEntryEntity
    {
        public int Id { get; set; }
        public string FoodPerDayDate { get; set; }
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public int Amount { get; set; }
        public int Calories { get; set; }
    }
}
