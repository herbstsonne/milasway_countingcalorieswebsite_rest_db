using System.Collections.Generic;
using CountingCalories.Domain.Entities;

namespace CountingCalories.Domain.Repository.Contract
{
    public interface IAsyncRepository<T> where T: BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetByName(string name);
        T GetByDate(string date);
        int GetIdOfLastElement();
        void Add(T entity);
        void UpdateAll(List<T> newEntityList);
        void Delete(int id);
    }
}
