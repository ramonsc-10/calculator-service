using CodingChallengeCalculatorService.RestApi.Implementation;
using CodingChallengeCalculatorService.RestApi.Models.Request;
using Microsoft.Extensions.Configuration;

var apiAddressEnv = Environment.GetEnvironmentVariable("API_ADDRESS");
var config = new ConfigurationBuilder()
    .AddJsonFile($"appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
    .Build();

var apiAddress = apiAddressEnv ?? config.GetValue<string>("ApiConfig:BaseUrl");

var trackingId = Guid.NewGuid().ToString();
var calculatorApi = new CalculatorApiClient(new Uri(apiAddress));
var journalApi = new JournalApiClient(new Uri(apiAddress));

Console.WriteLine("Add [2,2,2] with trackingId");
var result = await calculatorApi.AddAsync(trackingId, new AddRequest(){ Addends = new [] {2, 2, 2}} );
Console.WriteLine("Result: " + result.Sum.ToString());

Console.WriteLine("Sub {8 - 3 } with trackingId");
var subResult = await calculatorApi.SubAsync(trackingId, new SubRequest() {Minuend = 8, Subtrahend = 3});
Console.WriteLine("Result: " + subResult.Difference);

Console.WriteLine("Sub {1 - 3 } without trackingId");
var subResult2 = await calculatorApi.SubAsync(string.Empty, new SubRequest() { Minuend = 1, Subtrahend = 3 });
Console.WriteLine("Result: " + subResult2.Difference);

Console.WriteLine("Mult [2,2,3] with trackingId");
var multResponse = await calculatorApi.MultAsync(trackingId, new MultRequest() { Factors = new[] { 2, 2, 3 } });
Console.WriteLine("Result: " + multResponse.Product);

Console.WriteLine("Div {101/ 10} with trackingId");
var divResponse = await calculatorApi.DivAsync(trackingId, new DivRequest() {Dividend = 101, Divisor = 10});
Console.WriteLine("Result: " + divResponse.Quotient + ", remainder:" + divResponse.Remainder);

Console.WriteLine("Sqrt {100} with trackingId");
var squareRootResponse = await calculatorApi.SqrtAsync(trackingId, new SquareRootRequest() { Number= 100 });
Console.WriteLine("Result: " + squareRootResponse.Square);



Console.WriteLine("Journal: ");
var getRecordOperationsResponse= await journalApi.GetRecordOperationsAsync(new GetRecordOperationsRequest() {Id = trackingId});
Console.WriteLine("Result: " + getRecordOperationsResponse.ToString());


Console.WriteLine("Press any key to exit");
var b = Console.ReadLine();

