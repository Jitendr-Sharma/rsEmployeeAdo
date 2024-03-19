namespace rsEmployee.Data
{

    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;
    using global::rsEmployee.Models;


    namespace rsEmployee.Data
    {
        public class EmployeeRepository
        {
            private SqlConnection _connection;

            public EmployeeRepository()
            {
                string connStr = "server=JKSHARMA; database=CRMLeads;" + "Integrated Security=True;TrustServerCertificate=True;";

                _connection = new SqlConnection(connStr);
            }

            public IEnumerable<Employee> GetAllEmployees()
            {
                List<Employee> employees = new List<Employee>();
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM tblEmployee", _connection);
                    _connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Employee employee = new Employee
                        {
                            EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Email = reader["Email"].ToString(),
                            DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                            IsActive = Convert.ToBoolean(reader["IsActive"])
                        };

                        employees.Add(employee);
                    }

                    reader.Close();
                }

                return employees;
            }

            public Employee GetEmployeeById(int employeeId)
            {
                Employee employee = null;


                {
                    SqlCommand command = new SqlCommand("SELECT * FROM tblEmployee WHERE EmployeeId = @EmployeeId", _connection);
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);
                    _connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        employee = new Employee
                        {
                            EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            Email = reader["Email"].ToString(),
                            DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                            IsActive = Convert.ToBoolean(reader["IsActive"])
                        };
                    }

                    reader.Close();
                }

                return employee;
            }

            public void InsertEmployee(Employee employee)
            {

                {
                    SqlCommand command = new SqlCommand("INSERT INTO tblEmployee (FirstName, LastName, Email, DateOfBirth, IsActive) VALUES (@FirstName, @LastName, @Email, @DateOfBirth, @IsActive)", _connection);
                    command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    command.Parameters.AddWithValue("@LastName", employee.LastName);
                    command.Parameters.AddWithValue("@Email", employee.Email);
                    command.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
                    command.Parameters.AddWithValue("@IsActive", employee.IsActive);
                    _connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            public void UpdateEmployee(Employee employee)
            {

                {
                    SqlCommand command = new SqlCommand("UPDATE tblEmployee SET FirstName = @FirstName, LastName = @LastName, Email = @Email, DateOfBirth = @DateOfBirth, IsActive = @IsActive WHERE EmployeeId = @EmployeeId", _connection);
                    command.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);
                    command.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    command.Parameters.AddWithValue("@LastName", employee.LastName);
                    command.Parameters.AddWithValue("@Email", employee.Email);
                    command.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);
                    command.Parameters.AddWithValue("@IsActive", employee.IsActive);
                    _connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            public void DeleteEmployee(int employeeId)
            {

                {
                    SqlCommand command = new SqlCommand("DELETE FROM tblEmployee WHERE EmployeeId = @EmployeeId", _connection);
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);
                    _connection.Open();
                    command.ExecuteNonQuery();
                }
            }



        }
    }
}





