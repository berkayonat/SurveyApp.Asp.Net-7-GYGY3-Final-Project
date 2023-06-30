using MediatR;
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

        // GET: api/<SurveyController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<SurveyController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<SurveyController>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateSurveyCommand request)
        {
            if (ModelState.IsValid)
            {
                var surveyToken = await _mediator.Send(request);
                var surveyUrl = Url.Action("TakeSurvey", "Home", new { token = surveyToken }, Request.Scheme);
                return Ok(surveyUrl);
            }
            return BadRequest(ModelState);
        }

        // PUT api/<SurveyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SurveyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
