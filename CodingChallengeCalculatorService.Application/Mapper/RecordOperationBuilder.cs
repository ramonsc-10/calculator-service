using CodingChallengeCalculatorService.Application.Models.Request;
using CodingChallengeCalculatorService.Domain.Models;

namespace CodingChallengeCalculatorService.Application.Mapper
{
    public static class RecordOperationBuilder
    {
        public static AddRecordOperation BuildAddRecordOperation(AddRequest addRequest, int resultAdd,
            string trackingId)
        {
            return new AddRecordOperation
            {
                TrackingId = trackingId,
                Operation = "Sum",
                Calculation = $"{string.Join(" + ", addRequest.Addends)} = {resultAdd}"
            };
        }

        public static AddRecordOperation BuildSubRecordOperation(SubRequest subRequest, int resultSub,
            string trackingId)
        {
            return new AddRecordOperation
            {
                TrackingId = trackingId,
                Operation = "Sub",
                Calculation = $"{subRequest.Minuend + " - " + subRequest.Subtrahend} = {resultSub}"
            };
        }

        public static AddRecordOperation BuildMultRecordOperation(MultRequest multRequest, int multResult,
            string trackingId)
        {
            return new AddRecordOperation
            {
                TrackingId = trackingId,
                Operation = "Mult",
                Calculation = $"{string.Join(" * ", multRequest.Factors)} = {multResult}"
            };
        }

        public static AddRecordOperation BuildDivRecordOperation(DivRequest divRequest, int quotient, int remainder,
            string? trackingId)
        {
            return new AddRecordOperation
            {
                TrackingId = trackingId,
                Operation = "Sub",
                Calculation = $"{divRequest.Dividend} / {divRequest.Divisor} = {quotient} , Remainder = {remainder}"
            };
        }

        public static AddRecordOperation BuildSquareRootRecordOperation(SquareRootRequest squareRootRequest,
            double squareRootResult, string trackingId)
        {
            return new AddRecordOperation
            {
                TrackingId = trackingId,
                Operation = "Sub",
                Calculation = $"{squareRootRequest.Number} ^ 0.5 = {squareRootResult}"
            };
        }
    }
}
