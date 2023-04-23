using CodingChallengeCalculatorService.Domain.Models;

namespace CodingChallengeCalculatorService.Application.Models.Result
{
    public class RecordOperationsResult
    {
        public IEnumerable<RecordOperation> Operations { get; set; }
    }
}
