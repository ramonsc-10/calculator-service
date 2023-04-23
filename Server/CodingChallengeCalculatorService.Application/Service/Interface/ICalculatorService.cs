using CodingChallengeCalculatorService.Application.Models.Request;
using CodingChallengeCalculatorService.Application.Models.Result;

namespace CodingChallengeCalculatorService.Application.Service.Interface
{
    public interface ICalculatorService
    {
        void TrackOperation(string trackingId);
        public AddResult Add(AddRequest addRequest);
        public SubResult Sub(SubRequest subRequest);
        public MultResult Mult(MultRequest multRequest);
        public DivResult Div(DivRequest divRequest);
        public SquareRootResult SquareRoot(SquareRootRequest squareRootRequest);
    }
}
