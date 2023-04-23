using CodingChallengeCalculatorService.Application.Models.Request;
using CodingChallengeCalculatorService.Application.Models.Result;
using CodingChallengeCalculatorService.Application.Service.Interface;
using CodingChallengeCalculatorService.Domain.Repository;

namespace CodingChallengeCalculatorService.Application.Service.Implementation
{
    public class JournalService: IJournalService
    {
        private readonly IRecordOperationRepository _recordOperationRepository;

        public JournalService(IRecordOperationRepository recordOperationRepository)
        {
            _recordOperationRepository = recordOperationRepository;
        }

        public RecordOperationsResult GetRecordOperationsByTrackingId(GetRecordOperationsRequest recordOperationsRequest)
        {
            return new RecordOperationsResult()
            {
                Operations = _recordOperationRepository.FindByTrackingId(recordOperationsRequest.Id)
            };
        }
    }
}
