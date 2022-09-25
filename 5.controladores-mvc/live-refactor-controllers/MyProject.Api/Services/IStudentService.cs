using MyProject.Api.Models;

namespace MyProject.Api.Services
{
    public interface IStudentService
    {
        Student GetStudent(int studentId);
        IEnumerable<Student> GetStudents();
        int CreateStudent(int id, string name);
        void UpdateStudent(int id, string name);
        void DeleteStudent(int id);
    }
}
