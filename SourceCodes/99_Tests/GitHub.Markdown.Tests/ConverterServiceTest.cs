using Aliencube.GitHub.Markdown.Configurations;
using Aliencube.GitHub.Markdown.Configurations.Interfaces;
using Aliencube.GitHub.Markdown.Services;
using Aliencube.GitHub.Markdown.Services.Interfaces;
using FluentAssertions;
using NUnit.Framework;
using System.Configuration;

namespace Aliencube.GitHub.Markdown.Tests
{
    [TestFixture]
    public class ConverterServiceTest
    {
        #region Setup

        private IGitHubClientSettings _settings;
        private IGitHubClientHelper _helper;
        private IConverterService _converter;

        [SetUp]
        public void Init()
        {
            this._settings = GitHubClientSettings.CreateInstance();
            this._helper = new Services.GitHubClientHelper(this._settings);
            this._converter = new ConverterService(this._helper);
        }

        [TearDown]
        public void Dispose()
        {
            if (this._converter != null)
            {
                this._converter.Dispose();
            }

            if (this._helper != null)
            {
                this._helper.Dispose();
            }

            if (this._settings != null)
            {
                this._settings.Dispose();
            }
        }

        #endregion Setup

        #region Tests

        [Test]
        [TestCase("**Hello World**", "<p><strong>Hello World</strong></p>")]
        public async void GetHtml_GivenMarkdown_ReturnHtml_Async(string markdown, string expected)
        {
            var result = await this._converter.ConvertAsync(markdown);

            result.Should().Be(expected);
        }

        #endregion Tests
    }
}