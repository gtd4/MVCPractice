using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LearnMVCInSevenDaysPractice.DataAccessLayer;

namespace LearnMVCInSevenDaysPractice.Models
{
	public class EmployeeBusinessLayer
	{
		public List<Employee> GetEmployees()
		{
			var salesDal = new SalesERPDAL();
			return salesDal.Employees.ToList();
		}
	}
}