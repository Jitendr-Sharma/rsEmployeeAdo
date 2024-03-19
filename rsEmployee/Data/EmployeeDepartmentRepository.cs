using rsEmployee.Models.rsEmployee.Models;
using System.Data.SqlClient;

namespace rsEmployee.Data
{
    public class EmployeeDepartmentRepository
    {
        private SqlConnection _connection;
        public EmployeeDepartmentRepository()
        {
            string connStr = "server=JKSHARMA; database=CRMLeads;" + "Integrated Security=True;TrustServerCertificate=True;";

            _connection = new SqlConnection(connStr);
        }

        public IEnumerable<EmployeeDepartment> GetAllEmployeeDepartments()
        {
            List<EmployeeDepartment> employeeDepartments = new List<EmployeeDepartment>();

          
            {
                string query = "SELECT * FROM tblEmployeeDepartment";
                SqlCommand command = new SqlCommand(query, _connection);
                _connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    EmployeeDepartment employeeDepartment = new EmployeeDepartment
                    {
                        EmployeeDepartmentId = Convert.ToInt32(reader["EmployeeDepartmentId"]),
                        EmployeeId = Convert.ToInt32(reader["EmployeeId"]),
                        DepartmentId = Convert.ToInt32(reader["DepartmentId"])
                    };

                    employeeDepartments.Add(employeeDepartment);
                }

                reader.Close();
            }

            return employeeDepartments;
        }

        public void InsertEmployeeDepartment(EmployeeDepartment employeeDepartment)
        {
           
            {
                string query = "INSERT INTO tblEmployeeDepartment (EmployeeId, DepartmentId) VALUES (@EmployeeId, @DepartmentId)";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@EmployeeId", employeeDepartment.EmployeeId);
                command.Parameters.AddWithValue("@DepartmentId", employeeDepartment.DepartmentId);
                _connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public string GetEmployeeNameById(int employeeId)
        {
            string employeeName = null;

        
            {
                string query = "SELECT EmployeeName FROM tblEmployee WHERE EmployeeId = @EmployeeId";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@EmployeeId", employeeId);
                _connection.Open();
                employeeName = command.ExecuteScalar()?.ToString();
            }

            return employeeName;
        }

        public string GetDepartmentNameById(int departmentId)
        {
            string departmentName = null;

           
            {
                string query = "SELECT DepartmentName FROM tblDepartment WHERE DepartmentId = @DepartmentId";
                SqlCommand command = new SqlCommand(query, _connection);
                command.Parameters.AddWithValue("@DepartmentId", departmentId);
                _connection.Open();
                departmentName = command.ExecuteScalar()?.ToString();
            }

            return departmentName;
        }
    }
}
