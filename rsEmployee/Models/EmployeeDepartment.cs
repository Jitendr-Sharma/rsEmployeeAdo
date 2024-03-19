using System.ComponentModel.DataAnnotations;

namespace rsEmployee.Models
{
    namespace rsEmployee.Models
    {
        public class EmployeeDepartment
        {
            [Key]
            public int EmployeeDepartmentId { get; set; }

            [Required]
            public int EmployeeId { get; set; }

            [Required]
            public int DepartmentId { get; set; }

            [Required]
            [Display(Name = "Employee Name")]
            public string EmployeeName { get; set; }

            [Required]
            [Display(Name = "Department Name")]
            public string DepartmentName { get; set; }

        }
    }

}
