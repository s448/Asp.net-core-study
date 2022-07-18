using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using training.Models;

namespace training.Controllers
{
    public class TeacherController : Controller
    {
        TrainingDbContext Db = new TrainingDbContext();

        [HttpPost]
        public ActionResult AddTeacher(Teacher teacher)
        {
            Db.teachers.Add(teacher);
            Db.SaveChanges();
            return RedirectToAction("GetTeachers");
        }

        public ActionResult AddTeacher()
        {
            return View("AddTeacher");
        }
        public ActionResult GetTeachers()
        {
            List<Teacher> teachers = new List<Teacher>();
            teachers = (from t in Db.teachers select t).ToList();
            return View(teachers);
        }

        public ActionResult DeleteTeacher(int id)
        {
            Teacher teacher = new Teacher();

            teacher = (from t in Db.teachers where t.teacherId == id select t).FirstOrDefault();
            Db.teachers.Remove(teacher);
            Db.SaveChanges();

            return RedirectToAction("GetTeachers");
        }

        public ActionResult GetDetails(int id)
        {
            Teacher teacher = new Teacher();
            teacher = (from t in Db.teachers where t.teacherId == id select t).FirstOrDefault();

            return View("Details",teacher);
        }
    }
}