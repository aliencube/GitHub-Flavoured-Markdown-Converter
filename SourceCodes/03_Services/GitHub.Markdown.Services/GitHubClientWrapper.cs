using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aliencube.GitHub.Markdown.Services.Interfaces;
using Octokit;

namespace Aliencube.GitHub.Markdown.Services
{
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

        public void Dispose()
        {
        }
    }
}
