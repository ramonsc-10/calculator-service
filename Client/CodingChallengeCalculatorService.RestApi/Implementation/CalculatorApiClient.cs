using System.Net.Http.Headers;
using System.Text.Json;
using CodingChallengeCalculatorService.RestApi.Models.Request;
using CodingChallengeCalculatorService.RestApi.Models.Response;
using CodingChallengeCalculatorService.RestApi.Utils;

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

        public async Task<SubResponse> SubAsync(string? trackingId, SubRequest subRequest)
        {
            var request = BuildSubHttpRequestMessage(trackingId, subRequest);

            var response = await _httpClient.SendAsync(request);

            var responseContentStream = await response.Content.ReadAsStreamAsync();
            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<SubResponse>(responseContentStream);
            }
            throw new Exception((await JsonSerializer.DeserializeAsync<ErrorResponse>(responseContentStream)).ToString());
        }
        
        public async Task<MultResponse> MultAsync(string? trackingId, MultRequest multRequest)
        {
            var request = BuildMultHttpRequestMessage(trackingId, multRequest);

            var response = await _httpClient.SendAsync(request);

            var responseContentStream = await response.Content.ReadAsStreamAsync();
            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<MultResponse>(responseContentStream);
            }
            throw new Exception((await JsonSerializer.DeserializeAsync<ErrorResponse>(responseContentStream)).ToString());
        }

        public async Task<DivResponse> DivAsync(string? trackingId, DivRequest divRequest)
        {
            var request = BuildDivHttpRequestMessage(trackingId, divRequest);

            var response = await _httpClient.SendAsync(request);

            var responseContentStream = await response.Content.ReadAsStreamAsync();
            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<DivResponse>(responseContentStream);
            }
            throw new Exception((await JsonSerializer.DeserializeAsync<ErrorResponse>(responseContentStream)).ToString());
        }

        public async Task<SquareRootResponse> SqrtAsync(string? trackingId, SquareRootRequest squareRootRequest)
        {
            var request = BuildSquareRootHttpRequestMessage(trackingId, squareRootRequest);

            var response = await _httpClient.SendAsync(request);

            var responseContentStream = await response.Content.ReadAsStreamAsync();
            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<SquareRootResponse>(responseContentStream);
            }
            throw new Exception((await JsonSerializer.DeserializeAsync<ErrorResponse>(responseContentStream)).ToString());
        }

        #region private methods

        private HttpRequestMessage BuildAddHttpRequestMessage(string? trackingId, AddRequest request)
        {
            var uriString = "calculator/add";
            var ms = new MemoryStream();
            ClientTools.SerializeAsJson(request, ms);

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

        private HttpRequestMessage BuildSubHttpRequestMessage(string? trackingId, SubRequest request)
        {
            var uriString = "calculator/sub";
            var ms = new MemoryStream();
            ClientTools.SerializeAsJson(request, ms);

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

        private HttpRequestMessage BuildMultHttpRequestMessage(string? trackingId, MultRequest request)
        {
            var uriString = "calculator/mult";
            var ms = new MemoryStream();
            ClientTools.SerializeAsJson(request, ms);

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

        private HttpRequestMessage BuildDivHttpRequestMessage(string? trackingId, DivRequest request)
        {
            var uriString = "calculator/div";
            var ms = new MemoryStream();
            ClientTools.SerializeAsJson(request, ms);

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

        private HttpRequestMessage BuildSquareRootHttpRequestMessage(string? trackingId, SquareRootRequest request)
        {
            var uriString = "calculator/sqrt";
            var ms = new MemoryStream();
            ClientTools.SerializeAsJson(request, ms);

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
        #endregion
    }
}