using Aliencube.GitHub.Markdown.Services;
using Aliencube.GitHub.Markdown.Services.Interfaces;
using FluentAssertions;
using NUnit.Framework;

namespace Aliencube.GitHub.Markdown.Tests
{
    [TestFixture]
    public class ConverterServiceTest
    {
        #region Setup

        private IConverterService _converter;

        [SetUp]
        public void Init()
        {
            var connection = GitHubClientHelper.GetConnection();
            this._converter = new ConverterService(connection);
        }

        [TearDown]
        public void Dispose()
        {
            if (this._converter != null)
            {
                this._converter.Dispose();
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