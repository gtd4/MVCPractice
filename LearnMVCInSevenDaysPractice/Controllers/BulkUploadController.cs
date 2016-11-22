using LearnMVCInSevenDaysPractice.Filters;
using LearnMVCInSevenDaysPractice.Models;
using LearnMVCInSevenDaysPractice.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace LearnMVCInSevenDaysPractice.Controllers
{
    public class BulkUploadController : AsyncController
    {
        // GET: BulkUpload
		[HeaderFooterFilter]
		[AdminFilter]
        public ActionResult Index()
        {
            return View(new FileUploadViewModel());
        }

		[AdminFilter]
		public async Task<ActionResult> Upload(FileUploadViewModel model)
		{
			int t1 = Thread.CurrentThread.ManagedThreadId;
			var employees = await Task.Factory.StartNew<List<Employee>>
				(() => GetEmployees(model));
			int t2 = Thread.CurrentThread.ManagedThreadId;

			var bal = new EmployeeBusinessLayer();
			bal.UploadEmployess(employees);
			return RedirectToAction("Index", "Employee");
		}

		private List<Employee> GetEmployees(FileUploadViewModel model)
		{
			var employees = new List<Employee>();
			StreamReader csvReader = new StreamReader(model.FileUpload.InputStream);
			csvReader.ReadLine();
			while(!csvReader.EndOfStream)
			{
				var line = csvReader.ReadLine();
				var values = line.Split(',');
				Employee e = new Employee();
				e.FirstName = values[0];
				e.LastName = values[1];
				e.Salary = int.Parse(values[2]);
				employees.Add(e);
			}

			return employees;
		}
    }
}