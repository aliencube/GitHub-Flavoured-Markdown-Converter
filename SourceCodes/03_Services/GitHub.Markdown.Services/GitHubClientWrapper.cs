using Aliencube.GitHub.Markdown.Services.Interfaces;
using Octokit;
using System;

namespace Aliencube.GitHub.Markdown.Services
{
    /// <summary>
    /// This represents a wrapper entity for <c>GitHubClient</c> to be disposable.
    /// </summary>
    public class GitHubClientWrapper : GitHubClient, IGitHubClientWrapper
    {
        public GitHubClientWrapper(IConnection connection)
            : base(connection)
        {
        }

        public GitHubClientWrapper(ProductHeaderValue productInformation)
            : base(productInformation)
        {
        }

        public GitHubClientWrapper(ProductHeaderValue productInformation, ICredentialStore credentialStore)
            : base(productInformation, credentialStore)
        {
        }

        public GitHubClientWrapper(ProductHeaderValue productInformation, Uri baseAddress)
            : base(productInformation, baseAddress)
        {
        }

        public GitHubClientWrapper(ProductHeaderValue productInformation, ICredentialStore credentialStore, Uri baseAddress)
            : base(productInformation, credentialStore, baseAddress)
        {
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