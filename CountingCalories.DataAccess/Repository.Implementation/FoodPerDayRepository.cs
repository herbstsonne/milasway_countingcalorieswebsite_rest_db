using System;
using System.Collections.Generic;
using System.Linq;
using CountingCalories.Domain.Entities;
using CountingCalories.Domain.Repository.Contract;
using Microsoft.EntityFrameworkCore;

namespace CountingCalories.DataAccess.Repository.Implementation
{
    public class FoodPerDayRepository : IAsyncRepository<FoodPerDayEntity>
    {
        private readonly CountingCaloriesContext _db;

        public FoodPerDayRepository(CountingCaloriesContext db)
        {
            _db = db;
        }

        public IEnumerable<FoodPerDayEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public FoodPerDayEntity GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void Add(FoodPerDayEntity entity)
        {
            _db.FoodPerDays.Add(entity);
            _db.SaveChanges();
        }

        public void Update(FoodPerDayEntity entity)
        {
            _db.FoodPerDays.Update(entity);
            _db.SaveChanges();
        }

        public void UpdateAll(List<FoodPerDayEntity> newEntityList)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var entryEntity = _db.FoodPerDays.FirstOrDefault(e => e.Id == id);
            if (entryEntity == null)
                return;
            _db.FoodPerDays.Remove(entryEntity);
            _db.SaveChanges();
        }

        public FoodPerDayEntity GetByDate(string date)
        {
            var foodPerDayEntity = _db.FoodPerDays
                .Include(f => f.AllEntries)
                .FirstOrDefault(f => f.Day.Equals(date));
            return foodPerDayEntity;
        }
    }
}
