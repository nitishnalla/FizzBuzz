using FizzBuzz.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace FizzBuzz.Controllers
{
	public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

		[HttpPost]
		public ActionResult Index(FormModel model)
		{
			if (ModelState.IsValid)
			{
				List<string> userInput = model.Input.Split(',').ToList();
				List<string> outputList = new List<string>();
				foreach (string value in userInput)
				{
					int number;
					string output = string.Empty;
					if (int.TryParse(value, out number))
					{
						output = (number % 3 == 0 && number % 5 == 0) ? "FizzBuzz" : (number % 3 == 0 ? "Fizz" : (number % 5 == 0 ? "Buzz" : "Divided " + number.ToString() + " by 3," + "Divided " + number.ToString() + " by 5"));
						if (output.Contains(","))
						{
							outputList.AddRange(output.Split(',').ToList());
						}
						else
						{
							outputList.Add(output);
						}
					}
					else
					{
						outputList.Add("Invalid Item");
					}

				}
				ViewBag.OutputList = outputList;
			}
			return View();
		}

	}
}