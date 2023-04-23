using System.Net;
using CodingChallengeCalculatorService.Api.Filter;
using CodingChallengeCalculatorService.Application.Exception;
using CodingChallengeCalculatorService.Application.Models.Request;
using CodingChallengeCalculatorService.Application.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CodingChallengeCalculatorService.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorService _calculatorService;

        public CalculatorController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        [HttpPost("add")]
        [CalculatorExceptionFilter]
        public IActionResult Add([FromHeader] string? trackingId, [FromBody] AddRequest request)
        {
            _calculatorService.TrackOperation(trackingId);

            try
            {
                var result = _calculatorService.Add(request);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                throw new CalculatorException(ex.Message, "AddParametersError", HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                throw new CalculatorException(ex.Message, "AddInternalError", HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost("sub")]
        [CalculatorExceptionFilter]
        public IActionResult Sub([FromHeader] string? trackingId, [FromBody] SubRequest request)
        {
            _calculatorService.TrackOperation(trackingId);

            try
            {
                var result = _calculatorService.Sub(request);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                throw new CalculatorException(ex.Message, "SubParametersError", HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                throw new CalculatorException(ex.Message, "SubInternalError", HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost("mult")]
        [CalculatorExceptionFilter]
        public IActionResult Mult([FromHeader] string? trackingId, [FromBody] MultRequest request)
        {
            _calculatorService.TrackOperation(trackingId);

            try
            {
                var result = _calculatorService.Mult(request);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                throw new CalculatorException(ex.Message, "MultParametersError", HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                throw new CalculatorException(ex.Message, "MultInternalError", HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost("div")]
        [CalculatorExceptionFilter]
        public IActionResult Div([FromHeader] string? trackingId, [FromBody] DivRequest request)
        {
            _calculatorService.TrackOperation(trackingId);

            try
            {
                var result = _calculatorService.Div(request);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                throw new CalculatorException(ex.Message, "DivParametersError", HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                throw new CalculatorException(ex.Message, "DivInternalError", HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost("sqrt")]
        [CalculatorExceptionFilter]
        public IActionResult Sqrt([FromHeader] string? trackingId, [FromBody] SquareRootRequest request)
        {
            _calculatorService.TrackOperation(trackingId);

            try
            {
                var result = _calculatorService.SquareRoot(request);
                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                throw new CalculatorException(ex.Message, "SquareRootParametersError", HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                throw new CalculatorException(ex.Message, "SquareRootInternalError", HttpStatusCode.InternalServerError);
            }
        }
    }
}