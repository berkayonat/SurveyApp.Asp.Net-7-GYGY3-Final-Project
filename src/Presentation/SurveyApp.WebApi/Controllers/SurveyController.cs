using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.Application.DTOs.Response;
using SurveyApp.Application.Features.Survey.Commands.Create;
using SurveyApp.Application.Features.Survey.Queries.GetAll;
using SurveyApp.Application.Features.Survey.Queries.GetAllByUserId;
using SurveyApp.Application.Features.Survey.Queries.GetByToken;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SurveyApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class SurveyController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<CreateSurveyCommand> _validator;


        public SurveyController(IMediator mediator, IValidator<CreateSurveyCommand> validator)
        {
            _mediator = mediator;
            _validator = validator;
        }


        [HttpGet]
        [Authorize(Roles = "admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetSurveys()
        {
            var surveys = await _mediator.Send(new GetAllSurveysQuery());
            return Ok(surveys);

        }

        [HttpGet("user-surveys")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> GetUserSurveys()
        {
            
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var surveys = await _mediator.Send(new GetAllSurveysByUserIdQuery(userId));

            return Ok(surveys);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Create([FromBody] CreateSurveyCommand request)
        {
            var validationResult = await _validator.ValidateAsync(request);

            if (!validationResult.IsValid)
            {
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }

                return BadRequest(ModelState);
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            request.AppUserId = userId;

            var surveyUrl = await _mediator.Send(request);
            return Ok(surveyUrl);
        }
        
        [HttpGet]
        [Route("{token}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Survey(string token)
        {

            var SurveyDto = await _mediator.Send(new GetSurveyByTokenQuery(token));

            if (SurveyDto == null)
            {
                return NotFound();
            }

            return Ok(SurveyDto);
        }

    }
}
