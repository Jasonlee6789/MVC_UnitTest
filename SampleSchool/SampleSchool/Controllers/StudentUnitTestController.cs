using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleSchool.Models;

namespace SampleSchool.Controllers
{
    /*[Route("api/[controller]")]
    [ApiController]
    public class StudentUnitTestController : ControllerBase
    {
    }*/
    public class StudentUnitTestController : Controller
    {
        [NonAction]
        public List<Students> GetStudentList()
        {
            return new List<Students>
            {      new Students
                {
                    Sid = 18101,
                    Name = "John Smith",
                    Age = 21,
                    Phone = "021 123456",
                },
                new Students
                {
                    Sid = 18102,
                    Name = "Peter Price",
                    Age = 20,
                    Phone = "020 123456",
                },
            };
        }
        public IActionResult Index()
        {
            var students = from s in GetStudentList() select s;
            return View(students);
        }

        public IActionResult Students()
        {
            var students = from e in GetStudentList()
                           orderby e.Sid
                           select e;
            return View(students);
        }
    }


}