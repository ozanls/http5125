using Cumulative1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Cumulative1.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student/List
        public ActionResult List()
        {
            List<Student> Students = new List<Student>();
            StudentDataController Controller = new StudentDataController();
            Students = Controller.ListStudents();

            // Should navigate to /Views/Student/List.cshtml
            return View(Students);
        }

        //GET: Student/Show/{id} -> A webpage containing information about that particular student
        public ActionResult Show(int id)
        {
            StudentDataController Controller = new StudentDataController();
            Student SelectedStudent = Controller.FindStudent(id);

            //Should navigate to /View/Article/Show.cshtml
            return View(SelectedStudent);
        }

    }
}