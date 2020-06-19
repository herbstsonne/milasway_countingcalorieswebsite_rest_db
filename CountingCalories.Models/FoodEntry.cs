namespace CountingCalories.UI.Models
{
    public class FoodEntry
    {
        public int Id { get; set; }
        public Food Food { get; set; }
        public int Amount { get; set; }
        public int Calories { get; set; }
    }
}
