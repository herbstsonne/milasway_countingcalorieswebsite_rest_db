using CountingCalories.UI.Models;
using Microsoft.EntityFrameworkCore;

namespace EFGetStarted
{
    public class CountingCaloriesContext : DbContext
    {
        public DbSet<Food> Food { get; set; }
        public DbSet<FoodEntry> FoodEntries { get; set; }
        public DbSet<FoodInDay> FoodInDays { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=countingcalories.db");
    }
}
