using rsEmployee.Models;
using System.Data.SqlClient;

namespace rsEmployee.Data
{
    public class DepartmentRepository
    {
        private SqlConnection _connection;
        public DepartmentRepository()
        {
            string connStr = "server=JKSHARMA; database=CRMLeads;" + "Integrated Security=True;TrustServerCertificate=True;";

            _connection = new SqlConnection(connStr);
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            List<Department> departments = new List<Department>();
          
            {
                string query = "SELECT * FROM tblDepartment";
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Department department = new Department
                    {
                        DepartmentId = Convert.ToInt32(reader["DepartmentId"]),
                        DepartmentName = reader["DepartmentName"].ToString()
                    };

                    departments.Add(department);
                }

                reader.Close();
            }

            return departments;
        }

        public Department GetDepartmentById(int departmentId)
        {
            Department department = null;

            {
                string query = "SELECT * FROM tblDepartment WHERE DepartmentId = @DepartmentId";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@DepartmentId", departmentId);
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    department = new Department
                    {
                        DepartmentId = Convert.ToInt32(reader["DepartmentId"]),
                        DepartmentName = reader["DepartmentName"].ToString()
                    };
                }

                reader.Close();
            }

            return department;
        }

        public void InsertDepartment(Department department)
        {
           
            {
                string query = "INSERT INTO tblDepartment (DepartmentName) VALUES (@DepartmentName)";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);
                _connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateDepartment(Department department)
        {
          
            {
                string query = "UPDATE tblDepartment SET DepartmentName = @DepartmentName WHERE DepartmentId = @DepartmentId";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@DepartmentId", department.DepartmentId);
                command.Parameters.AddWithValue("@DepartmentName", department.DepartmentName);
                _connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteDepartment(int departmentId)
        {
          
            {
                string query = "DELETE FROM tblDepartment WHERE DepartmentId = @DepartmentId";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@DepartmentId", departmentId);
                _connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}
