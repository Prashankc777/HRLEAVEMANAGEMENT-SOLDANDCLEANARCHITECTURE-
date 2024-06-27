using HRLeaveManagement.Application.Contracts.Persistence;
using HRLeaveManagement.Persisrtance.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HRLeaveManagement.Persisrtance.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class

    {
        protected readonly HrDatabaseContext _context;

        public GenericRepository(HrDatabaseContext context)
        {
            _context = context;
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> UpdateAsync(int id, T updatedEntity)
        {
            var entity = await _context.Set<T>().FindAsync(id);

            if (entity == null)
            {
                throw new Exception($"{typeof(T).Name} not found");
            }

            foreach (var updatedProperty in typeof(T).GetProperties())
            {
                var value = updatedProperty.GetValue(updatedEntity);
                updatedProperty.SetValue(entity, value);
            }

            await _context.SaveChangesAsync();
            return entity;
        }


        public async Task<T> DeleteAsync(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return entity;

        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

       
    }
}



