using TeachersPet.Entities;

namespace TeachersPet.Services
{
    public interface ITeacherRepository
    {
        Task<bool> TeacherExists(string teachername);
        Task<bool> TeacherOwnsTest(int teacherId, int testId);
        Task<Teacher> GetTeacher(string teachername);
        Task<Teacher> GetTeacher(int id);
        Teacher CreateTeacher(Teacher teacher);
        Task<Teacher> UpdateTeacher(Teacher teacher);
        Task<Teacher> DeleteTeacher(Teacher teacher);
        Task<Teacher> DeleteTeacher(int id);
        Task<int> AddCredits(int id, int credits);
    }
}