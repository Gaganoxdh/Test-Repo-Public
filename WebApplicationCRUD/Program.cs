using System;
using System.Data.SqlClient;

namespace VulnerableApp
{
    class VulnerableExample
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter username:");
            string username = Console.ReadLine();

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
                    Console.WriteLine("User found.");
                }
                else
                {
                    Console.WriteLine("User not found.");
                }
            }

            // ❌ Vulnerability 2: Hardcoded secret
            string apiKey = "SECRET-12345-KEY";
            Console.WriteLine("Using API Key: " + apiKey);
        }
    }
}