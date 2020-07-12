using CountingCalories.UI.Models;
using Microsoft.EntityFrameworkCore;

namespace EFGetStarted
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
