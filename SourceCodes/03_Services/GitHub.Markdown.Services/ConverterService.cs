using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Octokit;

namespace Aliencube.GitHub.Markdown.Services
{
    public class ConverterService
    {
        private readonly IConnection _connection;

        public ConverterService()
        {
        }

        public async Task<string> ConvertAsync(string markdown)
        {
            var html = String.Empty;
            if (String.IsNullOrWhiteSpace(markdown))
            {
                return html;
            }

            using (var client = new GitHubClientWrapper(this._connection))
            {
                html = await client.Miscellaneous.RenderRawMarkdown(markdown);
            }
            return html;
        }
    }
}
