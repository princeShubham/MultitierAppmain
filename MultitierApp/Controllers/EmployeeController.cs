using CommanLayer.Contract;
using CommanLayer.models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultitierApp.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployee employee;

        public EmployeeController(IEmployee employee)
        {
            this.employee = employee;
        }
        public IActionResult Index()
        {
            var emp = employee.GetEmployees();
            return View(emp);
        }

        public IActionResult Create()
        {
            return View();
        } 
        [HttpPost]
        public IActionResult Create(Employee emp)
        {
          var r= employee.CreateEmployee(emp);
            if (r != null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var r = employee.DeleteEmployee(id);
            if (r == true)
            {
                return RedirectToAction("Index");
            }
            else
            {
                TempData["message"] = "erro in delete!";
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public IActionResult Update(int id)
        {
            var r = employee.GetEmployee(id);
            return View(r);
        }

        [HttpPost]
        public IActionResult Update2(Employee emp)
        {
            var r = employee.UpdateEmployee(emp);
            if (r != null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ModelState.AddModelError(null, "Employee not updated !");
                return View();
            }
        }

    }
}
