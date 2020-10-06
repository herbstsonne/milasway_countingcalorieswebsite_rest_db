
using System;
using System.Collections.Generic;
using CountingCalories.Domain.Entities;
using CountingCalories.Domain.Repository.Contract;
using CountingCalories.Domain.Services.Interfaces;
using CountingCalories.Shared.ViewModels;

namespace CountingCalories.Domain.Services
{
    public class CountingCaloriesApiService : ICountingCaloriesApiService
    {
        private readonly IAsyncRepository<FoodPerDayEntity> _repoFoodPerDay;
        private readonly IAsyncRepository<FoodEntryEntity> _repoFoodEntry;

        public CountingCaloriesApiService(IAsyncRepository<FoodPerDayEntity> repoFoodPerDay, IAsyncRepository<FoodEntryEntity> repoFoodEntry)
        {
            _repoFoodPerDay = repoFoodPerDay;
            _repoFoodEntry = repoFoodEntry;
        }

        public void AddFoodEntry(FoodEntryView foodEntry)
        {
            var currentDate = DateTime.Now.ToString("dd.MM.yyyy");
            var foodEntryEntity = new FoodEntryEntity()
            {
                FoodId = foodEntry.FoodId,
                FoodName = foodEntry.FoodName,
                Amount = foodEntry.Amount,
                Calories = foodEntry.Calories,
                FoodPerDayDate = currentDate
            };
            _repoFoodEntry.Add(foodEntryEntity);
        }

        public void AddFoodPerDay(FoodPerDayView foodPerDay)
        {
            var foodPerDayEntity = new FoodPerDayEntity()
            {
                Day = foodPerDay.Day
            };
            _repoFoodPerDay.Add(foodPerDayEntity);
        }

        public void DeleteFoodEntry(int id)
        {
            _repoFoodEntry.Delete(id);
        }

        public int GetFoodEntryIdOfLastEntry()
        {
            return _repoFoodEntry.GetIdOfLastElement();
        }

        public FoodPerDayView GetFoodPerDayByDate(string date)
        {
            var foodPerDayEntity = _repoFoodPerDay.GetByDate(date);

            if (foodPerDayEntity == null)
                return null;
            var viewEntries = new List<FoodEntryView>();
            foreach (var entityEntry in foodPerDayEntity.AllEntries)
            {
                var entry = new FoodEntryView()
                {
                    EntryId = entityEntry.Id,
                    FoodId = entityEntry.FoodId,
                    FoodName = entityEntry.FoodName,
                    Amount = entityEntry.Amount,
                    Calories = entityEntry.Calories
                };
                viewEntries.Add(entry);
            }

            var foodPerDayView = new FoodPerDayView
            {
                Day = foodPerDayEntity.Day,
                AllFoodEntries = viewEntries
            };
            
            return foodPerDayView;
        }
    }
}
