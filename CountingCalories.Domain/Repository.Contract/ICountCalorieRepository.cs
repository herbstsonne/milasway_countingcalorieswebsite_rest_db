using CountingCalories.Shared.ViewModels;

namespace CountingCalories.Domain.Repository.Contract
{
    public interface ICountCalorieRepository
    {
        FoodPerDayView GetFoodPerDayByDate(string date);
        void AddFoodPerDay(FoodPerDayView foodPerDay);
        void AddFoodEntry(FoodEntryView foodEntry);
        void DeleteFoodEntry(int id);
        int GetFoodEntryIdOfLastEntry();
    }
}
