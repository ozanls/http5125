using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cumulative1.Models;

namespace Cumulative1.Controllers
{
    public class TeacherController : Controller
    {
        // GET: Teacher/List
        public ActionResult List()
        {
            List<Teacher> Teachers = new List<Teacher>();
            TeacherDataController Controller = new TeacherDataController();
            Teachers = Controller.ListTeachers();

            // Should navigate to /Views/Teacher/List.cshtml
            return View(Teachers);
        }

        //GET: Teacher/Show/{id} -> A webpage containing information about that particular teacher
        public ActionResult Show(int id)
        {
            TeacherDataController Controller = new TeacherDataController();
            Teacher SelectedTeacher = Controller.FindTeacher(id);

            //Should navigate to /View/Article/Show.cshtml
            return View(SelectedTeacher);
        }
        
    }
}