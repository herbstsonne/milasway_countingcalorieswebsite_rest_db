using System.Collections.Generic;
using CountingCalories.Domain.ViewModels;

namespace CountingCalories.Domain.Repository.Contract
{
    public interface ICountCalorieRepository
    {
        FoodPerDayView GetFoodPerDayByDate(string date);
        int AddFoodPerDay(FoodPerDayView foodPerDay);
        int AddFoodEntry(FoodEntryView foodEntry);
        int DeleteFoodEntry(int id);
        int GetFoodEntryIdOfLastEntry();
    }
}
