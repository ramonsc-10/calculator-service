using CodingChallengeCalculatorService.Application.Mapper;
using CodingChallengeCalculatorService.Application.Models.Request;
using CodingChallengeCalculatorService.Application.Service.Implementation;
using CodingChallengeCalculatorService.Domain.Repository;
using NSubstitute;


namespace CodingChallengeCalculatorService.Tests
{
    public class CalculatorServiceTests
    {
        private IRecordOperationRepository _recordOperationRepository;
        private CalculatorService _calculatorService;

        [SetUp]
        public void Setup()
        {
            _recordOperationRepository = Substitute.For<IRecordOperationRepository>();
            _calculatorService = new CalculatorService(_recordOperationRepository);
        }

        [Test]
        public void Add_ShouldReturnSum_WhenAddRequestIsValid()
        {
            // Arrange
            var addRequest = new AddRequest { Addends = new[] { 2, 3 } };
            var expectedSum = 5;

            // Act
            var addResult = _calculatorService.Add(addRequest);

            // Assert
            Assert.AreEqual(expectedSum, addResult.Sum);
        }

        [Test]
        public void Add_ShouldThrowArgumentException_WhenAddRequestIsNull()
        {
            // Arrange
            AddRequest addRequest = null;

            // Act & Assert
            Assert.That(() => _calculatorService.Add(addRequest), Throws.ArgumentException
                .With.Message.Contains("You need at least two numbers to do the operation Add"));
        }

        [Test]
        public void Sub_ShouldReturnDifference_WhenSubRequestIsValid()
        {
            // Arrange
            var subRequest = new SubRequest { Minuend = 5, Subtrahend = 3 };
            var expectedDifference = 2;

            // Act
            var subResult = _calculatorService.Sub(subRequest);

            // Assert
            Assert.AreEqual(expectedDifference, subResult.Difference);
        }

        [Test]
        public void Sub_ShouldThrowArgumentException_WhenSubRequestIsNull()
        {
            // Arrange
            SubRequest subRequest = null;

            // Act & Assert
            Assert.That(() => _calculatorService.Sub(subRequest), Throws.ArgumentException
                .With.Message.Contains("No numbers provider to operate"));
        }

        [Test]
        public void Mult_ShouldReturnProduct_WhenMultRequestIsValid()
        {
            // Arrange
            var multRequest = new MultRequest { Factors = new[] { 2, 3 } };
            var expectedProduct = 6;

            // Act
            var multResult = _calculatorService.Mult(multRequest);

            // Assert
            Assert.AreEqual(expectedProduct, multResult.Product);
        }

        [Test]
        public void Mult_ShouldThrowArgumentException_WhenMultRequestIsNull()
        {
            // Arrange
            MultRequest multRequest = null;

            // Act & Assert
            Assert.That(() => _calculatorService.Mult(multRequest), Throws.ArgumentException
                .With.Message.Contains("You need at least two numbers to do the operation Mult"));
        }

        [Test]
        public void Div_ShouldReturnQuotientAndRemainder_WhenDivRequestIsValid()
        {
            // Arrange
            var divRequest = new DivRequest { Dividend = 5, Divisor = 2 };
            var expectedQuotient = 2;
            var expectedRemainder = 1;

            // Act
            var divResult = _calculatorService.Div(divRequest);

            // Assert
            Assert.AreEqual(expectedQuotient, divResult.Quotient);
            Assert.AreEqual(expectedRemainder, divResult.Remainder);
        }


        [Test]
        public void Div_ShouldThrowArgumentException_WhenDivRequestIsNull()
        {
            // Arrange
            DivRequest divRequest = null;


            // Act & Assert
            Assert.That(() => _calculatorService.Div(divRequest), Throws.ArgumentException
                .With.Message.Contains("No numbers provider to operate"));
        }

        [Test]
        public void Div_ShouldThrowArgumentException_WhenDivisorIsZero()
        {
            // Arrange
            var divRequest = new DivRequest { Dividend = 5, Divisor = 0 };


            // Act & Assert
            Assert.That(() => _calculatorService.Div(divRequest), Throws.ArgumentException
                .With.Message.Contains("You can't divide by 0"));
        }



        [Test]
        public void SquareRoot_ShouldReturnSquareRootResult_WhenSquareRootRequestIsValid()
        {
            // Arrange
            var squareRootRequest = new SquareRootRequest { Number = 9 };
            var expectedSquareRoot = 3;

            // Act
            var squareRootResult = _calculatorService.SquareRoot(squareRootRequest);

            // Assert
            Assert.AreEqual(expectedSquareRoot, squareRootResult.Square);
        }

        [Test]
        public void SquareRoot_ShouldThrowArgumentException_WhenSquareRootRequestIsNull()
        {
            // Arrange
            SquareRootRequest squareRootRequest = null;

            // Act & Assert
            Assert.That(() => _calculatorService.SquareRoot(squareRootRequest), Throws.ArgumentException
                .With.Message.Contains("No number provider to operate"));
        }

    }
}