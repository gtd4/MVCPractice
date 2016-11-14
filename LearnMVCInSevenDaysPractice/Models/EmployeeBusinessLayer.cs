using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnMVCInSevenDaysPractice.Models
{
	public class EmployeeBusinessLayer
	{
		public List<Employee> GetEmployees()
		{
			var employees = new List<Employee>();
			var emp = new Employee();
			emp.FirstName = "Gavin";
			emp.LastName = "Downes";
			emp.Salary = 20000;

			employees.Add(emp);

			emp = new Employee();
			emp.FirstName = "Richard";
			emp.LastName = "Downes";
			emp.Salary = 10000;

			employees.Add(emp);

			emp = new Employee();
			emp.FirstName = "Bevan";
			emp.LastName = "Downes";
			emp.Salary = 25000;

			employees.Add(emp);

			return employees;
		}
	}
}