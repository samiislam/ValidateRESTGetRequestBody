using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebAPI.Requests;

namespace WebAPI.Controllers
{
    [Route("/")]
    [ApiController]
    public class SimpleController : ControllerBase
    {
        private ILogger<SimpleController> Logger { get; }

        public SimpleController(ILogger<SimpleController> logger) => Logger = logger;
        
        [HttpGet]
        [Route("m_1param")]
        public IActionResult Method_1Param([FromQuery] string id)
        {
            return Ok($"{nameof(Method_1Param)}:\nid = {id??"null"}");
        }

        [HttpGet]
        [Route("m_1paramR")]
        public IActionResult Method_1ParamR([FromQuery][Required] string id)
        {
            return Ok($"{nameof(Method_1ParamR)}:\nid = {id??"null"}");
        }

        [HttpGet]
        [Route("m_3param")]
        public IActionResult Method_3Param([FromQuery] string id, [FromQuery] string firstname, [FromQuery] string lastname)
        {
            return Ok($"{nameof(Method_3Param)}:\nid = {id??"null"}\nfirstname = {firstname??"null"}\nlastname = {lastname??"null"}");
        }

        [HttpGet]
        [Route("m_rm")]
        public IActionResult Method_RequestModel([FromQuery] Request request)
        {
            return Ok($"{nameof(Method_RequestModel)}:\nid = {request.Id??"null"}\nfirstname = {request.FirstName??"null"}\nlastname = {request.LastName??"null"}");
        }

        [HttpGet]
        [Route("m_rm_bv")]
        public IActionResult Method_RequestModelWithBuiltInValidationAttribute([FromQuery] RequestWithBuiltInValidationAttribute request)
        {
            return Ok($"{nameof(Method_RequestModelWithBuiltInValidationAttribute)}:\nid = {request.Id??"null"}\nfirstname = {request.FirstName??"null"}\nlastname = {request.LastName??"null"}");
        }

        [HttpGet]
        [Route("m_rm_classv")]
        public IActionResult Method_RequestModelWithClassLevelValidation([FromQuery] RequestWithClassLevelValidation request)
        {
            return Ok($"{nameof(Method_RequestModelWithClassLevelValidation)}:\nid = {request.Id??"null"}\nfirstname = {request.FirstName??"null"}\nlastname = {request.LastName??"null"}");
        }

        [HttpGet]
        [Route("m_rm_cv")]
        public IActionResult Method_RequestModelWithCustomValidationAttribute([FromQuery] RequestWithCustomValidationAttribute request)
        {
            return Ok($"{nameof(Method_RequestModelWithClassLevelValidation)}:\nid = {request.Id??"null"}\nfirstname = {request.FirstName??"null"}\nlastname = {request.LastName??"null"}\nmaritalstatus = {request.MaritalStatus}\nspouse firstname = {request.SpouseFirstName??"null"}\nspouse lastname = {request.SpouseLastName??"null"}");
        }

    }
}
