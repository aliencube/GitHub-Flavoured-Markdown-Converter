using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octokit;

namespace Aliencube.GitHub.Markdown.Services.Interfaces
{
    public interface IGitHubClientWrapper : IGitHubClient, IDisposable
    {
    }
}
