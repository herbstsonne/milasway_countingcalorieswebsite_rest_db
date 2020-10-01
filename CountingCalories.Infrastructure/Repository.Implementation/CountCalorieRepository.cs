using System;
using System.Linq;
using CountingCalories.Domain.Repository.Contract;
using CountingCalories.Domain.ViewModels;
using CountingCalories.Infrastructure.DataClasses;

namespace CountingCalories.Infrastructure.Repository.Implementation
{
    public class CountCalorieRepository : ICountCalorieRepository
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
                    EntryId = fe.Id,
                    FoodId = fe.FoodId,
                    FoodName = fe.FoodName,
                    Amount = fe.Amount,
                    Calories = fe.Calories
                }; 
            foodPerDayView.AllFoodEntries = foodEntries.ToList();
            return foodPerDayView;
        }

        public int AddFoodPerDay(FoodPerDayView foodPerDay)
        {
            var foodPerDayEntity = new FoodPerDayEntity()
            {
                Day = foodPerDay.Day
            };
            _db.FoodPerDays.Add(foodPerDayEntity);
            return _db.SaveChanges();
        }

        public int AddFoodEntry(FoodEntryView newestFoodEntry)
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
            return _db.SaveChanges();
        }

        public int DeleteFoodEntry(int id)
        {
            var entryEntity = _db.FoodEntries.FirstOrDefault(e => e.Id == id);
            _db.FoodEntries.Remove(entryEntity);
            return _db.SaveChanges();
        }

        public int GetFoodEntryIdOfLastEntry()
        {
            /*var entryEntity = (from fe in _db.FoodEntries
                   where fe.FoodPerDayDate == DateTime.Now.ToString("dd.MM.yyyy")
                   select fe).LastOrDefault();*/
            var entryEntity = _db.FoodEntries.ToList().LastOrDefault();
            return entryEntity.Id;
        }
    }
}
