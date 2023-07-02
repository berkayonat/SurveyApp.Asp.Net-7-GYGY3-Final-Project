using MediatR;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.Application.DTOs.Response;
using SurveyApp.Application.Features.Survey.Commands.Create;
using SurveyApp.Application.Features.Survey.Queries.GetAll;
using SurveyApp.Application.Features.Survey.Queries.GetByToken;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SurveyApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SurveyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetSurveys()
        {
            var surveys = await _mediator.Send(new GetAllSurveysQuery());
            return Ok(surveys);

        }
            [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSurveyCommand request)
        {
            if (ModelState.IsValid)
            {
                var surveyUrl = await _mediator.Send(request);
                return Ok(surveyUrl);
            }
            return BadRequest(ModelState);
        }
        [HttpGet]
        [Route("{token}")]
        public async Task<IActionResult> Survey(string token)
        {

            var SurveyDto = await _mediator.Send(new GetSurveyByTokenQuery(token));

            if (SurveyDto == null)
            {
                return NotFound();
            }

            return Ok(SurveyDto);
        }
        //[HttpPost]
        //[Route("SubmitSurvey")]
        //public IActionResult SubmitSurvey(SurveyViewModel surveyViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _surveyService.SubmitSurvey(surveyViewModel);

        //        return RedirectToAction("SurveyCompleted");
        //    }

        //    return BadRequest(ModelState);
        //}

        //[HttpGet]
        //[Route("SurveyCompleted")]
        //public IActionResult SurveyCompleted()
        //{
        //    return View("SurveyCompleted");
        //}
    }
}
