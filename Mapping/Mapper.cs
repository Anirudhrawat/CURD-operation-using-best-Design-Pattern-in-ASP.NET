using AutoMapper;
using School_Management_System.DTO;
using School_Management_System.Models;

namespace School_Management_System.Mapping
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<Student, StudentDTO>().
                ForMember(dest => dest.Email, opt => opt.MapFrom(student => student.Email)).
                ForMember(dest => dest.Name, opt => opt.MapFrom(student => student.Name)).
                ForMember(dest => dest.Id, opt => opt.MapFrom(student => student.Id));
            CreateMap<StudentDTO, Student>().
                ForMember(dest => dest.Enrollments, s => s.Ignore()).
                ForMember(dest => dest.Email, opt => opt.MapFrom(student => student.Email)).
                ForMember(dest => dest.Name, opt => opt.MapFrom(student => student.Name)).
                ForMember(dest => dest.Id, opt => opt.MapFrom(student => student.Id));


            CreateMap<Course, CourseDTO>().
                ForMember(dest => dest.Id, opt => opt.MapFrom(student => student.Id)).
                ForMember(dest => dest.Title, opt => opt.MapFrom(student => student.Title)).
                ForMember(dest => dest.Description, opt => opt.MapFrom(student => student.Description));
            CreateMap<CourseDTO, Course>().
                ForMember(dest => dest.Enrollments, s => s.Ignore()).
                ForMember(dest => dest.Id, opt => opt.MapFrom(student => student.Id)).
                ForMember(dest => dest.Title, opt => opt.MapFrom(student => student.Title)).
                ForMember(dest => dest.Description, opt => opt.MapFrom(student => student.Description));



            CreateMap<Enrollment, EnrollmentDTO>().
                ForMember(dest => dest.Id, opt => opt.MapFrom(student => student.Id)).
                ForMember(dest => dest.StudentId, opt => opt.MapFrom(student => student.StudentId)).
                ForMember(dest => dest.CourseId, opt => opt.MapFrom(student => student.CourseId)).
                ForMember(dest => dest.EnrollmentDate, opt => opt.MapFrom(student => student.EnrollmentDate));
            CreateMap<EnrollmentDTO, Enrollment>().
                ForMember(dest => dest.Course, s => s.Ignore()).
                ForMember(dest => dest.Student, s => s.Ignore()).
                ForMember(dest => dest.EnrollmentDate, opt => opt.MapFrom(student => student.EnrollmentDate)).
                ForMember(dest => dest.Id, opt => opt.MapFrom(student => student.Id)).
                ForMember(dest => dest.StudentId, opt => opt.MapFrom(student => student.StudentId)).
                ForMember(dest => dest.CourseId, opt => opt.MapFrom(student => student.CourseId));
        }
    }
}
