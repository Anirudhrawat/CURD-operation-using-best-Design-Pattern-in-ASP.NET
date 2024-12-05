using Microsoft.EntityFrameworkCore;
using School_Management_System.Interfaces;
using School_Management_System.Models;

namespace School_Management_System.Repository
{
    public class EnrollmentRepo: IRepository<Enrollment>
    {
        private readonly SmsdbContext _msdbContext;

        public EnrollmentRepo(SmsdbContext msdbContext)
        {
            _msdbContext = msdbContext;
        }
        public async Task CreateAsync(Enrollment entity)
        {
            await _msdbContext.Enrollments.AddAsync(entity);
        }

        public void Delete(Enrollment entity)
        {
            _msdbContext.Enrollments.Remove(entity);
        }

        public async Task<IEnumerable<Enrollment>> GetAllAsync()
        {
            return await _msdbContext.Enrollments.AsNoTracking().ToListAsync();
        }

        public async Task<Enrollment> GetAsync(int i)
        {
            return await _msdbContext.Enrollments.AsNoTracking().FirstOrDefaultAsync(opt => opt.Id == i);
        }

        public void Update(Enrollment entity)
        {
            _msdbContext.Enrollments.Update(entity);
        }
    }
}
