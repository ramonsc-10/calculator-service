using CodingChallengeCalculatorService.Application.Models.Request;
using CodingChallengeCalculatorService.Application.Models.Result;

namespace CodingChallengeCalculatorService.Application.Service.Interface
{
    public interface IJournalService
    {
        RecordOperationsResult GetRecordOperationsByTrackingId(GetRecordOperationsRequest recordOperationsRequest);
    }
}
