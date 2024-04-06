using System;
using MySql.Data.MySqlClient;
using Cumulative1.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cumulative1.Controllers
{
    public class StudentDataController : ApiController
    {
        private SchoolDbContext School = new SchoolDbContext();

        /// <summary>
        /// Returns a list of students in the system
        /// </summary>
        /// <example> GET api/StudentData/ListStudents</example>
        /// <returns>
        /// [{"StudentId": "1", "StudentfName": "Sarah", "StudentlName": "Valdez", "StudentNumber": "N1678", "StudentEnrolDate": "2018-06-18 00:00:00"},
        /// {"StudentId": "2", "StudentfName": "Jennifer", "StudentlName": "Faulkner", "StudentNumber": "N1679}, "StudentEnrolDate": "2018-08-02 00:00:00"]
        /// </returns>
        [HttpGet]
        [Route("api/StudentData/ListStudents")]
        public List<Student> ListStudents()
        {
            // Create a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            // Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            // SQL Query
            cmd.CommandText = "select * from students";

            // Gather results into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            // Set up a list of students
            List<Student> Students = new List<Student> { };

            // Loop through each row of the result set
            while (ResultSet.Read())
            {
                // Retreive Student Name
                string StudentfName = ResultSet["studentfname"].ToString();
                string StudentlName = ResultSet["studentlname"].ToString();

                //Retreive Student ID
                int StudentId = Convert.ToInt32(ResultSet["studentid"]);

                //Retreive Students employee number
                string StudentNumber = ResultSet["studentnumber"].ToString();

                //Retreive Students employee number
                string StudentEnrolDate = ResultSet["enroldate"].ToString();

                Student NewStudent = new Student();
                NewStudent.StudentfName = StudentfName;
                NewStudent.StudentlName = StudentlName;
                NewStudent.StudentId = StudentId;
                NewStudent.StudentNumber = StudentNumber;
                NewStudent.StudentEnrolDate = StudentEnrolDate;

                // Add to our list of students
                Students.Add(NewStudent);


            }

            // Close the connection between the MySQL database and the web-server
            Conn.Close();

            // Return the list of students
            return Students;

        }

        //GOAL:
        // Write a method which allows us to receive a student id
        // Return a student object mathing that student id
        /// <summary>
        /// Receives a student ID. Returns the matching student object from the database with the same student id primary key
        /// </summary>
        /// <param name="StudentId">The input student id to find</param>
        /// <example> GET api/StudentData/FindStudent/1</example>
        /// <returns>
        /// {"StudentId": "1", "StudentName": "Alexander Bennett", "StudentNumber": "N1678"}
        /// </returns>
        [HttpGet]
        [Route("api/StudentData/FindStudent/{StudentId}")]
        public Student FindStudent(int StudentID)
        {
            // Creating a connection to the database
            MySqlConnection Conn = School.AccessDatabase();
            Conn.Open();

            // Creating a MySQL command
            MySqlCommand cmd = Conn.CreateCommand();

            // Using a query to access the information
            string query = "Select * from students where studentid like @searchkey";

            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@searchkey", StudentID);
            cmd.Prepare();

            // Run the query
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            // Create student object
            Student SelectedStudent = new Student();

            // Put that information into a student object
            while (ResultSet.Read())
            {
                SelectedStudent.StudentfName = ResultSet["studentfname"].ToString();
                SelectedStudent.StudentlName = ResultSet["studentlname"].ToString();
                SelectedStudent.StudentId = Convert.ToInt32(ResultSet["studentid"]);
                SelectedStudent.StudentNumber = ResultSet["studentnumber"].ToString(); ;
                SelectedStudent.StudentEnrolDate = ResultSet["enroldate"].ToString();
            }
            // Return the student object

            return SelectedStudent;
        }

    }

}
