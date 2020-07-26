using System.Collections.Generic;
using System.Linq;
using CountingCalories.Domain.Repository.Contract;
using CountingCalories.Domain.ViewModels;
using CountingCalories.Infrastructure.Entities;

namespace CountingCalories.Infrastructure.Repository.Implementation
{
    public class FoodRepositoryDao : IFoodRepositoryDao
    {
        private CountingCaloriesContext _db;

        public FoodRepositoryDao(CountingCaloriesContext db)
        {
            _db = db;
        }

        public IEnumerable<FoodView> GetAllFood()
        {
            var allFood = from f in _db.Food 
                select new FoodView()
                {
                    FoodId = f.Id,
                    Name = f.Name,
                    CaloriesPer100G = f.CaloriesPer100G
                };
            return allFood;
        }

        public FoodView GetFoodByName(string name)
        {
            var food = _db.Food.FirstOrDefault(f => f.Name == name);
            if (food == null)
                return null;
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
            _db.Food.Add(food);
            _db.SaveChanges();
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
            _db.Food.UpdateRange(allFood);
            _db.SaveChanges();
        }

        public void DeleteFoodById(int id)
        {
            var food = _db.Food.Find(id);
            _db.Food.Remove(food);
            _db.SaveChanges();
        }
    }
}
