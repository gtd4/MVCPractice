using LearnMVCInSevenDaysPractice.Models;
using LearnMVCInSevenDaysPractice.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnMVCInSevenDaysPractice.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public string GetString()
		{
			return "What Up";
		}

		public ActionResult GetView()
		{


			var employeeListViewModel = new EmployeeListViewModel();

			EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
			List<Employee> employees = empBal.GetEmployees();

			List < EmployeeViewModel > empViewModels = new List<EmployeeViewModel>();

			foreach (Employee emp in employees)
			{
				EmployeeViewModel empViewModel = new EmployeeViewModel();
				empViewModel.EmployeeFullName = emp.FirstName + " " + emp.LastName;
				empViewModel.Salary = emp.Salary.ToString("C");
				if (emp.Salary > 15000)
				{
					empViewModel.SalaryColor = "yellow";
				}
				else
				{
					empViewModel.SalaryColor = "green";
				}
				empViewModels.Add(empViewModel);
			}
			employeeListViewModel.Employees = empViewModels;
			employeeListViewModel.UserName = "Admin";
			return View("MyView", employeeListViewModel);
		}
    }
}