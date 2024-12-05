using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using School_Management_System.Interfaces;
using School_Management_System.Models;

namespace School_Management_System.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _msdbContext;

        public Repository(SmsdbContext msdbContext)
        {
            _msdbContext = msdbContext.Set<T>();
        }
        public async Task CreateAsync(T entity)
        {
            try
            {
                await _msdbContext.AddAsync(entity);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public void Delete(T entity)
        {
            _msdbContext.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _msdbContext.AsNoTracking().ToListAsync();
        }

        public async Task<T> GetAsync(int i)
        {

            return await _msdbContext.FindAsync(i);
        }

        public void Update(T entity)
        {
            _msdbContext.Update(entity);
        }
    }
}
