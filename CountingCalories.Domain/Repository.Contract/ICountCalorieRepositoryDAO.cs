using System.Collections.Generic;
using CountingCalories.Domain.ViewModels;

namespace CountingCalories.Domain.Repository.Contract
{
    public interface ICountCalorieRepositoryDao
    {
        FoodPerDayView GetFoodPerDayByDate(string date);
        void AddFoodPerDay(FoodPerDayView foodPerDay);
        void AddFoodEntries(Dictionary<FoodEntryView, string> foodEntries);
    }
}
