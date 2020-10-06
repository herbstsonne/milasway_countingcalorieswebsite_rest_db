using CountingCalories.Shared.ViewModels;

namespace CountingCalories.Domain.Services.Interfaces
{
    public interface IFoodPerDayApiService
    {
        FoodPerDayView GetFoodPerDayByDate(string date);
        void AddFoodPerDay(FoodPerDayView foodPerDay);
        void UpdateFoodPerDay(FoodPerDayView foodPerDay);
    }
}
