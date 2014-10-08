using Octokit;
using System;

namespace Aliencube.GitHub.Markdown.Services.Interfaces
{
    /// <summary>
    /// This provides interfaces to the <c>GitHubClientWrapper</c> class.
    /// </summary>
    public interface IGitHubClientWrapper : IGitHubClient, IDisposable
    {
    }
}