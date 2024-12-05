using School_Management_System.Models;
using System;

namespace School_Management_System.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<Student> Students { get; }
        IRepository<Enrollment> Enrollments { get; }
        IRepository<Course> Courses { get; }
        Task Save();
    }
}
