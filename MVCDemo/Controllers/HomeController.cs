using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDemo.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		[ChildActionOnly]
		public ActionResult Report()
		{
			var model = new List<ReportViewModel>();
			var rand = new Random();
			var range = 1 * 365; //1 years
			for (var i = 0; i < 50; i++)
			{
				model.Add(new ReportViewModel()
				{
					Type = "支出",
					Time = DateTime.Today.AddDays(-rand.Next(range)),
					Amount = rand.Next(500,100000)
				});
			}

			return PartialView("Partials/_Report", model.OrderBy(x => x.Time));
		}
	}

	public class ReportViewModel
	{
		[Display(Name = "類別")]
		public string Type { get; set; }
		[Display(Name = "日期")]
		public DateTime Time { get; set; }
		[Display(Name = "金額")]
		public decimal Amount { get; set; }
	}
}