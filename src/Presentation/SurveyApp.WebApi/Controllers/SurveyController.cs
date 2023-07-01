﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using SurveyApp.Application.Features.Survey.Commands.Create;

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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
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

        
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

       
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
