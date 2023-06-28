using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private static List<Employee> employees ;

        public HomeController()
        {
            if (employees == null)
            {
                employees = new List<Employee>();

                for (int i = 0; i < 10; i++)
                {
                    employees.Add(new HourlyEmployee());
                    employees.Add(new SalariedEmployee());
                    employees.Add(new Manager());
                }
            }
        }

        /// <summary>
        /// index view
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View(employees);
        }

        /// <summary>
        /// add work days
        /// </summary>
        /// <param name="employeeIndex">index of employee from list</param>
        /// <param name="days">number of days</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Work(int employeeIndex, int days)
        {
            Employee employee = employees[employeeIndex];
            try
            {
                employee.Work(days);
                TempData["Message"] = "Work days updated successfully.";
                TempData["MessageType"] = "success";
            }
            catch (InvalidOperationException ex)
            {
                TempData["Message"] = ex.Message;
                TempData["MessageType"] = "danger";
            }
            return RedirectToAction("Index",employees);
        }

        /// <summary>
        /// Take vacation days
        /// </summary>
        /// <param name="employeeIndex">index of employee from list</param>
        /// <param name="days">number of days</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult TakeVacation(int employeeIndex, float days)
        {
            Employee employee = employees[employeeIndex];
            try
            {
                employee.TakeVacation(days);
                TempData["Message"] = "Vacation days updated successfully.";
                TempData["MessageType"] = "success";
            }
            catch (InvalidOperationException ex)
            {
                TempData["Message"] = ex.Message;
                TempData["MessageType"] = "danger";
            }
            return RedirectToAction("Index");
        }
    }
}