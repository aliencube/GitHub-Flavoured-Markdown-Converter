using System;

namespace Aliencube.GitHub.Markdown.Configurations.Interfaces
{
    /// <summary>
    /// This provides interfaces to the <c>GitHubMarkdownSettings</c> class.
    /// </summary>
    public interface IGitHubClientSettings : IDisposable
    {
        /// <summary>
        /// Gets or sets the proxy settings element.
        /// </summary>
        ProxyElement Proxy { get; set; }

        /// <summary>
        /// Gets or sets the product information element.
        /// </summary>
        ProductInformationElement ProductInformation { get; set; }
    }
}