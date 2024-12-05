using AutoMapper;
using School_Management_System.DTO;
using School_Management_System.Interfaces;
using School_Management_System.Interfaces.Service;
using School_Management_System.Models;

namespace School_Management_System.Service
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _service;
        public EnrollmentService(IUnitOfWork service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task EnrollStudent(int studentId, int courseId)
        {
            var enrollment = new Enrollment
            {
                StudentId = studentId,
                CourseId = courseId,
                EnrollmentDate = DateTime.Now 
            };
            await _service.Enrollments.CreateAsync(enrollment);
            await _service.Save();
        }

        public async Task<IEnumerable<StudentDTO>> GetEnrollmentsByCourse(int courseId)
        {
            var enrollmentList = await _service.Enrollments.GetAllAsync();
            if(enrollmentList.Count() == 0)
            {
                return null;
            }
            var trimList = enrollmentList.Where(i=>i.CourseId==courseId).ToList();
            if (trimList.Count() == 0)
            {
                return null;
            }

            var studentList = new List<StudentDTO>();
            foreach(var stid in trimList)
            {
                var course = await _service.Students.GetAsync(stid.StudentId);
                studentList.Add(_mapper.Map<StudentDTO>(course));
            }
            return studentList;
        }

        public async Task<IEnumerable<CourseDTO>> GetEnrollmentsByStudent(int studentId)
        {
            var enrollmentList = await _service.Enrollments.GetAllAsync();
            if (enrollmentList.Count() == 0)
            {
                return null;
            }
            var trimList = enrollmentList.Where(i => i.StudentId == studentId).ToList();
            if (trimList.Count() == 0)
            {
                return null;
            }
            var courseList = new List<CourseDTO>();
            foreach (var stid in trimList)
            {
                var student = await _service.Courses.GetAsync(stid.CourseId);
                courseList.Add(_mapper.Map<CourseDTO>(student));
            }
            return courseList;
        }
    }
}
