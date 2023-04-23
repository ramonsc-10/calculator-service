using CodingChallengeCalculatorService.RestApi.Implementation;
using CodingChallengeCalculatorService.RestApi.Models.Request;
using Microsoft.Extensions.Configuration;

//var builder = new ConfigurationBuilder()
//    .SetBasePath(Directory.GetCurrentDirectory())
//    .AddJsonFile("appsettings.json", optional: false);

//var config = builder.Build();

//string uriValue = config.GetValue<string>("Uri");

var calculatorApi = new CalculatorApiClient(new Uri("https://localhost:7254/"));
var a = Console.ReadLine();
var result = await calculatorApi.AddAsync(string.Empty, new AddRequest(){ Addends = new [] {2}} );
Console.WriteLine(result.Sum.ToString());
var b = Console.ReadLine();

