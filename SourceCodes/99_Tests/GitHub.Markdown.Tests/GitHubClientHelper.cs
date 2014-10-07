using Octokit;
using Octokit.Internal;
using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Net;

namespace Aliencube.GitHub.Markdown.Tests
{
    public static class GitHubClientHelper
    {
        private static readonly NameValueCollection _appSettings = ConfigurationManager.AppSettings;

        private static IHttpClient GetHttpClientAdapter()
        {
            var connStrings = _appSettings["ProxyConnectionString"].Split(new string[] { ";" }, StringSplitOptions.RemoveEmptyEntries);

            var url = connStrings.Single(p => p.ToLower().StartsWith("url=")).ToLower().Replace("url=", "");

            var domain = String.Empty;
            var username = connStrings.Single(p => p.ToLower().StartsWith("username=")).ToLower().Replace("username=", "");
            if (username.Contains("\\"))
            {
                domain = username.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries)[0];
                username = username.Split(new string[] { "\\" }, StringSplitOptions.RemoveEmptyEntries)[1];
            }

            var password = connStrings.Single(p => p.ToLower().StartsWith("password=")).ToLower().Replace("password=", "");

            var credentials = new NetworkCredential(username, password, domain);
            var proxy = new WebProxy(url) { Credentials = credentials };
            var httpClient = new HttpClientAdapter(proxy);

            return httpClient;
        }

        private static ProductHeaderValue GetProductInformation()
        {
            var productName = _appSettings["ProductInformation"];
            var productInformation = new ProductHeaderValue(productName);
            return productInformation;
        }

        public static IConnection GetConnection()
        {
            bool result;
            var useProxy = Boolean.TryParse(_appSettings["UseProxy"], out result) && result;

            var pi = GetProductInformation();

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
    }
}