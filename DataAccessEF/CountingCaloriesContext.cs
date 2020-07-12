using CountingCalories.UI.Models;
using Microsoft.EntityFrameworkCore;

namespace EFGetStarted
{
    public class CountingCaloriesContext : DbContext
    {
        public CountingCaloriesContext(DbContextOptions<CountingCaloriesContext> options) : base(options)
        {
        }

        public DbSet<Food> Food { get; set; }
        public DbSet<FoodEntry> FoodEntries { get; set; }
        public DbSet<FoodPerDay> FoodInDays { get; set; }
    }
}
