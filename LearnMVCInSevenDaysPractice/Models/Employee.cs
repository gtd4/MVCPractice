using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LearnMVCInSevenDaysPractice.Models
{
	public class Employee
	{
		public int EmployeeId { get; set; }
		[Required(ErrorMessage = "Enter First Name")]
		public string FirstName { get; set; }
		[StringLength(10, ErrorMessage = "Last Name Should Not Be Longer Than 10 Letters")]
		public string LastName { get; set; }
		public int Salary { get; set; }
	}
}