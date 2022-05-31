using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Task4JsonAndAjaxCheck.Filters;
using Task4JsonAndAjaxCheck.Models;

namespace Task4JsonAndAjaxCheck.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public List<TestModel> list { get; set; }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            list=new List<TestModel>() { 
                new TestModel() { Name="Ahmad",Address="adasd",Age=213},
                new TestModel() { Name="Ali",Address="casasd",Age=12 },
                new TestModel() {Name="Waqas",Address="fasfnajf",Age=53}
            };
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AjaxCheck()
        {
            if(HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                return PartialView("_TestPartial", list);
            return View(list);
        }
        [ServiceFilter(typeof(JsonCheckFilter))]
        public IActionResult JsonCheck()
        {
            return View(list);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}