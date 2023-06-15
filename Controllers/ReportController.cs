using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using School.Models;
using Newtonsoft.Json;

namespace School.Controllers
{
    public class ReportController : Controller
    {
       /* private readonly SchoolContext _context;

        public ReportController(SchoolContext context)
        {
            _context = context;
        }*/

        private readonly string _connString = "Server=localhost;Database=School;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true;";

        [HttpGet]
        public ActionResult GetAllOnsitePeople(string value)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                string query = "EXECUTE GetAllOnsitePeople @discriminator = " + value;

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@discriminator", value);
                conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string results = reader.GetString(0);
                        return Content(results);
                    }
                }
                conn.Close();
                return NotFound();
            }
        }

        public ActionResult GetInstructorsForDepartment(int value)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                string query = "EXECUTE GetInstructorsForDepartment @id = " + value + ";";

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", value);
                conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string results = reader.GetString(0);
                        return Content(results);
                    }
                }
                conn.Close();
                return NotFound();
            }
        }

        public ActionResult GetGradesForDepartment()
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                string query = "EXECUTE GetGradesForDepartment;";

                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string results = reader.GetString(0);
                        return Content(results);
                    }
                }
                conn.Close();
                return NotFound();
            }
        }

        public ActionResult AverageDepartmentGrade(int value)
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                string query = "EXECUTE AverageDepartmentGrade @id = " + value + ";";

                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@id", value);
                conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string results = reader.GetString(0);
                        return Content(results);
                    }
                }
                conn.Close();
                return NotFound();
            }
        }

        public ActionResult ClassData()
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                string query = "EXECUTE ClassData;";

                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string results = reader.GetString(0);
                        return Content(results);
                    }
                }
                conn.Close();
                return NotFound();
            }
        }

        [HttpGet]
        public IActionResult GradesByDepartment()
        {
            using (SqlConnection conn = new SqlConnection(_connString))
            {
                string query = "EXECUTE GradesByDepartment;";

                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string results = reader.GetString(0);
                        return Content(results);
                    }
                }
                conn.Close();
                return NotFound();
            }
        }

        public JsonResult method()
        {
            var db = new SchoolContext();
            Person person = db.People.Find(4);
            string json = JsonConvert.SerializeObject(person, Formatting.Indented);
            return Json(json);
        }
    }
}
