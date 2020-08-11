using System;
using System.Linq;
using CountingCalories.Domain.Repository.Contract;
using CountingCalories.Domain.ViewModels;
using CountingCalories.Infrastructure.DataClasses;

namespace CountingCalories.Infrastructure.Repository.Implementation
{
    public class CountCalorieRepository : ICountCalorieRepositoryDao
    {
        private CountingCaloriesContext _db;

        public CountCalorieRepository(CountingCaloriesContext db)
        {
            _db = db;
        }

        public FoodPerDayView GetFoodPerDayByDate(string date)
        {
            var foodInDay = _db.FoodPerDays.FirstOrDefault(f => f.Day.Equals(date));
            if (foodInDay == null)
                return null;
            var foodPerDayView = new FoodPerDayView()
            {
                Day = foodInDay.Day
            };
            var foodEntries = from fe in _db.FoodEntries
                where fe.FoodPerDayDate == foodInDay.Day
                select new FoodEntryView()
                {
                    FoodId = fe.FoodId,
                    FoodName = fe.FoodName,
                    Amount = fe.Amount,
                    Calories = fe.Calories
                }; 
            foodPerDayView.AllFoodEntries = foodEntries.ToList();
            return foodPerDayView;
        }

        public void AddFoodPerDay(FoodPerDayView foodPerDay)
        {
            var foodPerDayEntity = new FoodPerDayEntity()
            {
                Day = foodPerDay.Day
            };
            _db.FoodPerDays.Add(foodPerDayEntity);
            _db.SaveChanges();
        }

        public void AddFoodEntry(FoodEntryView newestFoodEntry)
        {
            var currentDate = DateTime.Now.ToString("dd.MM.yyyy");
            var foodEntryEntity = new FoodEntryEntity()
            {
                FoodId = newestFoodEntry.FoodId,
                FoodName = newestFoodEntry.FoodName,
                Amount = newestFoodEntry.Amount,
                Calories = newestFoodEntry.Calories,
                FoodPerDayDate = currentDate
            };
            _db.FoodEntries.Add(foodEntryEntity);
            _db.SaveChanges();
        }
    }
}
