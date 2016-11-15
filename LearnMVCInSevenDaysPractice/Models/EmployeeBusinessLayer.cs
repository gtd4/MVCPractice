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

		public Employee SaveEmployee(Employee e)
		{
			var salesDal = new SalesERPDAL();
			salesDal.Employees.Add(e);
			salesDal.SaveChanges();
			return e;
		}
	}
}