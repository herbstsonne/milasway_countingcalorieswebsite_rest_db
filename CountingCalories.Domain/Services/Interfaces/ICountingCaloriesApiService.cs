
using CountingCalories.Shared.ViewModels;

namespace CountingCalories.Domain.Services.Interfaces
{
    public interface ICountingCaloriesApiService
    {
        FoodPerDayView GetFoodPerDayByDate(string date);
        void AddFoodPerDay(FoodPerDayView foodPerDay);
        void AddFoodEntry(FoodEntryView foodEntry);
        void DeleteFoodEntry(int id);
        int GetFoodEntryIdOfLastEntry();
    }
}
