using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NutriLift.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly NutriLiftContext context;
        public Repository(NutriLiftContext databaseContext)
        {
            this.context = databaseContext;
        }

        public List<T> GetAll()
        {
            try
            {
                return context.Set<T>().ToList();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public T GetById(Guid id)
        {
            try
            {
                return context.Find<T>(id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task CreateAsync(T entity)
        {
            try
            {
                await context.AddAsync(entity);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while creating {nameof(entity)} : {ex.Message}");
            }
        }

        public async Task UpdateAsync(T entity)
        {
            try
            {
                context.Entry(entity).State  = EntityState.Modified;
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while creating {nameof(entity)} : {ex.Message}");
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                T record = GetById(id);
                context.Remove(record);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error while deleting : {ex.Message}");
            }
        }
    }
}
