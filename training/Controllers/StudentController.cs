using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using training.Models;

namespace training.Controllers
{
    public class StudentController : Controller
    {
        TrainingDbContext Db = new TrainingDbContext();
        public ActionResult GetStudents()
        {
            List<Student> students = new List<Student>();
            students = (from s in Db.students select s).ToList();
            return View("StudentsView");
        }
    }
}