using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using project.Models;

namespace project.Controllers
{
    public class StudentController : Controller
    {

        private ExcersiceContext ORM = null;

        public StudentController(ExcersiceContext ORM)
        {
            this.ORM = ORM;
        }

        [HttpGet]
        public IActionResult CreateStudent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateStudent(Student S)
        {
            ORM.Add(S);

            ORM.SaveChanges();
            ViewBag.Message = "Registration Done Successfully";
            ModelState.Clear();
            return View();
        }


        public IActionResult AllStudents()
        {
            IList<Student> S = new List<Student>();
            S = ORM.Student.ToList<Student>();
            return View(S);
        }

        public IActionResult StudentDetail(int ID)

        {
                Student S = ORM.Student.Where(m => m.Id == ID).FirstOrDefault<Student>();
                return View(S);

        }

        [HttpGet]
        public IActionResult EditStudent(int Id)
        {

            Student S = ORM.Student.Where(m => m.Id == Id).FirstOrDefault<Student>();
            return View(S);
        }
        [HttpPost]
        public IActionResult EditStudent(Student S)
        {
            ORM.Student.Update(S);
            ORM.SaveChanges();
            
            return RedirectToAction("AllStudents");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}