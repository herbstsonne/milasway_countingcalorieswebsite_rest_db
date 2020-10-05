using System.Collections.Generic;
using System.Linq;
using CountingCalories.Domain.Entities;
using CountingCalories.Domain.Repository.Contract;

namespace CountingCalories.DataAccess.Repository.Implementation
{
    public class FoodRepository : IAsyncRepository<FoodEntity>
    {
        private readonly CountingCaloriesContext _db;

        public FoodRepository(CountingCaloriesContext db)
        {
            _db = db;
        }

        public IEnumerable<FoodEntity> GetAll()
        {
            return _db.Food;
        }

        public FoodEntity GetByName(string name)
        {
            var food = _db.Food.FirstOrDefault(f => f.Name == name);
            if (food == null)
                return null;
            return food;
        }

        public void Add(FoodEntity entity)
        {
            _db.Food.Add(entity);
            _db.SaveChanges();
        }

        public void UpdateAll(List<FoodEntity> newEntityList)
        {
            _db.Food.UpdateRange(newEntityList);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var food = _db.Food.Find(id);
            _db.Food.Remove(food);
            _db.SaveChanges();
        }

        public FoodEntity GetByDate(string date)
        {
            throw new System.NotImplementedException();
        }

        public int GetIdOfLastElement()
        {
            throw new System.NotImplementedException();
        }
    }
}
