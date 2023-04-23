namespace CodingChallengeCalculatorService.Domain.Models
{
    public class AddRecordOperation
    {
        public string TrackingId { get; set; }
        public string Operation { get; set; }
        public string Calculation { get; set; }
    }
}
