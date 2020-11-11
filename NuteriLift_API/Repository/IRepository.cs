using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NuteriLift_API.Repository
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
        T GetById(Guid id);

        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
    }
}
