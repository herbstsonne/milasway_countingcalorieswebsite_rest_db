
namespace CountingCalories.Domain.ViewModels
{
    public class FoodEntryView
    {
        public int EntryId { get; set; }
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public int Amount { get; set; }
        public int Calories { get; set; }
    }
}
