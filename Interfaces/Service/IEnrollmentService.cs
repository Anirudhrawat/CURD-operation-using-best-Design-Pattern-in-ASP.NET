using School_Management_System.DTO;
using School_Management_System.Models;

namespace School_Management_System.Interfaces.Service
{
    public interface IEnrollmentService
    {
        Task EnrollStudent(int studentId, int courseId);
        Task<IEnumerable<CourseDTO>> GetEnrollmentsByStudent(int studentId);
        Task<IEnumerable<StudentDTO>> GetEnrollmentsByCourse(int courseId);

    }
}
