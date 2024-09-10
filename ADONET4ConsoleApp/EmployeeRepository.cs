using MySql.Data.MySqlClient;
using System;

namespace ADONET4ConsoleApp
{
    public class EmployeeRepository
    {
        readonly string connectionString = "Data Source=127.0.0.1;Initial Catalog=EMP;UID=root;Password=Jayram007@;Integrated Security=True";

        public void CreateEmployee()
        {
            Console.Write("Name : ");
            string name = Console.ReadLine();

            Console.Write("Address : ");
            string address = Console.ReadLine();

            Console.Write("Phone : ");
            string phoneNo = Console.ReadLine();

            Console.Write("BirthDate yyyy-MM-dd: ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Console.Write("IsActive true/false: ");
            bool isActive = Boolean.Parse(Console.ReadLine());

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                string query = "INSERT INTO Employee (Name, Address, PhoneNo, BirthDate, IsActive) VALUES (@Name, @Address, @PhoneNo, @BirthDate, @IsActive)";
                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Address", address);
                    cmd.Parameters.AddWithValue("@PhoneNo", phoneNo);
                    cmd.Parameters.AddWithValue("@BirthDate", birthDate);
                    cmd.Parameters.AddWithValue("@IsActive", isActive);

                    cmd.ExecuteNonQuery();

                    Console.WriteLine("Employee Added Successfully");
                }
            }
        }

        public void ReadEmployees()
        {
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT * FROM Employee";

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Console.WriteLine($"ID: {reader["Id"]}, Name: {reader["Name"]}, Address: {reader["Address"]}, Phone: {reader["PhoneNo"]}, BirthDate: {reader["BirthDate"]}, IsActive: {reader["IsActive"]}");
                    }
                    Console.WriteLine();
                }
            }
        }

        public void ReadEmployee()
        {
            Console.Write("Id : ");
            int id = int.Parse(Console.ReadLine());

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT * FROM Employee WHERE Id="+id;

                using (MySqlCommand cmd = new MySqlCommand(query, con))
                {
                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.HasRows == true)
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID: {reader["Id"]}, Name: {reader["Name"]}, Address: {reader["Address"]}, Phone: {reader["PhoneNo"]}, BirthDate: {reader["BirthDate"]}, IsActive: {reader["IsActive"]}");
                        }
                    }
                    else
                        Console.WriteLine("No record found with Id : "+id);
                }
                Console.WriteLine();
            }
        }
        public void UpdateEmployee()
        {
            Console.Write("Id : ");
            int id = int.Parse(Console.ReadLine());
            
            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                string getEmployeeQuery = "SELECT * FROM Employee WHERE Id=" + id;
                MySqlCommand cmdEmployee = new MySqlCommand(getEmployeeQuery, con);

                MySqlDataReader readerEmployee = cmdEmployee.ExecuteReader();
                if (readerEmployee.HasRows == true)
                {
                    readerEmployee.Close();
                    Console.Write("Name : ");
                    string name = Console.ReadLine();

                    Console.Write("Address : ");
                    string address = Console.ReadLine();

                    Console.Write("Phone : ");
                    string phoneNo = Console.ReadLine();

                    Console.Write("BirthDate yyyy-MM-dd: ");
                    DateTime birthDate = DateTime.Parse(Console.ReadLine());

                    Console.Write("IsActive true/false: ");
                    bool isActive = Boolean.Parse(Console.ReadLine());

                    string query = "UPDATE Employee SET Name = @Name, Address = @Address, PhoneNo = @PhoneNo, BirthDate = @BirthDate, IsActive = @IsActive WHERE Id = @Id";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.Parameters.AddWithValue("@Name", name);
                        cmd.Parameters.AddWithValue("@Address", address);
                        cmd.Parameters.AddWithValue("@PhoneNo", phoneNo);
                        cmd.Parameters.AddWithValue("@BirthDate", birthDate);
                        cmd.Parameters.AddWithValue("@IsActive", isActive);
                        cmd.ExecuteNonQuery();
                    }
                    Console.WriteLine("Employee Updated Successfully");
                }
                else
                    Console.WriteLine("No record found with Id : " + id);                
            }
        }

        public void DeleteEmployee()
        {
            Console.Write("Id : ");
            int id = int.Parse(Console.ReadLine());            

            using (MySqlConnection con = new MySqlConnection(connectionString))
            {
                con.Open();
                string getEmployeeQuery = "SELECT * FROM Employee WHERE Id=" + id;
                MySqlCommand cmdEmployee = new MySqlCommand(getEmployeeQuery, con);

                MySqlDataReader readerEmployee = cmdEmployee.ExecuteReader();
                if (readerEmployee.HasRows == true)
                {
                    readerEmployee.Close();
                    string query = "DELETE FROM Employee WHERE Id = @Id";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                    }
                    Console.WriteLine("Employee Deleted Successfully");
                }
                else
                    Console.WriteLine("No record found with Id : " + id);
                
            }
        }
    }
}
