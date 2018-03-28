using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Library.Api
{
    public class RequestBuilder : IRequestBuilder, IRequestBuilderMethod, IRequestBuilderHeadersBodySend
    {
        public RequestBuilder()
        {
            this.Client = new HttpClient();
        }

        private RequestBuilder(HttpClient client, HttpRequestMessage request)
        {
            this.Client = client;
            this.Request = request;
        }

        protected HttpClient Client { get; }

        protected HttpRequestMessage Request { get; }

        public IRequestBuilderMethod WithUrl(string url)
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(url)
            };

            return new RequestBuilder(this.Client, request);
        }

        async Task<TResult> IRequestBuilderHeadersBodySend.SendAsync<TResult>()
        {
            var response = await this.Client.SendAsync(this.Request);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsAsync<TResult>();
            
            return result;
        }

        IRequestBuilderHeadersBodySend IRequestBuilderHeadersBodySend.WithBody(object body)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            var json = JsonConvert.SerializeObject(body, settings);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            this.Request.Content = content;

            return this;
        }

        IRequestBuilderHeadersBodySend IRequestBuilderHeadersBodySend.WithHeader(string header, string value)
        {
            this.Request.Headers.Add(header, value);
            return this;
        }

        Task IRequestBuilderHeadersBodySend.SendAsync()
        {
            return this.Client.SendAsync(this.Request);
        }

        public IRequestBuilderHeadersBodySend WithMethod(HttpMethod method)
        {
            this.Request.Method = method;
            return this;
        }
    }

    public interface IRequestBuilder
    {
        IRequestBuilderMethod WithUrl(string url);
    }

    public interface IRequestBuilderMethod
    {
        IRequestBuilderHeadersBodySend WithMethod(HttpMethod method);
    }

    public interface IRequestBuilderHeadersBodySend
    {
        IRequestBuilderHeadersBodySend WithHeader(string header, string value);

        IRequestBuilderHeadersBodySend WithBody(object body);

        Task<TResult> SendAsync<TResult>();

        Task SendAsync();
    }
}
