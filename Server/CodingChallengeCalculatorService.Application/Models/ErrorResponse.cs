namespace CodingChallengeCalculatorService.Application.Models
{
    public class ErrorResponse
    {
        public string ErrorCode { get; set; }
        public int ErrorStatus { get; set; }
        public string ErrorMessage { get; set; }
    }
}
