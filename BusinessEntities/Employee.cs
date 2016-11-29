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
		//[FirstNameValidation]
		public string FirstName { get; set; }
		[StringLength(10, ErrorMessage = "Last Name Should Be Longer than 3 and Not Be Longer Than 10 Letters", MinimumLength = 3)]
		public string LastName { get; set; }
		public int Salary { get; set; }
	}

	
}