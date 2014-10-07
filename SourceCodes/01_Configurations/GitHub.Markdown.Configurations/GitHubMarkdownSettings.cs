using Aliencube.GitHub.Markdown.Configurations.Interfaces;
using System.Configuration;

namespace Aliencube.GitHub.Markdown.Configurations
{
    /// <summary>
    /// This represents the <c>ConfigurationSection</c> element entity for GitHubMarkdownSettings.
    /// </summary>
    public class GitHubMarkdownSettings : ConfigurationSection, IGitHubMarkdownSettings
    {
        /// <summary>
        /// Gets or sets the proxy settings element.
        /// </summary>
        [ConfigurationProperty("proxy", IsRequired = true)]
        public ProxyElement Proxy
        {
            get { return (ProxyElement)this["proxy"]; }
            set { this["proxy"] = value; }
        }

        /// <summary>
        /// Gets or sets the product information element.
        /// </summary>
        [ConfigurationProperty("productInformation", IsRequired = true)]
        public ProductInformationElement ProductInformation
        {
            get { return (ProductInformationElement)this["productInformation"]; }
            set { this["productInformation"] = value; }
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