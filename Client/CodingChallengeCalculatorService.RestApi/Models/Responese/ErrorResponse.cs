namespace CodingChallengeCalculatorService.RestApi.Models.Response
{
    public class ErrorResponse
    {
        public string ErrorCode { get; set; }
        public int ErrorStatus { get; set; }
        public string ErrorMessage { get; set; }

        public override string ToString()
        {
            return $"ErrorCode: {ErrorCode}, ErrorStatus: {ErrorStatus}, ErrorMessage: {ErrorMessage}";
        }
    }
}
