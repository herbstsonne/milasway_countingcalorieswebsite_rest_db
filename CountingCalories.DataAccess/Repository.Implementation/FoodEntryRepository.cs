using System.Collections.Generic;
using System.Linq;
using CountingCalories.Domain.Entities;
using CountingCalories.Domain.Repository.Contract;

namespace CountingCalories.DataAccess.Repository.Implementation
{
    public class FoodEntryRepository : IAsyncRepository<FoodEntryEntity>
    {
        private readonly CountingCaloriesContext _db;

        public FoodEntryRepository(CountingCaloriesContext db)
        {
            _db = db;
        }

        public void Add(FoodEntryEntity entity)
        {
            _db.FoodEntries.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var entryEntity = _db.FoodEntries.FirstOrDefault(e => e.Id == id);
            _db.FoodEntries.Remove(entryEntity);
            _db.SaveChanges();
        }

        public IEnumerable<FoodEntryEntity> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public FoodEntryEntity GetByDate(string date)
        {
            throw new System.NotImplementedException();
        }

        public FoodEntryEntity GetByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public int GetIdOfLastElement()
        {
            var last = _db.FoodEntries.LastOrDefault();
            if (last == null)
                return -1;
            return last.Id;
        }

        public void UpdateAll(List<FoodEntryEntity> newEntityList)
        {
            throw new System.NotImplementedException();
        }
    }
}
