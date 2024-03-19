using Microsoft.AspNetCore.Mvc;
using rsEmployee.Data.rsEmployee.Data;
using rsEmployee.Models;

namespace rsEmployee.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeRepository _employeeRepository;

        public EmployeeController()
        {
            _employeeRepository = new EmployeeRepository();
        }

        public ActionResult Index()
        {
            IEnumerable<Employee> employees = _employeeRepository.GetAllEmployees();
            return View(employees);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Store(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.InsertEmployee(employee);
                return RedirectToAction("Index");
            }

            return View("Create", employee);
        }

        public ActionResult Edit(int id)
        {
            Employee employee = _employeeRepository.GetEmployeeById(id);
            if (employee == null)
            {
                return View();
            }

            return View(employee);
        }

        [HttpPost]
        public ActionResult Update(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }

            return View("Edit", employee);
        }
        public ActionResult Delete(int id)
        {
            _employeeRepository.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            Employee employee = _employeeRepository.GetEmployeeById(id);
            if (employee == null)
            {
                return View();
            }

            return View(employee);
        }






    }
}
