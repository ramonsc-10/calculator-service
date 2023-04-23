using CodingChallengeCalculatorService.Domain.Models;
using CodingChallengeCalculatorService.Domain.Repository;
using CodingChallengeCalculatorService.Infrastructure.Entities;
using CodingChallengeCalculatorService.Infrastructure.Mapper;

namespace CodingChallengeCalculatorService.Infrastructure.Repositories
{
    public class RecordOperationRepository : IRecordOperationRepository
    {
        private IDictionary<string, List<RecordOperationEntity>> _recordOperationsByTrackingId;


        public RecordOperationRepository()
        {
            _recordOperationsByTrackingId = new Dictionary<string, List<RecordOperationEntity>>();
        }

        public IEnumerable<RecordOperation> FindByTrackingId(string trackingId)
        {
            _recordOperationsByTrackingId.TryGetValue(trackingId, out var records);

            if (records != null)
            {
                return records.Select(RecordOperationMapper.MapToDomainRecordOperation);
            }

            return new List<RecordOperation>();


        }

        public void Add(AddRecordOperation operation)
        {
            _recordOperationsByTrackingId.TryGetValue(operation.TrackingId, out var records);

            var entity = RecordOperationMapper.MapToEntity(operation);

            if (records != null)
            {
                records.Add(entity);
            }
            else
            {
                _recordOperationsByTrackingId.Add(operation.TrackingId, new List<RecordOperationEntity>() {entity});
            }
        }
    }
}