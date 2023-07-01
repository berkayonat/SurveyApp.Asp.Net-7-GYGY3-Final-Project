using Microsoft.AspNetCore.Mvc;
using SurveyApp.Mvc.Models;
using System.Diagnostics;

namespace SurveyApp.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("survey/{token}")]
        public IActionResult Survey(string token)
        {
            
            //var survey = _surveyRepository.GetSurveyByToken(token);
            //if (survey != null)
            //{
            //    return View(survey);
            //}
            //else
            //{
            //    return NotFound();
            //}
            return View();
        }

        public IActionResult Index()
        {
            return View();
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