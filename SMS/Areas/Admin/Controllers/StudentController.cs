using Microsoft.AspNetCore.Mvc;
using SMS.Models;
using SMS.Repositorys;
using System.ComponentModel;

namespace SMS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public IActionResult Index()
        {
            var data = _studentRepository.GetAll();
            return View(data);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            var data = _studentRepository.AddData(student);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id) 
        {
            var data = _studentRepository.GetById(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit (Student student)
        {
            var data = _studentRepository.GetById(student.Id);
            if(data == null)
            {
                return NotFound();
            }
            data.Name = student.Name;
            data.Address = student.Address;
            data.RollNumber = student.RollNumber;
            data.Phone = student.Phone;
            data.Email = student.Email;
            data.Age = student.Age;
            data.Gender = student.Gender;
            data.Class = student.Class;
            data.Description = student.Description;
            data.ImeagesFeature = student.ImeagesFeature;
            data.ImeagesUrl = student.ImeagesUrl;
            _studentRepository.UpdateData(data);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(int id) 
        {
          _studentRepository.GetById(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var data = _studentRepository.GetById(id);
            return View(data);
        }
    }
}
