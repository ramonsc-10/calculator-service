using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text.Json;
using CodingChallengeCalculatorService.RestApi.Models.Request;
using CodingChallengeCalculatorService.RestApi.Models.Response;

namespace CodingChallengeCalculatorService.RestApi.Implementation
{
    public class CalculatorApiClient
    {
        private readonly HttpClient _httpClient;
        public CalculatorApiClient(Uri baseAddress)
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = baseAddress
            };
        }

        public async Task<AddResponse> AddAsync(string? trackingId, AddRequest addRequest)
        {
            var request = BuildAddHttpRequestMessage(trackingId, addRequest);

            var response = await _httpClient.SendAsync(request);

            var responseContentStream = await response.Content.ReadAsStreamAsync();
            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<AddResponse>(responseContentStream);
            }
            throw new Exception((await JsonSerializer.DeserializeAsync<ErrorResponse>(responseContentStream)).ToString());
        }

        private HttpRequestMessage BuildAddHttpRequestMessage(string? trackingId, AddRequest addRequest)
        {
            var uriString = "calculator/add";
            var ms = new MemoryStream();
            SerializeAsJson(addRequest, ms);

            var requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(uriString, UriKind.Relative),
                Content = new StreamContent(ms),
            };

            requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            if (!string.IsNullOrEmpty(trackingId))
            {

                requestMessage.Headers.Add("X-Evi-Tracking-Id", trackingId);
            }

            return requestMessage;
        }

        private void SerializeAsJson(object obj, Stream stream)
        {
            var streamWriter = new StreamWriter(stream);

            JsonSerializer.Serialize(streamWriter.BaseStream, obj, obj.GetType());

            streamWriter.Flush();
            stream.Seek(0, SeekOrigin.Begin);
        }
    }
}