using School_Management_System.Models;

namespace School_Management_System.DTO
{
    public class CourseDTO
    {
        public int? Id { get; set; }

        public string Title { get; set; } = null!;

        public string? Description { get; set; }

    }
}
