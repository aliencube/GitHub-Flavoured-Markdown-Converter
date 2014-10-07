using Aliencube.GitHub.Markdown.Configurations;
using Octokit;
using Octokit.Internal;
using System.Configuration;
using System.Net;

namespace Aliencube.GitHub.Markdown.Tests
{
    public static class GitHubClientHelper
    {
        private static IHttpClient GetHttpClientAdapter()
        {
            IHttpClient httpClient;
            using (var settings = ConfigurationManager.GetSection("gitHubClientSettings") as GitHubClientSettings)
            {
                var url = settings.Proxy.Url;
                var domain = settings.Proxy.Domain;
                var username = settings.Proxy.Username;
                var password = settings.Proxy.Password;

                var credentials = new NetworkCredential(username, password, domain);
                var proxy = new WebProxy(url) { Credentials = credentials };
                httpClient = new HttpClientAdapter(proxy);
            }
            return httpClient;
        }

        private static ProductHeaderValue GetProductInformation()
        {
            ProductHeaderValue productInformation;
            using (var settings = ConfigurationManager.GetSection("gitHubClientSettings") as GitHubClientSettings)
            {
                var name = settings.ProductInformation.Name;
                productInformation = new ProductHeaderValue(name);
            }
            return productInformation;
        }

        public static IConnection GetConnection()
        {
            IConnection connection;
            using (var settings = ConfigurationManager.GetSection("gitHubClientSettings") as GitHubClientSettings)
            {
                var useProxy = settings.Proxy.UseProxy;
                var pi = GetProductInformation();

                if (useProxy)
                {
                    var adapter = GetHttpClientAdapter();
                    connection = new Connection(pi, adapter);
                }
                else
                {
                    connection = new Connection(pi);
                }
            }

            return connection;
        }
    }
}