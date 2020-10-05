namespace CountingCalories.Domain.Entities
{
    public class FoodEntity : BaseEntity
    {
        public override int Id { get; set; }
        public string Name { get; set; }
        public int CaloriesPer100G { get; set; }
    }
}
