using CodingChallengeCalculatorService.Application.Mapper;
using CodingChallengeCalculatorService.Application.Models.Request;
using CodingChallengeCalculatorService.Application.Models.Result;
using CodingChallengeCalculatorService.Application.Service.Interface;
using CodingChallengeCalculatorService.Domain.Repository;

namespace CodingChallengeCalculatorService.Application.Service.Implementation
{
    public class CalculatorService : ICalculatorService
    {
        private string? _trackingId;
        private readonly IRecordOperationRepository _recordOperationRepository;

        public CalculatorService(IRecordOperationRepository recordOperationRepository)
        {
            _recordOperationRepository = recordOperationRepository;
        }

        public void TrackOperation(string trackingId)
        {
            _trackingId = trackingId;
        }

        public AddResult Add(AddRequest addRequest)
        {
            if (addRequest?.Addends == null || !addRequest.Addends.Any() || addRequest.Addends.Count() < 2)
            {
                throw new ArgumentException("You need at least two numbers to do the operation Add", nameof(addRequest));
            }

            var resultAdd = addRequest.Addends.Sum();

            if (!string.IsNullOrEmpty(_trackingId))
            {
                _recordOperationRepository.Add(RecordOperationBuilder.BuildAddRecordOperation(addRequest, resultAdd, _trackingId));
            }

            return new AddResult()
            {
                Sum = resultAdd
            };
        }

        public SubResult Sub(SubRequest subRequest)
        {
            if (subRequest?.Minuend == null || subRequest?.Subtrahend == null)
            {
                throw new ArgumentException("No numbers provider to operate", nameof(subRequest));
            }

            var resultSub = subRequest.Minuend - subRequest.Subtrahend;

            if (!string.IsNullOrEmpty(_trackingId))
            {
                _recordOperationRepository.Add(RecordOperationBuilder.BuildSubRecordOperation(subRequest, resultSub, _trackingId));
            }

            return new SubResult()
            {
                Difference = resultSub
            };
        }

        public MultResult Mult(MultRequest multRequest)
        {
            if (multRequest?.Factors == null || !multRequest.Factors.Any() || multRequest.Factors.Count() < 2)
            {
                throw new ArgumentException("You need at least two numbers to do the operation Mult", nameof(multRequest));
            }

            var multResult = multRequest.Factors.Aggregate((f, result) => f * result);

            if (!string.IsNullOrEmpty(_trackingId))
            {
                _recordOperationRepository.Add(RecordOperationBuilder.BuildMultRecordOperation(multRequest, multResult, _trackingId));
            }

            return new MultResult()
            {
                Product = multResult
            };
        }

        public DivResult Div(DivRequest divRequest)
        {
            if (divRequest?.Divisor == null || divRequest?.Dividend == null)
            {
                throw new ArgumentException("No numbers provider to operate", nameof(divRequest));
            }

            if (divRequest?.Divisor == 0)
            {
                throw new ArgumentException("You can't divide by 0", nameof(divRequest));
            }

            var quotient = divRequest.Dividend / divRequest.Divisor;
            var remainder = divRequest.Dividend % divRequest.Divisor;

            if (!string.IsNullOrEmpty(_trackingId))
            {
                _recordOperationRepository.Add(RecordOperationBuilder.BuildDivRecordOperation(divRequest, quotient, remainder, _trackingId));
            }

            return new DivResult()
            {
                Quotient = quotient,
                Remainder = remainder
            };
        }

        public SquareRootResult SquareRoot(SquareRootRequest squareRootRequest)
        {
            if (squareRootRequest?.Number == null)
            {
                throw new ArgumentException("No number provider to operate", nameof(squareRootRequest));
            }

            var squareRootResult = Math.Sqrt(squareRootRequest.Number);

            if (!string.IsNullOrEmpty(_trackingId))
            {
                _recordOperationRepository.Add(RecordOperationBuilder.BuildSquareRootRecordOperation(squareRootRequest, squareRootResult, _trackingId));
            }

            return new SquareRootResult()
            {
                Square = squareRootResult
            };
        }
    }
}
