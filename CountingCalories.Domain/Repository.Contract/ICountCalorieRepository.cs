using System.Collections.Generic;
using CountingCalories.Domain.ViewModels;

namespace CountingCalories.Domain.Repository.Contract
{
    public interface ICountCalorieRepository
    {
        FoodPerDayView GetFoodPerDayByDate(string date);
        void AddFoodPerDay(FoodPerDayView foodPerDay);
        void AddFoodEntry(FoodEntryView foodEntry);
    }
}
