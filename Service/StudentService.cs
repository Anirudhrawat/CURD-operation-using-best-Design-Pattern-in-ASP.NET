using AutoMapper;
using School_Management_System.DTO;
using School_Management_System.Interfaces;
using School_Management_System.Interfaces.Service;
using School_Management_System.Models;

namespace School_Management_System.Service
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddStudent(StudentDTO studentDto)
        {
            var student = _mapper.Map<Student>(studentDto);
            student.Enrollments = null;
            await _unitOfWork.Students.CreateAsync(student);
            await _unitOfWork.Save();
        }

        public async Task DeleteStudent(int id)
        {
            var student = await _unitOfWork.Students.GetAsync(id);
            _unitOfWork.Students.Delete(student);
            await _unitOfWork.Save();
        }

        public async Task<IEnumerable<StudentDTO>> GetAllStudents()
        {
            var studentList = await _unitOfWork.Students.GetAllAsync();
            return _mapper.Map<IEnumerable<StudentDTO>>(studentList);
        }

        public async Task<StudentDTO> GetStudentById(int id)
        {
            var student =  await _unitOfWork.Students.GetAsync(id);
            return _mapper.Map<StudentDTO>(student);
        }

        public async Task UpdateStudent(int id, StudentDTO studentDto)
        {
            var student = await _unitOfWork.Students.GetAsync(id);
            student.Email = studentDto.Email;
            student.Name = studentDto.Email;
            _unitOfWork.Students.Update(student);
            await _unitOfWork.Save();
        }
    }
}
