﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LearnMVCInSevenDaysPractice.ViewModels
{
	public class FileUploadViewModel : BaseViewModel
	{
		public HttpPostedFileBase FileUpload { get; set; }
	}
}