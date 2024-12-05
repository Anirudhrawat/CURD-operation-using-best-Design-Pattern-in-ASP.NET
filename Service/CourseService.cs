using AutoMapper;
using School_Management_System.DTO;
using School_Management_System.Interfaces;
using School_Management_System.Interfaces.Service;
using School_Management_System.Models;

namespace School_Management_System.Service
{
    public class CourseService: ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CourseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddCourse(CourseDTO studentDto)
        {
            var course = _mapper.Map<Course>(studentDto);
            course.Enrollments = null;
            await _unitOfWork.Courses.CreateAsync(course);
            await _unitOfWork.Save();
        }

        public async Task DeleteCourse(int id)
        {
            var course = await _unitOfWork.Courses.GetAsync(id);
            _unitOfWork.Courses.Delete(course);
            await _unitOfWork.Save();
        }

        public async Task<IEnumerable<CourseDTO>> GetAllCourses()
        {
            var studentList = await _unitOfWork.Courses.GetAllAsync();
            return _mapper.Map<IEnumerable<CourseDTO>>(studentList);
        }

        public async Task<CourseDTO> GetCourseById(int id)
        {
            var course = await _unitOfWork.Courses.GetAsync(id);
            return _mapper.Map<CourseDTO>(course);
        }

        public async Task UpdateCourse(int id, CourseDTO studentDto)
        {
            var course = await _unitOfWork.Courses.GetAsync(id);
            course.Title = studentDto.Title;
            course.Description = studentDto.Description;
            _unitOfWork.Courses.Update(course);
            await _unitOfWork.Save();
        }
    }
}
