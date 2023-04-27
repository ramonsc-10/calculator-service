using System.Text;

namespace CodingChallengeCalculatorService.RestApi.Models.Response
{
    public class RecordOperationsResponse
    {
        public IEnumerable<RecordOperation> Operations { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("Operations:");
            foreach (var operation in Operations)
            {
                sb.AppendLine(operation.ToString());
            }
            return sb.ToString();
        }
    }

    public class RecordOperation
    {
        public string Operation { get; set; }
        public string Calculation { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return $"Operation: {Operation}, Calculation: {Calculation}, Date: {Date}";
        }
    }
}
