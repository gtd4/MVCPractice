﻿using LearnMVCInSevenDaysPractice.Models;
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

		public ActionResult Index()
		{


			var employeeListViewModel = new EmployeeListViewModel();

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

			return View("Index", employeeListViewModel);
		}

		public ActionResult AddNew()
		{
			return View("CreateEmployee");
		}

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
						return View("CreateEmployee");
					}
				case "Cancel":
					return RedirectToAction("Index");

			}
			return new EmptyResult();
		}
	}
}