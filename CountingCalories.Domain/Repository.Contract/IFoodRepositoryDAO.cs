using System.Collections.Generic;
using CountingCalories.Domain.ViewModels;

namespace CountingCalories.Domain.Repository.Contract
{
    public interface IFoodRepositoryDao
    {
        IEnumerable<FoodView> GetAllFood();
        FoodView GetFoodByName(string name);
        void AddFood(FoodView food);
        void UpdateAllFood(List<FoodView> newFoodList);
        void DeleteFoodById(int id);
    }
}
