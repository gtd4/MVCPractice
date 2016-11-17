using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LearnMVCInSevenDaysPractice.DataAccessLayer;
using LearnMVCInSevenDays.Models;

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

		public UserStatus GetUserValidity(UserDetails u)
		{
			if (u.UserName == "Admin" && u.Password == "Admin")
			{
				return UserStatus.AuthenticatedAdmin;
			}
			else if(u.UserName.Equals("Sukesh") && u.Password.Equals("Sukesh"))
			{
				return UserStatus.AuthenticatedUser;
			}
			return UserStatus.NonAuthenticatedUser;
		}
	}
}