using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using SurveyApp.Application.DTOs.Request;
using SurveyApp.Application.DTOs.Response;
using SurveyApp.Application.Features.Answer.Commands.Submit;
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

            var surveyDto = await _mediator.Send(new GetSurveyByTokenQuery(token));
            if (surveyDto == null)
            {
                return NotFound();

            }

            return View(surveyDto);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitSurvey(SurveyDto request)
        {
            if (ModelState.IsValid)
            {
                var answers = request.Answers ?? new List<AnswerDto>();
                await _mediator.Send(new SubmitSurveyAnswersCommand(answers) );


                return RedirectToAction(nameof(SurveyCompleted));
            }
            
            return View(request);

        }

        public IActionResult SurveyCompleted()
        {
            ViewBag.Message = "Survey completed successfully. Thank you!";
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