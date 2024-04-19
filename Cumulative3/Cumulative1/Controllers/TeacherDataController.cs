using Cumulative3.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Cumulative3.Controllers
{
    public class TeacherDataController : ApiController
    {
        private SchoolDbContext School = new SchoolDbContext();

        /// <summary>
        /// Returns a list of teachers in the system
        /// </summary>
        /// <example> GET api/TeacherData/ListTeachers</example>
        /// <returns>
        /// [{"TeacherId": "1", "TeacherfName": "Alexander", "TeacherlName":  "Bennett", "EmployeeNumber": "T378", "TeacherHireDate": "2016-08-05 00:00:00" "TeacherSalary": "55.30"},
        /// {"TeacherId": "2", "TeacherfName": "Caitlin", "TeacherlName": "Cummings", "EmployeeNumber": "T318", "TeacherHireDate": "2016-06-10 00:00:00" "TeacherSalary": "62.77"}]
        /// </returns>
        [HttpGet]
        [Route("api/TeacherData/ListTeachers")]
        public List<Teacher> ListTeachers()
        {
            // Create a connection
            MySqlConnection Conn = School.AccessDatabase();

            //Open the connection between the web server and database
            Conn.Open();

            // Establish a new command (query) for our database
            MySqlCommand cmd = Conn.CreateCommand();

            // SQL Query
            cmd.CommandText = "select * from teachers";

            // Gather results into a variable
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            // Set up a list of teachers
            List<Teacher> Teachers = new List<Teacher> { };

            // Loop through each row of the result set
            while (ResultSet.Read())
            {
                // Retreive Teacher Name
                string TeacherfName = ResultSet["teacherfname"].ToString();
                string TeacherlName = ResultSet["teacherlname"].ToString();
                //Retreive Teacher ID
                int TeacherId = Convert.ToInt32(ResultSet["teacherid"]);

                //Retreive Teachers employee number
                string EmployeeNumber = ResultSet["employeenumber"].ToString();

                //Retreive Teachers salary
                string TeacherSalary = ResultSet["salary"].ToString();

                //Retreive Teachers employee number
                string TeacherHireDate = ResultSet["hiredate"].ToString();

                Teacher NewTeacher = new Teacher();
                NewTeacher.TeacherfName = TeacherfName;
                NewTeacher.TeacherlName = TeacherlName;
                NewTeacher.TeacherId = TeacherId;
                NewTeacher.EmployeeNumber = EmployeeNumber;
                NewTeacher.TeacherSalary = TeacherSalary;
                NewTeacher.TeacherHireDate = TeacherHireDate;

                // Add to our list of teachers
                Teachers.Add(NewTeacher);


            }

            // Close the connection between the MySQL database and the web-server
            Conn.Close();

            // Return the list of teachers
            return Teachers;

        }

        //GOAL:
        // Write a method which allows us to receive a teacher id
        // Return a teacher object mathing that teacher id
        /// <summary>
        /// Receives a teacher ID. Returns the matching teacher object from the database with the same teacher id primary key
        /// </summary>
        /// <param name="TeacherId">The input teacher id to find</param>
        /// <example> GET api/TeacherData/FindTeacher/1</example>
        /// <returns>
        /// {"TeacherId": "1", "TeacherfName": "Alexander", "TeacherlName": "Bennett", "EmployeeNumber": "T378"}
        /// </returns>
        [HttpGet]
        [Route("api/TeacherData/FindTeacher/{TeacherId}")]
        public Teacher FindTeacher(int TeacherID)
        {
            // Creating a connection to the database
            MySqlConnection Conn = School.AccessDatabase();
            Conn.Open();

            // Creating a MySQL command
            MySqlCommand cmd = Conn.CreateCommand();

            // Using a query to access the information
            string query = "Select * from teachers where teacherid like @searchkey";

            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@searchkey", TeacherID);
            cmd.Prepare();

            // Run the query
            MySqlDataReader ResultSet = cmd.ExecuteReader();

            // Create teacher object
            Teacher SelectedTeacher = new Teacher();

            // Put that information into a teacher object
            while (ResultSet.Read())
            {
                SelectedTeacher.TeacherfName = ResultSet["teacherfname"].ToString();
                SelectedTeacher.TeacherlName = ResultSet["teacherlname"].ToString();
                SelectedTeacher.TeacherId = Convert.ToInt32(ResultSet["teacherid"]);
                SelectedTeacher.EmployeeNumber = ResultSet["employeenumber"].ToString();
                SelectedTeacher.TeacherSalary = ResultSet["salary"].ToString();
                SelectedTeacher.TeacherHireDate = ResultSet["hiredate"].ToString();
            }
            // Return the teacher object

            return SelectedTeacher;
        }

        /// <summary>
        /// Receives teacher information and adds it to the database
        /// </summary>
        /// <returns>
        /// 
        /// </returns>
        /// <example>
        /// POST localhost:xx/api/teacherdata/addteacher
        /// FORM DATA/POST DATA/REQUEST BODY
        /// {
        ///     "TeacherID" : "999",
        ///     "TeacherfName" : "John",
        ///     "TeacherlName" : "Smith",
        ///     "EmployeeNumber" : "T999",
        ///     "TeacherSalary" : "50.00",
        ///     "TeacherHireDate" : "2024-01-01 00:00:00"
        /// {
        /// </example>
        // Add Teacher
[HttpPost]
public void AddTeacher([FromBody]Teacher NewTeacher)
{
    MySqlConnection Conn = School.AccessDatabase();
    Conn.Open();

    MySqlCommand Cmd = Conn.CreateCommand();
            
    string query = "INSERT INTO teachers (teacherfname, teacherlname, employeenumber, hiredate, salary) VALUES (@teacherfname, @teacherlname, @employeenumber, @hiredate, @salary)";

    Cmd.CommandText = query;

    Cmd.Parameters.AddWithValue("@teacherfname",NewTeacher.TeacherfName);
    Cmd.Parameters.AddWithValue("@teacherlname",NewTeacher.TeacherlName);
    Cmd.Parameters.AddWithValue("@employeenumber",NewTeacher.EmployeeNumber);
    Cmd.Parameters.AddWithValue("@hiredate", NewTeacher.TeacherHireDate);
    Cmd.Parameters.AddWithValue("@salary",NewTeacher.TeacherSalary);

    Cmd.Prepare();
    Cmd.ExecuteNonQuery();

    Conn.Close();
}

        /// <summary>
        /// Receives a teacher ID, deletes the corresponding teacher from the database
        /// </summary>
        /// <param name="TeacherId">The Teacher ID to delete</param>
        /// <returns>
        /// </returns>
        /// <example>
        /// POST: api/TeacherData/DeleteTeacher/1 ->
        /// </example>
        [HttpPost]
        [Route("api/TeacherData/DeleteTeacher/{TeacherId}")]
        public void DeleteTeacher(int TeacherId)
        {
            MySqlConnection Conn = School.AccessDatabase();
            Conn.Open();

             string query = "DELETE FROM teachers WHERE teacherid=@TeacherId";

             MySqlCommand Cmd = Conn.CreateCommand();

             Cmd.CommandText = query;

             Cmd.Parameters.AddWithValue("@TeacherId",TeacherId);

             Cmd.Prepare();

             Cmd.ExecuteNonQuery();

        }

        /// <summary>
        /// Receive a teacher id and updated teacher information, and update the corresponding teacher in the database
        /// </summary>
        /// <example>
        /// POST api/TeacherData/UpdateTeacher/{ArticleId}
        /// POST CONTENT/ REQUEST BODY
        /// {
        ///     "TeacherfName": "Alexander"
        ///     "TeacherlName": "Bennett"
        ///     "EmployeeNumber": "T378"
        ///     "TeacherSalary": "55.30"
        ///     "TeacherHireDate": "2016-08-05 12:00:00 AM"
        /// }
        /// </example>
        /// <returns>
        /// 
        /// </returns>
        [HttpPost]
        [Route("api/TeacherData/UpdateTeacher/{TeacherId}")]
        public string UpdateTeacher(int TeacherId, [FromBody] Teacher UpdatedTeacher)
        {

            string query = "update teachers set teacherfname=@TeacherfName, teacherlname=@TeacherlName, employeenumber=@EmployeeNumber, salary=@TeacherSalary where teacherid=@id";

            MySqlConnection Conn = School.AccessDatabase();

            Conn.Open();

            MySqlCommand Cmd = Conn.CreateCommand();

            Cmd.CommandText = query;
            Cmd.Parameters.AddWithValue("@TeacherfName", UpdatedTeacher.TeacherfName);
            Cmd.Parameters.AddWithValue("@TeacherlName", UpdatedTeacher.TeacherlName);
            Cmd.Parameters.AddWithValue("@EmployeeNumber", UpdatedTeacher.EmployeeNumber);
            Cmd.Parameters.AddWithValue("@TeacherSalary", UpdatedTeacher.TeacherSalary);
            Cmd.Parameters.AddWithValue("@id", TeacherId);

            Cmd.Prepare(); 

            Cmd.ExecuteNonQuery();

            Conn.Close();

            return "Teacher has been updated successfully!";

        }

    }

}
