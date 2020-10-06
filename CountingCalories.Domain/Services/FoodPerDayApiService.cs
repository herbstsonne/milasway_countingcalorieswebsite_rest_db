using System.Collections.Generic;
using CountingCalories.Domain.Entities;
using CountingCalories.Domain.Repository.Contract;
using CountingCalories.Domain.Services.Interfaces;
using CountingCalories.Shared.ViewModels;

namespace CountingCalories.Domain.Services
{
    public class FoodPerDayApiService : IFoodPerDayApiService
    {
        private readonly IAsyncRepository<FoodPerDayEntity> _repoFoodPerDay;

        public FoodPerDayApiService(IAsyncRepository<FoodPerDayEntity> repoFoodPerDay)
        {
            _repoFoodPerDay = repoFoodPerDay;
        }

        public void AddFoodPerDay(FoodPerDayView foodPerDay)
        {
            var foodPerDayEntity = new FoodPerDayEntity()
            {
                Day = foodPerDay.Day
            };
            _repoFoodPerDay.Add(foodPerDayEntity);
        }

        public void UpdateFoodPerDay(FoodPerDayView foodPerDay)
        {
            var allEntries = new List<FoodEntryEntity>();
            foreach (var entry in foodPerDay.AllFoodEntries)
            {
                var entryEntity = new FoodEntryEntity()
                {
                    Id = entry.EntryId,
                    FoodId = entry.FoodId,
                    FoodName = entry.FoodName,
                    Amount = entry.Amount,
                    Calories = entry.Calories
                };
                allEntries.Add(entryEntity);
            }
            var foodPerDayEntity = new FoodPerDayEntity()
            {
                Id = foodPerDay.Id,
                Day = foodPerDay.Day,
                AllEntries = allEntries
            };
            _repoFoodPerDay.Update(foodPerDayEntity);
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
                Id = foodPerDayEntity.Id,
                Day = foodPerDayEntity.Day,
                AllFoodEntries = viewEntries
            };
            
            return foodPerDayView;
        }
    }
}
