
using Microsoft.AspNetCore.Http.HttpResults;
using SMS.Data;
using SMS.Models;

namespace SMS.Repositorys
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public string AddData(Student student)
        {
          _context.Students.Add(student);
          _context.SaveChanges();
            return "Data Addes Successfull";
        }

        public string DeleteData(int id)
        {
            var data = _context.Students.Find(id);
            if(data == null)
            {
                return "Notfound";
            }
            _context.Students.Remove(data);
            _context.SaveChanges();
            return "Data Delete Successfull";
        }

        public IEnumerable<Student> GetAll()
        {
            var data = _context.Students.ToList();
            return data;
        }

        public Student GetById(int id)
        {
            return _context.Students.Find(id);

        }

        public void UpdateData(Student student)
        {
            _context.Students.Find(student.Id);
            _context.SaveChanges();
        }
    }
}
