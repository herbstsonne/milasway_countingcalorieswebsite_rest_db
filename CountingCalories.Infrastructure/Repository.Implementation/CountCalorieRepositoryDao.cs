using System.Collections.Generic;
using System.Linq;
using CountingCalories.Domain.Repository.Contract;
using CountingCalories.Domain.ViewModels;
using CountingCalories.Infrastructure.Entities;

namespace CountingCalories.Infrastructure.Repository.Implementation
{
    public class CountCalorieRepositoryDao : ICountCalorieRepositoryDao
    {
        private CountingCaloriesContext _db;

        public CountCalorieRepositoryDao(CountingCaloriesContext db)
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

        public void AddFoodEntries(Dictionary<FoodEntryView, string> foodEntries)
        {
            var allFoodEntryEntities = new List<FoodEntryEntity>();
            foreach (var foodView in foodEntries)
            {
                var foodEntryEntity = new FoodEntryEntity()
                {
                    FoodId = foodView.Key.FoodId,
                    FoodName = foodView.Key.FoodName,
                    Amount = foodView.Key.Amount,
                    Calories = foodView.Key.Calories,
                    FoodPerDayDate = foodView.Value
                };
                allFoodEntryEntities.Add(foodEntryEntity);
            }
            _db.FoodEntries.AddRange(allFoodEntryEntities);
            _db.SaveChanges();
        }
    }
}
