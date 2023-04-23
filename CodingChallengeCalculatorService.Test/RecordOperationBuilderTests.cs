using CodingChallengeCalculatorService.Application.Mapper;
using CodingChallengeCalculatorService.Application.Models.Request;


namespace CodingChallengeCalculatorService.Tests
{
    public class RecordOperationBuilderTests
    {
        [Test]
        public void BuildAddRecordOperation_ValidInput_ReturnsExpectedResult()
        {
            // Arrange
            var addRequest = new AddRequest {Addends = new[] {1, 2, 3}};
            var resultAdd = 6;
            var trackingId = "1234";

            // Act
            var operation = RecordOperationBuilder.BuildAddRecordOperation(addRequest, resultAdd, trackingId);

            // Assert
            Assert.AreEqual(trackingId, operation.TrackingId);
            Assert.AreEqual("Sum", operation.Operation);
            Assert.AreEqual("1 + 2 + 3 = 6", operation.Calculation);
        }

        [Test]
        public void BuildSubRecordOperation_ValidInput_ReturnsExpectedResult()
        {
            // Arrange
            var subRequest = new SubRequest {Minuend = 5, Subtrahend = 2};
            var resultSub = 3;
            var trackingId = "5678";

            // Act
            var operation = RecordOperationBuilder.BuildSubRecordOperation(subRequest, resultSub, trackingId);

            // Assert
            Assert.AreEqual(trackingId, operation.TrackingId);
            Assert.AreEqual("Sub", operation.Operation);
            Assert.AreEqual("5 - 2 = 3", operation.Calculation);
        }

        [Test]
        public void BuildMultRecordOperation_ValidInput_ReturnsExpectedResult()
        {
            // Arrange
            var multRequest = new MultRequest {Factors = new[] {2, 3, 4}};
            var multResult = 24;
            var trackingId = "abcd";

            // Act
            var operation = RecordOperationBuilder.BuildMultRecordOperation(multRequest, multResult, trackingId);

            // Assert
            Assert.AreEqual(trackingId, operation.TrackingId);
            Assert.AreEqual("Mult", operation.Operation);
            Assert.AreEqual("2 * 3 * 4 = 24", operation.Calculation);
        }

        [Test]
        public void BuildDivRecordOperation_ValidInput_ReturnsExpectedResult()
        {
            // Arrange
            var divRequest = new DivRequest {Dividend = 10, Divisor = 3};
            var quotient = 3;
            var remainder = 1;
            var trackingId = "efgh";

            // Act
            var operation = RecordOperationBuilder.BuildDivRecordOperation(divRequest, quotient, remainder, trackingId);

            // Assert
            Assert.AreEqual(trackingId, operation.TrackingId);
            Assert.AreEqual("Sub", operation.Operation);
            Assert.AreEqual("10 / 3 = 3 , Remainder = 1", operation.Calculation);
        }

        [Test]
        public void BuildSquareRootRecordOperation_ValidInput_ReturnsExpectedResult()
        {
            // Arrange
            var squareRootRequest = new SquareRootRequest {Number = 25};
            var squareRootResult = 5;
            var trackingId = "ijkl";

            // Act
            var operation =
                RecordOperationBuilder.BuildSquareRootRecordOperation(squareRootRequest, squareRootResult, trackingId);

            // Assert
            Assert.AreEqual(trackingId, operation.TrackingId);
            Assert.AreEqual("Sub", operation.Operation);
            Assert.AreEqual("25 ^ 0.5 = 5", operation.Calculation);
        }
    }
}