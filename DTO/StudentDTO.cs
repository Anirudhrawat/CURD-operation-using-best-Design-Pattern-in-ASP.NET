using School_Management_System.Models;

namespace School_Management_System.DTO
{
    public class StudentDTO
    {
        public int? Id { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

    }
}
