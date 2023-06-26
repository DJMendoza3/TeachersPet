using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TeachersPet.Entities
{
    public class Teacher : User
    {
        [Required]
        public int Role_id { get; set; } = 0;
        public float Credits { get; set; } = 0;
        public ICollection<Test> Tests { get; set; } = null!;
        public ICollection<Lesson> Lessons { get; set; } = null!;
        public ICollection<Course> Courses { get; set; } = null!;
        public ICollection<Syllabus> Syllabus { get; set; } = null!;
    }
}