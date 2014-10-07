using FluentAssertions;
using NUnit.Framework;
using Octokit;

namespace Aliencube.GitHub.Markdown.Tests
{
    [TestFixture]
    public class GitHubMarkdownServiceTest
    {
        #region Setup

        private IGitHubClient _github;

        [SetUp]
        public void Init()
        {
            var connection = GitHubClientHelper.GetConnection();
            this._github = new GitHubClient(connection);
        }

        [TearDown]
        public void Dispose()
        {
        }

        #endregion Setup

        #region Tests

        [Test]
        [TestCase("**Hello World**", "<p><strong>Hello World</strong></p>")]
        public async void GetHtml_GivenMarkdown_ReturnHtml_Async(string markdown, string expected)
        {
            var result = await this._github.Miscellaneous.RenderRawMarkdown(markdown);

            result.Should().Be(expected);
        }

        #endregion Tests
    }
}