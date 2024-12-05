using Microsoft.EntityFrameworkCore;
using School_Management_System.Interfaces;
using School_Management_System.Models;

namespace School_Management_System.Repository
{
    public class CourseRepo: IRepository<Course>
    {
        private readonly SmsdbContext _msdbContext;

        public CourseRepo(SmsdbContext msdbContext)
        {
            _msdbContext = msdbContext;
        }
        public async Task CreateAsync(Course entity)
        {
            await _msdbContext.Courses.AddAsync(entity);
        }

        public void Delete(Course entity)
        {
            _msdbContext.Courses.Remove(entity);
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _msdbContext.Courses.AsNoTracking().ToListAsync();
        }

        public async Task<Course> GetAsync(int i)
        {
            return await _msdbContext.Courses.AsNoTracking().FirstOrDefaultAsync(opt => opt.Id == i);
        }

        public void Update(Course entity)
        {
            _msdbContext.Courses.Update(entity);
        }
    }
}
