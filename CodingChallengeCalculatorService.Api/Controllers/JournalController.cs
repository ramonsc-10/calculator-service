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
    public class JournalController : ControllerBase
    {
        private readonly IJournalService _journalService;

        public JournalController(IJournalService journalService)
        {
            _journalService = journalService;
        }

        [HttpPost("query")]
        [CalculatorExceptionFilter]
        public IActionResult Query([FromBody] GetRecordOperationsRequest request)
        {
            try
            {
                var result = _journalService.GetRecordOperationsByTrackingId(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new CalculatorException(ex.Message, "GetRecordOperationsRequestInternalError", HttpStatusCode.InternalServerError);
            }
        }

    }
}