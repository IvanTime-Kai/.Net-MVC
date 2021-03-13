using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SQL_MVC.Models;

namespace SQL_MVC.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            EmployeeDBContext dbContext = new EmployeeDBContext();
            List<Department> listDepartment = dbContext.Departments.ToList();
            return View(listDepartment);
        }
    }
}