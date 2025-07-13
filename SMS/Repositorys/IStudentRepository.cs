using SMS.Models;

namespace SMS.Repositorys
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        String AddData(Student student);
        void UpdateData(Student student);
        String DeleteData(int id);
        Student GetById(int id);
    }
}
