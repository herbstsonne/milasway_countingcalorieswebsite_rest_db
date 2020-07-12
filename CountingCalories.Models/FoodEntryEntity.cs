namespace CountingCalories.UI.Models
{
    public class FoodEntryEntity
    {
        public int FoodInDayId { get; set; }
        public int Id { get; set; }
        //führt zu EF-Problemen, Zwischenobjekt nötig?
        //public Food Food { get; set; }
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public int Amount { get; set; }
        public int Calories { get; set; }
    }
}
