using System.Collections.Generic;
using CountingCalories.Shared.ViewModels;

namespace CountingCalories.Domain.Repository.Contract
{
    public interface IFoodRepository
    {
        IEnumerable<FoodView> GetAllFood();
        FoodView GetFoodByName(string name);
        void AddFood(FoodView food);
        void UpdateAllFood(List<FoodView> newFoodList);
        void DeleteFoodById(int id);
    }
}
