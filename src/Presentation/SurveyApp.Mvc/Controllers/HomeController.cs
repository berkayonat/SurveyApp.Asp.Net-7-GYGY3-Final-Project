using MediatR;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.Application.Features.Survey.Queries.GetByToken;
using SurveyApp.Mvc.Models;
using System.Diagnostics;

namespace SurveyApp.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;

        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [Route("survey/{token}")]
        public async Task<IActionResult> Survey(string token)
        {

            var survey = await _mediator.Send(new GetSurveyByTokenQuery(token));
            if (survey == null)
            {
                return NotFound();

            }

            return View(survey);

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