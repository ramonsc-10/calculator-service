using System.Net;

namespace CodingChallengeCalculatorService.Application.Exception
{
    public class CalculatorException : System.Exception
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Code { get; set; }

        public CalculatorException() { }

        public CalculatorException(string message)
            : base(message) { }

        public CalculatorException(string message, string code, HttpStatusCode statusCode)
            : base(message)
        {
            Code = code;
            StatusCode = statusCode;
        }
	}
}
