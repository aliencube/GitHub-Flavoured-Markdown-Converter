using Aliencube.GitHub.Markdown.Configurations;
using Aliencube.GitHub.Markdown.Configurations.Interfaces;
using FluentAssertions;
using NUnit.Framework;
using System.Configuration;

namespace Aliencube.GitHub.Markdown.Tests
{
    [TestFixture]
    public class GitHubMarkdownSettingsTest
    {
        #region Setup

        private IGitHubMarkdownSettings _settings;

        [SetUp]
        public void Init()
        {
            this._settings = ConfigurationManager.GetSection("gitHubMarkdownSettings") as GitHubMarkdownSettings;
        }

        [TearDown]
        public void Dispose()
        {
            if (this._settings != null)
            {
                this._settings.Dispose();
            }
        }

        #endregion Setup

        #region Tests

        [Test]
        [TestCase(true, "http://proxy:8080", "domain", "username", "password")]
        public void GetProxySettings_GivenConfig_ReturnProxySettings(bool useProxy, string url, string domain, string username, string password)
        {
            var proxy = this._settings.Proxy;

            proxy.UseProxy.Should().Be(useProxy);
            proxy.Url.Should().Be(url);
            proxy.Domain.Should().Be(domain);
            proxy.Username.Should().Be(username);
            proxy.Password.Should().Be(password);
        }

        #endregion Tests
    }
}