using CodingChallengeCalculatorService.Domain.Models;
using CodingChallengeCalculatorService.Infrastructure.Entities;

namespace CodingChallengeCalculatorService.Infrastructure.Mapper
{
    public static class RecordOperationMapper
    {

        public static RecordOperation MapToDomainRecordOperation(RecordOperationEntity entity)
        {
            return new RecordOperation()
            {
                Operation = entity.Operation,
                Calculation = entity.Calculation,
                Date = entity.Date
            };
        }

        public static RecordOperationEntity MapToEntity(AddRecordOperation operation)
        {
            return new RecordOperationEntity()
            {
                TrackingId = operation.TrackingId,
                Operation = operation.Operation,
                Calculation = operation.Calculation,
                Date = DateTime.Now
            };
        }
    }
}
