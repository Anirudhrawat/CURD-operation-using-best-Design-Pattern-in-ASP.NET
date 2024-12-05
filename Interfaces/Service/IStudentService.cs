using School_Management_System.DTO;

namespace School_Management_System.Interfaces.Service
{
    public interface IStudentService
    {
        Task AddStudent(StudentDTO studentDto);
        Task UpdateStudent(int id, StudentDTO studentDto);
        Task<IEnumerable<StudentDTO>> GetAllStudents();
        Task<StudentDTO> GetStudentById(int id);
        Task DeleteStudent(int id);
    }
}
