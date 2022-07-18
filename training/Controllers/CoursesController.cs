using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using training.Models;

namespace training.Controllers
{

    public class CoursesController : Controller
    {
        TrainingDbContext Db = new TrainingDbContext();

        public ActionResult GetCourses()
        {
            List<Course> courses = new List<Course>();

            courses = (from c in Db.courses select c).ToList();

            return View("Index");
        }

        public ActionResult GetCourse(int courseId)
        {
            Course course = new Course();

            course = (from c in Db.courses where c.coursetId == courseId select c).FirstOrDefault();

            return View("DetailsView");
        }

        public ActionResult AddCourse()
        {
            Course course = new Course();

            course.courseName = "Name 1";
            course.coursetId = 1;
            course.isAvailible = true;

            Db.courses.Add(course);

            Db.SaveChanges();

            return View("Index");
        }

        public ActionResult DeleteCourse(int courseId)
        {
            Course course = new Course();
            course = (from c in Db.courses where c.coursetId == courseId select c).FirstOrDefault();

            Db.courses.Remove(course);
            Db.SaveChanges();

            return View("Index");
        }

        public ActionResult UpdateCourse(int courseId)
        {
            Course course = new Course();
            course = (from c in Db.courses where c.coursetId == courseId select c).FirstOrDefault();

            course.courseName = "update";
            course.isAvailible = false;
            Db.SaveChanges();

            return View("Index");
        }
    }
}