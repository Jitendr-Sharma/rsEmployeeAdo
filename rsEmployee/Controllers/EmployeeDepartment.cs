using Microsoft.AspNetCore.Mvc;
using rsEmployee.Data;
using rsEmployee.Models.rsEmployee.Models;

namespace rsEmployee.Controllers
{
    public class EmployeeDepartmentController : Controller
    {
        private readonly EmployeeDepartmentRepository _employeeDepartmentRepository;

        public EmployeeDepartmentController()
        {
            _employeeDepartmentRepository = new EmployeeDepartmentRepository();
        }

        public ActionResult Index()
        {
            IEnumerable<EmployeeDepartment> employeeDepartments = _employeeDepartmentRepository.GetAllEmployeeDepartments();
            return View(employeeDepartments);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Store(EmployeeDepartment employeeDepartment)
        {
            if (ModelState.IsValid)
            {
                _employeeDepartmentRepository.InsertEmployeeDepartment(employeeDepartment);
                return RedirectToAction("Index");
            }

            return View("Create", employeeDepartment);
        }

    }
}
