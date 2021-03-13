using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;

namespace MVC_DEMO.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            List<Employee> employees = employeeBusinessLayer.GetAllEmployee();
            return View(employees);
        }
        [HttpGet]
        [ActionName("Create")]
        public ActionResult Create_Get()
        {
            return View();
        }

        // FROMCOLLECTION
        //[HttpPost]
        //public ActionResult Create(FormCollection formCollection)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        foreach (string key in formCollection.AllKeys)
        //        {
        //            Response.Write("Key = " + key + "  ");
        //            Response.Write("Value = " + formCollection[key]);
        //            Response.Write("<br/>");
        //        }
        //    }
        //    return View();
        //}

        //[HttpPost]
        //public ActionResult Create(FormCollection formCollection)
        //{
        //    Employee employee = new Employee();
        //    // Retrieve form data using form collection
        //    employee.Name = formCollection["Name"];
        //    employee.Gender = formCollection["Gender"];
        //    employee.City = formCollection["City"];
        //    employee.Salary = Convert.ToDecimal(formCollection["Salary"]);
        //    employee.DateOfBirth = Convert.ToDateTime(formCollection["DateOfBirth"]);
        //    EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
        //    employeeBusinessLayer.AddEmployee(employee);
        //    return RedirectToAction("Index");
        //}

        //[HttpPost]
        //public ActionResult Create(string name, string gender, string city, decimal Salary, DateTime dateOfBirth)
        //{
        //    Employee employee = new Employee();
        //    employee.Name = name;
        //    employee.Gender = gender;
        //    employee.City = city;
        //    employee.Salary = Salary;
        //    employee.DateOfBirth = dateOfBirth;
        //    EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
        //    employeeBusinessLayer.AddEmployee(employee);
        //    return RedirectToAction("Index");
        //}

        //MODEL BINDING
        [HttpPost]
        [ActionName("Create")]
        public ActionResult Create_Post(Employee employee)
        {
            if (ModelState.IsValid)
            {
                EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
                employeeBusinessLayer.AddEmployee(employee);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

        //UpdateModel
        //[HttpPost]
        //[ActionName("Create")]
        //public ActionResult Create_Post()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
        //        Employee employee = new Employee();
        //        UpdateModel<Employee>(employee);
        //        employeeBusinessLayer.AddEmployee(employee);
        //        return RedirectToAction("Index");
        //    }
        //    return View();
        //}


        //TryUpdateModel
        //[HttpPost]
        //[ActionName("Create")]
        //public ActionResult Create_Post()
        //{

        //    EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
        //    Employee employee = new Employee();
        //    TryUpdateModel<Employee>(employee);
        //    if (ModelState.IsValid)
        //    {
        //        employeeBusinessLayer.AddEmployee(employee);
        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}

        [HttpGet]
        [ActionName("Edit")]
        public ActionResult Edit_Get( int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            Employee employee = employeeBusinessLayer.GetAllEmployee().FirstOrDefault(emp => emp.ID == id);
            return View(employee);
        }

        //[HttpPost]
        //public ActionResult Edit(Employee employee)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
        //        employeeBusinessLayer.UpdateEmployee(employee);
        //        return RedirectToAction("Index");
        //    }
        //    return View(employee);
        //}

        // Cap nhap khong mong muon
        // Cach 1:
        //[HttpPost]
        //[ActionName("Edit")]
        //public ActionResult Edit_Post( int id)
        //{
        //    EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
        //    Employee employee = employeeBusinessLayer.GetAllEmployee().Single(emp => emp.ID == id);
        //    UpdateModel(employee, new string[] { "ID", "Gender", "City", "Salary", "DateOfBirth" });
        //    if (ModelState.IsValid)
        //    {
        //        employeeBusinessLayer.UpdateEmployee(employee);
        //        return RedirectToAction("Index");
        //    }
        //    return View(employee);
        //}
        
        // Cach 2:
        //[HttpPost]
        //[ActionName("Edit")]
        //public ActionResult Edit_Post(int id)
        //{
        //    EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
        //    Employee employee = employeeBusinessLayer.GetAllEmployee().Single(x => x.ID == id);
        //    UpdateModel(employee, null, null, new string[] { "Name" });
        //    if (ModelState.IsValid)
        //    {
        //        employeeBusinessLayer.UpdateEmployee(employee);
        //        return RedirectToAction("Index");
        //    }
        //    return View(employee);
        //}

        // Su dung thuoc tinh rang buoc Bind
        // Cach 1 :
        //[HttpPost]
        //[ActionName("Edit")]
        //public ActionResult Edit_Post([Bind(Include ="Id, Gender, City, Salary, DateOfBirth")] Employee employee)
        //{
        //    EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
        //    employee.Name = employeeBusinessLayer.GetAllEmployee().Single(emp => emp.ID == employee.ID).Name;
        //    if (ModelState.IsValid)
        //    {
        //        employeeBusinessLayer.UpdateEmployee(employee);
        //        return RedirectToAction("Index");
        //    }
        //    return View(employee);
        //}

        // Cach 2
        //[HttpPost]
        //[ActionName("Edit")]
        //public ActionResult Edit_Post([Bind(Exclude = "Name")] Employee employee)
        //{
        //    EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
        //    employee.Name = employeeBusinessLayer.GetAllEmployee().Single(emp => emp.ID == employee.ID).Name;
        //    if (ModelState.IsValid)
        //    {
        //        employeeBusinessLayer.UpdateEmployee(employee);
        //        return RedirectToAction("Index");
        //    }
        //    return View(employee);
        //}

        [HttpPost]
        [ActionName("Edit")]
        public ActionResult Edit_Post( int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            Employee employee = employeeBusinessLayer.GetAllEmployee().Single(emp => emp.ID == id);
            UpdateModel<IEmployee>(employee);
            if (ModelState.IsValid)
            {
                employeeBusinessLayer.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            EmployeeBusinessLayer employeeBusinessLayer = new EmployeeBusinessLayer();
            employeeBusinessLayer.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}