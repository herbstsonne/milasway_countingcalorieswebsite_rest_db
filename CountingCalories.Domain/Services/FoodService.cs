using System.Collections.Generic;
using CountingCalories.Domain.Entities;
using CountingCalories.Domain.Repository.Contract;
using CountingCalories.Domain.Services.Interfaces;
using CountingCalories.Shared.ViewModels;

namespace CountingCalories.Domain.Services
{
    public class FoodApiService : IFoodApiService
    {
        private readonly IAsyncRepository<FoodEntity> _repo;

        public FoodApiService(IAsyncRepository<FoodEntity> repo)
        {
            _repo = repo;
        }

        public IEnumerable<FoodView> GetAllFood()
        {
            var allFood = new List<FoodView>();
            foreach (var food in _repo.GetAll())
            {
                var foodView = new FoodView
                {
                    FoodId = food.Id,
                    Name = food.Name,
                    CaloriesPer100G = food.CaloriesPer100G
                };
                allFood.Add(foodView);
            }
            return allFood;
        }

        public FoodView GetFoodByName(string name)
        {
            var food = _repo.GetByName(name);

            return new FoodView()
            {
                FoodId = food.Id,
                Name = food.Name,
                CaloriesPer100G = food.CaloriesPer100G
            };
        }

        public void AddFood(FoodView foodView)
        {
            var food = new FoodEntity()
            {
                //Id = foodView.FoodId,
                Name = foodView.Name,
                CaloriesPer100G = foodView.CaloriesPer100G
            };
            _repo.Add(food);
        }

        public void UpdateAllFood(List<FoodView> newFoodList)
        {
            var allFood = new List<FoodEntity>();
            foreach (var foodView in newFoodList)
            {
                var food = new FoodEntity()
                {
                    Id = foodView.FoodId,
                    Name = foodView.Name,
                    CaloriesPer100G = foodView.CaloriesPer100G
                };
                allFood.Add(food);
            }
            _repo.UpdateAll(allFood);
        }

        public void DeleteFoodById(int id)
        {
            _repo.Delete(id);
        }
    }
}
