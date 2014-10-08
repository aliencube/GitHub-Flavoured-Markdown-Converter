using Aliencube.GitHub.Markdown.Configurations.Interfaces;
using Aliencube.GitHub.Markdown.Services.Interfaces;
using Octokit;
using Octokit.Internal;
using System;
using System.Net;

namespace Aliencube.GitHub.Markdown.Services
{
    /// <summary>
    /// This represents the helper entity for <c>GitHubClient</c>.
    /// </summary>
    public class GitHubClientHelper : IGitHubClientHelper
    {
        private readonly IGitHubClientSettings _settings;

        /// <summary>
        /// Initialises a new instance of the <c>GitHubClientHelper</c> class.
        /// </summary>
        /// <param name="settings"><c>GitHubClientSettings</c> instance.</param>
        public GitHubClientHelper(IGitHubClientSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            this._settings = settings;
        }

        /// <summary>
        /// Gets the <c>Connection</c> instance.
        /// </summary>
        /// <returns>Returns the <c>Connection</c> instance.</returns>
        public IConnection GetConnection()
        {
            var proxy = this._settings.Proxy;
            var pi = GetProductInformation();

            var useProxy = proxy.UseProxy;
            IConnection connection;
            if (useProxy)
            {
                var adapter = GetHttpClientAdapter();
                connection = new Connection(pi, adapter);
            }
            else
            {
                connection = new Connection(pi);
            }

            return connection;
        }

        /// <summary>
        /// Gets the product information from the config settings.
        /// </summary>
        /// <returns>Returns the product information.</returns>
        private ProductHeaderValue GetProductInformation()
        {
            var pi = this._settings.ProductInformation;
            var name = pi.Name;
            var productInformation = new ProductHeaderValue(name);
            return productInformation;
        }

        /// <summary>
        /// Gets the <c>HttpClientAdapter</c> instance from the config settings.
        /// </summary>
        /// <returns>Returns the <c>HttpClientAdapter</c> instance.</returns>
        private IHttpClient GetHttpClientAdapter()
        {
            var proxy = this._settings.Proxy;
            var url = proxy.Url;
            var domain = proxy.Domain;
            var username = proxy.Username;
            var password = proxy.Password;

            var useDefaultCredentials = proxy.UseDefaultCredentials;
            var credentials = useDefaultCredentials ? CredentialCache.DefaultNetworkCredentials : new NetworkCredential(username, password, domain);
            var webProxy = new WebProxy(url) { UseDefaultCredentials = useDefaultCredentials, Credentials = credentials };

            var httpClient = new HttpClientAdapter(webProxy);
            return httpClient;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing,
        /// or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }
    }
}