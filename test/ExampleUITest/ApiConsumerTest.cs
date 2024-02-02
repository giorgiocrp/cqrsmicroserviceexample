using ExampleUi.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace test.ExampleUITest
{
    public class ApiConsumerTests
    {
        private const string BaseUrl = "http://example.com/api/";

        [Fact]
        public async Task GetAsync_ValidUrl_ReturnsData()
        {
            // Arrange
            var expectedData = new List<string> { "data1", "data2", "data3" };
            var httpClientHandler = new StubHttpClientHandler(HttpStatusCode.OK, expectedData);
            var apiConsumer = new ApiConsumer<string>() { BaseUrl = BaseUrl };
            var url = "endpoint";

            // Act
            var result = await apiConsumer.GetAsync(url, httpClientHandler);

            // Assert
            Assert.Equal(expectedData, result);
        }

        [Fact]
        public void GetAsync_InvalidUrl_ThrowsException()
        {
            // Arrange
            var httpClientHandler = new StubHttpClientHandler(HttpStatusCode.NotFound);
            var apiConsumer = new ApiConsumer<string>() { BaseUrl = BaseUrl };
            var url = "invalidendpoint";

            // Act & Assert
            Assert.ThrowsAsync<Exception>(async () => await apiConsumer.GetAsync(url, httpClientHandler));
        }


        [Fact]
        public async Task DeleteAsync_ValidUrl_ReturnsData()
        {
            // Arrange
            var entity = new List<string> { "data1", "data2", "data3" };
            var httpClientHandler = new StubHttpClientHandler(HttpStatusCode.OK);
            var apiConsumer = new ApiConsumer<string>() { BaseUrl = BaseUrl };
            var url = "endpoint";

            // Act            
            var exception = await Record.ExceptionAsync(() => apiConsumer.DeleteAsync(url, entity[0], httpClientHandler));

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public void DeleteAsync_InvalidUrl_ThrowsException()
        {
            // Arrange
            var httpClientHandler = new StubHttpClientHandler(HttpStatusCode.NotFound);
            var apiConsumer = new ApiConsumer<string>() { BaseUrl = BaseUrl };
            var url = "invalidendpoint";

            // Act & Assert
            Assert.ThrowsAsync<Exception>(async () => await apiConsumer.DeleteAsync(url, string.Empty, httpClientHandler));
        }

        [Fact]
        public async Task PostAsync_ValidUrl_ReturnsData()
        {
            // Arrange
            var entity = new List<string> { "data1", "data2", "data3" };
            var httpClientHandler = new StubHttpClientHandler(HttpStatusCode.OK);
            var apiConsumer = new ApiConsumer<string>() { BaseUrl = BaseUrl };
            var url = "endpoint";

            // Act            
            var exception = await Record.ExceptionAsync(() => apiConsumer.PostAsync(url, entity[0], httpClientHandler));

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public void PostAsync_InvalidUrl_ThrowsException()
        {
            // Arrange
            var httpClientHandler = new StubHttpClientHandler(HttpStatusCode.NotFound);
            var apiConsumer = new ApiConsumer<string>() { BaseUrl = BaseUrl };
            var url = "invalidendpoint";

            // Act & Assert
            Assert.ThrowsAsync<Exception>(async () => await apiConsumer.PostAsync(url, string.Empty, httpClientHandler));
        }

        [Fact]
        public async Task PutAsync_ValidUrl_ReturnsData()
        {
            // Arrange
            var entity = new List<string> { "data1", "data2", "data3" };
            var httpClientHandler = new StubHttpClientHandler(HttpStatusCode.OK);
            var apiConsumer = new ApiConsumer<string>() { BaseUrl = BaseUrl };
            var url = "endpoint";

            // Act            
            var exception = await Record.ExceptionAsync(() => apiConsumer.PutAsync(url, entity[0], httpClientHandler));

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public void PutAsync_InvalidUrl_ThrowsException()
        {
            // Arrange
            var httpClientHandler = new StubHttpClientHandler(HttpStatusCode.NotFound);
            var apiConsumer = new ApiConsumer<string>() { BaseUrl = BaseUrl };
            var url = "invalidendpoint";

            // Act & Assert
            Assert.ThrowsAsync<Exception>(async () => await apiConsumer.PutAsync(url, string.Empty, httpClientHandler));
        }
    }

    // Helper class to mock HttpClient
    public class StubHttpClientHandler : HttpClientHandler
    {
        private readonly HttpStatusCode _statusCode;
        private readonly object _content;

        public StubHttpClientHandler(HttpStatusCode statusCode, object content = null)
        {
            _statusCode = statusCode;
            _content = content;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            var response = new HttpResponseMessage(_statusCode);
            if (_content != null)
            {
                response.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(_content));
            }
            return Task.FromResult(response);
        }
    }
}
