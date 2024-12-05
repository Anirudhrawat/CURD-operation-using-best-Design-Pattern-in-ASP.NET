using School_Management_System.DTO;

namespace School_Management_System.Interfaces.Service
{
    public interface ICourseService
    {
        Task AddCourse(CourseDTO studentDto);
        Task UpdateCourse(int id, CourseDTO studentDto);
        Task<IEnumerable<CourseDTO>> GetAllCourses();
        Task<CourseDTO> GetCourseById(int id);
        Task DeleteCourse(int id);
    }
}
