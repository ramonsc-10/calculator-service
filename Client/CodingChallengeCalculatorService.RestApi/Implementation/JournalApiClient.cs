using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text.Json;
using CodingChallengeCalculatorService.RestApi.Models.Request;
using CodingChallengeCalculatorService.RestApi.Models.Response;
using CodingChallengeCalculatorService.RestApi.Utils;

namespace CodingChallengeCalculatorService.RestApi.Implementation
{
    public class JournalApiClient
    {
        private readonly HttpClient _httpClient;
        public JournalApiClient(Uri baseAddress)
        {
            _httpClient = new HttpClient()
            {
                BaseAddress = baseAddress
            };
        }

        public async Task<RecordOperationsResponse> GetRecordOperationsAsync(GetRecordOperationsRequest getRecordOperationsRequest)
        {
            var request = BuildGetRecordOperationsHttpRequestMessage(getRecordOperationsRequest);

            var response = await _httpClient.SendAsync(request);

            var responseContentStream = await response.Content.ReadAsStreamAsync();
            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<RecordOperationsResponse>(responseContentStream);
            }
            throw new Exception((await JsonSerializer.DeserializeAsync<ErrorResponse>(responseContentStream)).ToString());
        }

        #region private methods
        private HttpRequestMessage BuildGetRecordOperationsHttpRequestMessage(GetRecordOperationsRequest request)
        {
            var uriString = "journal/query";
            var ms = new MemoryStream();
            ClientTools.SerializeAsJson(request, ms);

            var requestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(uriString, UriKind.Relative),
                Content = new StreamContent(ms),
            };

            requestMessage.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return requestMessage;
        }

        #endregion

    }
}