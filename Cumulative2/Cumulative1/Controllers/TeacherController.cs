using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Cumulative2.Models;
using Mysqlx.Datatypes;

namespace Cumulative2.Controllers
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

            //Should navigate to /View/Teacher/Show.cshtml
            return View(SelectedTeacher);
        }
        
        // GET : Teacher/New -> A webpage asking the user for new teacher information
        public ActionResult New()
        {
            // Navigate to Views/Teacher/New.cshtml
            return View();
        }

        // POST : Teacher/Create -> Redirects to the list teachers page
        [HttpPost]
        public ActionResult Create(string TeacherfName, string TeacherlName, string EmployeeNumber, string TeacherHireDate, string TeacherSalary)
        {
            Debug.WriteLine("Form Submission received for Add Teacher");
            Debug.WriteLine(TeacherfName);
            Debug.WriteLine(TeacherlName);
            Debug.WriteLine(EmployeeNumber);
            Debug.WriteLine(TeacherHireDate);
            Debug.WriteLine(TeacherSalary);

            Teacher NewTeacher = new Teacher();
            NewTeacher.TeacherfName = TeacherfName;
            NewTeacher.TeacherlName = TeacherlName;
            NewTeacher.EmployeeNumber = EmployeeNumber;
            NewTeacher.TeacherHireDate = TeacherHireDate;
            NewTeacher.TeacherSalary = TeacherSalary;

            TeacherDataController dataController = new TeacherDataController();

            dataController.AddTeacher(NewTeacher);

            return RedirectToAction("List");
        }


        // GET : Teacher/DeleteConfirm/{id} -> A webpage asking if the user really wants to delete that teacher

        public ActionResult DeleteConfirm(int id) {

            // Get the teacher info

            TeacherDataController DataController = new
            TeacherDataController();

            Teacher SelectedTeacher =
            DataController.FindTeacher(id);

            // Display the teacher info to confirm this is the one that the user wants to delete

            // Navigate to /Views/Teacher/DeleteConfirm

            return View(SelectedTeacher);

        }

        // POST : /Teacher/Delete/{id} -> Redirects to the teacher list page
        [HttpPost]
        public ActionResult Delete(int id)
        {

            TeacherDataController DataController = new
            TeacherDataController();

            DataController.DeleteTeacher(id);

            return RedirectToAction("List");
        }
        
    }
}