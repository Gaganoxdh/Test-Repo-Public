using System;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;

namespace VulnerableApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VulnerableController : ControllerBase
    {
        [HttpGet("user")]
        public IActionResult GetUser(string username)
        {
            // ❌ Vulnerability 1: SQL Injection
            string connectionString = "Server=localhost;Database=TestDB;Trusted_Connection=True;";
            string query = "SELECT * FROM Users WHERE Username = '" + username + "'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    return Ok("User found.");
                }
                else
                {
                    return NotFound("User not found.");
                }
            }
        }

        [HttpPost("log")]
        public IActionResult LogMessage(string message)
        {
            // ❌ Vulnerability 2: Unvalidated Input in Logs
            Console.WriteLine("Log: " + message); // Could be exploited for log injection
            return Ok("Message logged.");
        }

        [HttpGet("config")]
        public IActionResult GetConfig()
        {
            // ❌ Vulnerability 3: Hardcoded secret
            string apiKey = "12345-SECRET-KEY";
            return Ok("API Key: " + apiKey);
        }
    }
}