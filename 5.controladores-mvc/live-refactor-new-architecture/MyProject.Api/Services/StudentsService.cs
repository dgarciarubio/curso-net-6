using MyProject.Api.Models;

namespace MyProject.Api.Services
{
    public class StudentsService : IStudentService
    {
        private readonly List<Student> _students;

        public StudentsService() 
        {
            this._students = new List<Student>();
        }

        public Student GetStudent(int studentId) 
        {
            return _students.FirstOrDefault(student => student.Id == studentId);
        }

        public IEnumerable<Student> GetStudents() 
        {
            return _students;
        }

        public int CreateStudent(int id, string name) 
        {
            var newStudent = new Student { Id = id, Name = name };

            _students.Add(newStudent);
            return newStudent.Id;
        }

        public void UpdateStudent(int id, string name)
        {
            var student = _students.FirstOrDefault(student => student.Id == id);
            if (student != null) 
            {
                student.Name = name;
            } 
            else
            {
                throw new Exception("Student Not Found");
            }
        }

        public void DeleteStudent(int id) 
        {
            var student = _students.FirstOrDefault(student => student.Id == id);
            if (student != null)
            {
                _students.Remove(student);
            }
            else
            {
                throw new Exception("Student Not Found");
            }
        }
    }
}
