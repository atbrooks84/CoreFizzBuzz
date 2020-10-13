using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoreFizzBuzz.Models;
using System.Text;

namespace CoreFizzBuzz.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Solve()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Solve(string num1, string num2, string num3, string num4)
        {
            var fizzNum = Convert.ToInt32(num1);
            var buzzNum = Convert.ToInt32(num2);
            var startNum = Convert.ToInt32(num3);
            var endNum = Convert.ToInt32(num4);
            var output = new StringBuilder();

            for (var index = startNum; index <= endNum; index++)
            {
                if ((index % fizzNum == 0) && (index % buzzNum == 0))
                {
                    output.Append("FizzBuzz, ");
                }
                else if (index % fizzNum == 0)
                {
                    output.Append("Fizz, ");
                }
                else if (index % buzzNum == 0)
                {
                    output.Append("Buzz, ");
                }
                else
                {
                    output.Append(index.ToString() + ", ");
                }
            }
            ViewData["Output"] = output.ToString();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
