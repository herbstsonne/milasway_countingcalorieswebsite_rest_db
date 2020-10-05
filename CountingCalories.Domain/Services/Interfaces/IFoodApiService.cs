
using System.Collections.Generic;
using CountingCalories.Shared.ViewModels;

namespace CountingCalories.Domain.Services.Interfaces
{
    public interface IFoodApiService
    {
        IEnumerable<FoodView> GetAllFood();
        FoodView GetFoodByName(string name);
        void AddFood(FoodView food);
        void UpdateAllFood(List<FoodView> newFoodList);
        void DeleteFoodById(int id);
    }
}
