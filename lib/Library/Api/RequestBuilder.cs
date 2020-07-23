namespace Library.Api
{
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;

    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;

    /// <summary>
    /// A request builder that allows you to fluently build and send an http request.
    /// </summary>
    public class RequestBuilder : IRequestBuilder, IRequestBuilderMethod, IRequestBuilderHeadersBodySend
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequestBuilder"/> class.
        /// </summary>
        public RequestBuilder()
        {
            this.Client = new HttpClient();
        }

        private RequestBuilder(HttpClient client, HttpRequestMessage request)
        {
            this.Client = client;
            this.Request = request;
        }

        /// <summary>
        /// Gets the <see cref="HttpClient"/>.
        /// </summary>
        protected HttpClient Client { get; }

        /// <summary>
        /// Gets the <see cref="HttpRequestMessage"/>.
        /// </summary>
        protected HttpRequestMessage Request { get; }

        /// <inheritdoc />
        public IRequestBuilderMethod WithUrl(string url)
        {
            var request = new HttpRequestMessage
            {
                RequestUri = new Uri(url)
            };

            return new RequestBuilder(this.Client, request);
        }

        /// <inheritdoc />
        async Task<TResult> IRequestBuilderHeadersBodySend.SendAsync<TResult>()
        {
            var response = await this.Client.SendAsync(this.Request);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsAsync<TResult>();

            return result;
        }

        /// <inheritdoc />
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

        /// <inheritdoc />
        IRequestBuilderHeadersBodySend IRequestBuilderHeadersBodySend.WithHeader(string header, string value)
        {
            this.Request.Headers.Add(header, value);
            return this;
        }

        /// <inheritdoc />
        Task IRequestBuilderHeadersBodySend.SendAsync()
        {
            return this.Client.SendAsync(this.Request);
        }

        /// <inheritdoc />
        public IRequestBuilderHeadersBodySend WithMethod(HttpMethod method)
        {
            this.Request.Method = method;
            return this;
        }
    }

#pragma warning disable SA1201 // Elements must appear in the correct order

    /// <summary>
    /// The request builder interface.
    /// </summary>
    public interface IRequestBuilder
    {
        /// <summary>
        /// Sets the request builder url.
        /// </summary>
        /// <param name="url">The request url.</param>
        /// <returns>The next builder interface.</returns>
        IRequestBuilderMethod WithUrl(string url);
    }

    /// <summary>
    /// The request builder interface.
    /// </summary>
    public interface IRequestBuilderMethod
    {
        /// <summary>
        /// Sets the request method.
        /// </summary>
        /// <param name="method">The request method.</param>
        /// <returns>The next builder interface.</returns>
        IRequestBuilderHeadersBodySend WithMethod(HttpMethod method);
    }

    /// <summary>
    /// THe request builder interface.
    /// </summary>
    public interface IRequestBuilderHeadersBodySend
    {
        /// <summary>
        /// Adds a request header.
        /// </summary>
        /// <param name="header">The header name.</param>
        /// <param name="value">The header value.</param>
        /// <returns>Itself, allowing further configuration.</returns>
        IRequestBuilderHeadersBodySend WithHeader(string header, string value);

        /// <summary>
        /// Adds the request body.
        /// </summary>
        /// <param name="body">The request body.</param>
        /// <returns>Itself, allowing further configuration.</returns>
        IRequestBuilderHeadersBodySend WithBody(object body);

        /// <summary>
        /// Sends the request asynchronously and returns the result.
        /// </summary>
        /// <typeparam name="TResult">The expected result type.</typeparam>
        /// <returns>The request result.</returns>
        Task<TResult> SendAsync<TResult>();

        /// <summary>
        /// Sends the request asynchronously.
        /// </summary>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
        Task SendAsync();
    }

#pragma warning restore SA1201 // Elements must appear in the correct order
}
