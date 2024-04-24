using DAL.DataContext;
using DAL.DataModels;
using DAL.DTO;
using Employee_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Employee_Management_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult EmployeeFiltered(string search,int pg)
        {
            List<EmpTableDTO> model = (from emp in _context.Employees 
                                    join dept in _context.Departments on
                                    emp.Deptid equals dept.Id
                                    select new DAL.DTO.EmpTableDTO
                                    {
                                        ID = emp.Id,
                                        FirstName = emp.Firstname,
                                        LastName  = emp.Lastname,
                                        Email = emp.Email,
                                        Age = emp.Age,
                                        Gender = emp.Gender,
                                        Department = dept.Name,
                                        Education = emp.Education,
                                        Company = emp.Company,
                                        Experience  = emp.Experience,
                                        Package = emp.Package,
                                    }).ToList();
            if (!string.IsNullOrEmpty(search))
            {
                search = search.ToLower();
                model = model.Where(r=>r.FirstName.ToLower().Contains(search) || r.LastName.ToLower().Contains(search)).ToList();
            }
            var pages = Math.Ceiling(model.Count() / (double)10);
            var data = model.Skip((pg - 1) * 10).Take(10).ToList();
            ViewBag.Pages = pages;
            return View(model);
        }

        [HttpPost]
        public IActionResult AddEmployee(EmpTableDTO model)
        {
            if(ModelState.IsValid)
            {
                Employee emp = new();
                emp.Id = model.ID;
                emp.Firstname   = model.FirstName;
                emp.Lastname = model.LastName;
                emp.Deptid = int.Parse(model.Department);
                emp.Age = model.Age;
                emp.Email = model.Email;
                emp.Education = model.Education;
                emp.Company = model.Company;
                emp.Experience  = model.Experience;
                emp.Package = model.Package;
                emp.Gender = model.Gender;

                _context.Employees.Add(emp);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult EditEmployee(EmpTableDTO model)
        {
            if (ModelState.IsValid)
            {
                Employee emp = _context.Employees.FirstOrDefault(e => e.Id == model.ID);
                emp.Id = model.ID;
                emp.Firstname = model.FirstName;
                emp.Lastname = model.LastName;
                emp.Deptid = int.Parse(model.Department);
                emp.Age = model.Age;
                emp.Email = model.Email;
                emp.Education = model.Education;
                emp.Company = model.Company;
                emp.Experience = model.Experience;
                emp.Package = model.Package;
                emp.Gender = model.Gender;

                _context.Employees.Update(emp);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public List<Department> GetDepartmentData()
        {
            return _context.Departments.ToList();
        }

        [HttpGet]
        public Employee GetEmpData(int id)
        {
            return _context.Employees.FirstOrDefault(x => x.Id == id);
        }
        
        public IActionResult DeleteEmpData(int id)
        {
            Employee emp  = _context.Employees.FirstOrDefault(e => e.Id == id);
            if (emp != null)
            {
                _context.Employees.Remove(emp);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

    }
}