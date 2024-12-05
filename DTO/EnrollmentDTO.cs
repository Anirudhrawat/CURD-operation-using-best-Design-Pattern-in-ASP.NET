using School_Management_System.Models;

namespace School_Management_System.DTO
{
    public class EnrollmentDTO
    {
        public int? Id { get; set; }

        public int? StudentId { get; set; }

        public int? CourseId { get; set; }

        public DateTime EnrollmentDate { get; set; }

    }
}

