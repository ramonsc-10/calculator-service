using System.ComponentModel.DataAnnotations;

namespace CodingChallengeCalculatorService.Infrastructure.Entities
{
    public class RecordOperationEntity
    {
        [Key]
        public int OperationId { get; set; }
        public string TrackingId { get; set; }
        public string Operation { get; set; }
        public string Calculation { get; set; }
        public DateTime Date { get; set; }
    }
}