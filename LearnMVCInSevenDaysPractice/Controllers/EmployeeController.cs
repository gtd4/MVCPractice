﻿using LearnMVCInSevenDaysPractice.Filters;
using LearnMVCInSevenDaysPractice.Models;
using LearnMVCInSevenDaysPractice.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearnMVCInSevenDaysPractice.Controllers
{
	public class EmployeeController : Controller
	{
		// GET: Test
		public string GetString()
		{
			return "What Up";
		}
		[Authorize]
		public ActionResult Index()
		{

			var employeeListViewModel = new EmployeeListViewModel();
			employeeListViewModel.UserName = User.Identity.Name;

			EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
			List<Employee> employees = empBal.GetEmployees();

			List<EmployeeViewModel> empViewModels = new List<EmployeeViewModel>();

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
			employeeListViewModel.FooterData = new FooterViewModel();
			employeeListViewModel.FooterData.CompanyName = "StepByStepschools";
			employeeListViewModel.FooterData.Year = DateTime.Now.Year.ToString();

			return View("Index", employeeListViewModel);
		}

		[AdminFilter]
		public ActionResult AddNew()
		{
			return View("CreateEmployee", new CreateEmployeeViewModel());
		}

		[AdminFilter]
		[ValidateAntiForgeryToken]
		public ActionResult SaveEmployee(Employee e, string BtnSubmit)
		{

			switch (BtnSubmit)
			{
				case "Save Employee":
					if (ModelState.IsValid)
					{
						var empbal = new EmployeeBusinessLayer();
						empbal.SaveEmployee(e);
						return RedirectToAction("Index");
					}
					else
					{
						var vm = new CreateEmployeeViewModel();
						vm.FirstName = e.FirstName;
						vm.LastName = e.LastName;
						if(e.Salary > 0)
						{
							vm.Salary = e.Salary.ToString();
						}
						else
						{
							vm.Salary = ModelState["Salary"].Value.AttemptedValue;
						}
						return View("CreateEmployee", vm);
					}
				case "Cancel":
					return RedirectToAction("Index");

			}
			return new EmptyResult();
		}

		public ActionResult GetAddNewLink()
		{
			if(Convert.ToBoolean(Session["IsAdmin"]))
			{
				return PartialView("AddNewLink");
			}

			return new EmptyResult();
		}
	}
}