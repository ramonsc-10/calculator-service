using CodingChallengeCalculatorService.Domain.Models;

namespace CodingChallengeCalculatorService.Domain.Repository
{
    public interface IRecordOperationRepository
    {
        public IEnumerable<RecordOperation> FindByTrackingId(string trackingId);
        public void Add(AddRecordOperation operation);
    }
}