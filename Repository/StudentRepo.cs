using School_Management_System.Interfaces;
using School_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace School_Management_System.Repository
{
    public class StudentRepo : IRepository<Student>
    {
        private readonly SmsdbContext _msdbContext;

        public StudentRepo(SmsdbContext msdbContext)
        {
            _msdbContext = msdbContext;
        }
        public async Task CreateAsync(Student entity)
        {
            await _msdbContext.Students.AddAsync(entity);
        }

        public void Delete(Student entity)
        {
            _msdbContext.Students.Remove(entity);
        }

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _msdbContext.Students.AsNoTracking().ToListAsync();
        }

        public async Task<Student> GetAsync(int i)
        {
            return await _msdbContext.Students.AsNoTracking().FirstOrDefaultAsync(opt => opt.Id == i);
        }

        public void Update(Student entity)
        {
            _msdbContext.Students.Update(entity);
        }
    }
}
