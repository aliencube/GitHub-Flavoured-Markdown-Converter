using System;
using System.Threading.Tasks;

namespace Aliencube.GitHub.Markdown.Services.Interfaces
{
    /// <summary>
    /// This provides interfaces to the <c>ConverterService</c> class.
    /// </summary>
    public interface IConverterService : IDisposable
    {
        /// <summary>
        /// Converts the markdown text to HTML.
        /// </summary>
        /// <param name="markdown">Markdown text.</param>
        /// <returns>Returns the HTML text.</returns>
        Task<string> ConvertAsync(string markdown);
    }
}