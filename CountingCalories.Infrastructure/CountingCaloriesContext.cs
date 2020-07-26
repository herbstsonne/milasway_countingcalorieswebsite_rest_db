using CountingCalories.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CountingCalories.Infrastructure
{
    public class CountingCaloriesContext : DbContext
    {
        public CountingCaloriesContext(DbContextOptions<CountingCaloriesContext> options) : base(options)
        {
        }

        public DbSet<FoodEntity> Food { get; set; }
        public DbSet<FoodEntryEntity> FoodEntries { get; set; }
        public DbSet<FoodPerDayEntity> FoodInDays { get; set; }
    }
}
