using Octokit;
using System;

namespace Aliencube.GitHub.Markdown.Services.Interfaces
{
    /// <summary>
    /// This provides interfaces to the <c>GitHubClientHelper</c> class.
    /// </summary>
    public interface IGitHubClientHelper : IDisposable
    {
        /// <summary>
        /// Gets the <c>Connection</c> instance.
        /// </summary>
        /// <returns>Returns the <c>Connection</c> instance.</returns>
        IConnection GetConnection();
    }
}