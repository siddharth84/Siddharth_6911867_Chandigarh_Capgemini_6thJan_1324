using System;
using System.Data;
using Microsoft.Data.SqlClient;

namespace UniversityManagementSystem
{
    class Program
    {
        static string connectionString =
            "Server=SIDDHARTH\\SQLEXPRESS;" +
            "Database=UniversityDB;" +
            "Integrated Security=True;" +
            "TrustServerCertificate=True;";

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n===== UNIVERSITY MANAGEMENT SYSTEM =====");
                Console.WriteLine("1. Insert Student");
                Console.WriteLine("2. Update Student");
                Console.WriteLine("3. Delete Student");
                Console.WriteLine("4. View All Students");
                Console.WriteLine("5. View Student By Id");
                Console.WriteLine("6. Exit");
                Console.Write("Enter Choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1: InsertStudent(); break;
                    case 2: UpdateStudent(); break;
                    case 3: DeleteStudent(); break;
                    case 4: GetAllStudents(); break;
                    case 5: GetStudentById(); break;
                    case 6: return;
                    default: Console.WriteLine("Invalid Choice!"); break;
                }
            }
        }

        // INSERT
        static void InsertStudent()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_InsertStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                Console.Write("First Name: ");
                cmd.Parameters.AddWithValue("@FirstName", Console.ReadLine());

                Console.Write("Last Name: ");
                cmd.Parameters.AddWithValue("@LastName", Console.ReadLine());

                Console.Write("Email: ");
                cmd.Parameters.AddWithValue("@Email", Console.ReadLine());

                Console.Write("Dept Id: ");
                cmd.Parameters.AddWithValue("@DeptId", Convert.ToInt32(Console.ReadLine()));

                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Student Inserted Successfully!");
            }
        }

        // UPDATE
        static void UpdateStudent()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                Console.Write("Student Id: ");
                cmd.Parameters.AddWithValue("@StudentId", Convert.ToInt32(Console.ReadLine()));

                Console.Write("First Name: ");
                cmd.Parameters.AddWithValue("@FirstName", Console.ReadLine());

                Console.Write("Last Name: ");
                cmd.Parameters.AddWithValue("@LastName", Console.ReadLine());

                Console.Write("Email: ");
                cmd.Parameters.AddWithValue("@Email", Console.ReadLine());

                Console.Write("Dept Id: ");
                cmd.Parameters.AddWithValue("@DeptId", Convert.ToInt32(Console.ReadLine()));

                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Student Updated Successfully!");
            }
        }

        // DELETE
        static void DeleteStudent()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteStudent", con);
                cmd.CommandType = CommandType.StoredProcedure;

                Console.Write("Student Id to Delete: ");
                cmd.Parameters.AddWithValue("@StudentId", Convert.ToInt32(Console.ReadLine()));

                con.Open();
                cmd.ExecuteNonQuery();
                Console.WriteLine("Student Deleted Successfully!");
            }
        }

        // SELECT ALL (Using SqlDataReader)
        static void GetAllStudents()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetAllStudents", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("\n--- Student List ---");

                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["StudentId"]} | " +
                                      $"Name: {reader["FirstName"]} {reader["LastName"]} | " +
                                      $"Email: {reader["Email"]} | " +
                                      $"DeptId: {reader["DeptId"]}");
                }
            }
        }

        // SELECT BY ID (Using SqlDataAdapter)
        static void GetStudentById()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("sp_GetStudentById", con);
                cmd.CommandType = CommandType.StoredProcedure;

                Console.Write("Enter Student Id: ");
                cmd.Parameters.AddWithValue("@StudentId", Convert.ToInt32(Console.ReadLine()));

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    Console.WriteLine("\nStudent Found:");
                    Console.WriteLine($"ID: {row["StudentId"]}");
                    Console.WriteLine($"Name: {row["FirstName"]} {row["LastName"]}");
                    Console.WriteLine($"Email: {row["Email"]}");
                    Console.WriteLine($"DeptId: {row["DeptId"]}");
                }
                else
                {
                    Console.WriteLine("Student Not Found!");
                }
            }
        }
    }
}