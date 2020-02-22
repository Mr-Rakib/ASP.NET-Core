using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RCTC.BLL;
using RCTC.Models;

namespace RCTC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private StudentService studentService = new StudentService();

        public object HttpContextSession { get; private set; }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AllStudents(string search)
        {
            List<Student> AllStudents = new List<Student>();

            AllStudents = (search == null) ? studentService.FindAll() : studentService.SearchAll(search);

            return View(AllStudents);
           
        }


        public IActionResult StudentAdmission()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StudentAdmission(Student student)
        {
            return (ModelState.IsValid == true && studentService.Save(student)) ? 
                RedirectToAction("AllStudents") : (IActionResult)View();
        }

        public IActionResult Edit( int id )
        {
            Student student = studentService.FindByID(id);
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student student)
        {
            return (studentService.UpdateByID(student)) ?
             RedirectToAction("AllStudents") : (IActionResult)View();

        }


        public IActionResult Delete(int id )
        {
            return (studentService.DeteteByID(id)) ?
              RedirectToAction("AllStudents") : (IActionResult)View();
        }

        public IActionResult PaidStudents(string search)
        {
            List<Student> PaidStudents = new List<Student>();

            PaidStudents = (search == null) ? studentService.PaidStudents() : studentService.PaidSearchAll(search);

            return View(PaidStudents);
        }

        public IActionResult UnpaidStudents(string search)
        {
            List<Student> UnpaidStudents = new List<Student>();

            UnpaidStudents = (search == null) ? studentService.UnpaidStudents() : studentService.UnpaidSearchAll(search);

            return View(UnpaidStudents);
        }

        public IActionResult Details(int id)
        {
            Student student = studentService.FindByID(id);
            return View(student);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
