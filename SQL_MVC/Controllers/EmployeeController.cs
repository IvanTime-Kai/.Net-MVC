using SQL_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;

namespace SQL_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index( int departmentId)
        {
            EmployeeDBContext dBContext = new EmployeeDBContext();
            List<Employee> employees = dBContext.Employees.Where( emp => emp.DepartmentId == departmentId).ToList();

            return View(employees);

            
        }

        public ActionResult Details(int id)
        {
            EmployeeDBContext dBContext = new EmployeeDBContext();
            Employee employee = dBContext.Employees.Single(x => x.EmployeeId == id);
            return View(employee);
        }
    }
}