using Aliencube.GitHub.Markdown.Services.Interfaces;
using Octokit;
using System;
using System.Threading.Tasks;

namespace Aliencube.GitHub.Markdown.Services
{
    /// <summary>
    /// This represents the converter service entity.
    /// </summary>
    public class ConverterService : IConverterService
    {
        private readonly IConnection _connection;

        /// <summary>
        /// Initialises a new instance of the <c>ConverterService</c> class.
        /// </summary>
        /// <param name="connection"><c>Connection</c> instance.</param>
        public ConverterService(IConnection connection)
        {
            if (connection == null)
            {
                throw new ArgumentNullException("connection");
            }

            this._connection = connection;
        }

        /// <summary>
        /// Converts the markdown text to HTML.
        /// </summary>
        /// <param name="markdown">Markdown text.</param>
        /// <returns>Returns the HTML text.</returns>
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

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing,
        /// or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
        }
    }
}