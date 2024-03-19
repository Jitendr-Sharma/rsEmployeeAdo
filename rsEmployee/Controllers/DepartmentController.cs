using Microsoft.AspNetCore.Mvc;
using rsEmployee.Data;
using rsEmployee.Models;

namespace rsEmployee.Controllers
{
      public class DepartmentController : Controller

        {
            private readonly DepartmentRepository _departmentRepository;

            public DepartmentController()
            {
                _departmentRepository = new DepartmentRepository();
            }

            public ActionResult Index()
            {
                IEnumerable<Department> departments = _departmentRepository.GetAllDepartments();
                return View(departments);
            }

            public ActionResult Create()
            {
                return View();
            }

            [HttpPost]
            public ActionResult Store(Department department)
            {
                if (ModelState.IsValid)
                {
                    _departmentRepository.InsertDepartment(department);
                    return RedirectToAction("Index");
                }

                return View("Create", department);
            }

            public ActionResult Edit(int id)
            {
                Department department = _departmentRepository.GetDepartmentById(id);
                if (department == null)
                {
                    return View();
                }

                return View(department);
            }

            [HttpPost]
            public ActionResult Update(Department department)
            {
                if (ModelState.IsValid)
                {
                    _departmentRepository.UpdateDepartment(department);
                    return RedirectToAction("Index");
                }

                return View("Edit", department);
            }

            public ActionResult Delete(int id)
            {
                _departmentRepository.DeleteDepartment(id);
                return RedirectToAction("Index");
            }

        public ActionResult Details(int id)
        {
            Department department = _departmentRepository.GetDepartmentById(id);
            if (department == null)
            {
                return View();
            }

            return View(department);
        }
 


    }
}
