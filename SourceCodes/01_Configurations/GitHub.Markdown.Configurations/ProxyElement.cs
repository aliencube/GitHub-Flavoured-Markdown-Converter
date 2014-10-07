using System.Configuration;

namespace Aliencube.GitHub.Markdown.Configurations
{
    /// <summary>
    /// This represents the proxy settings element entity.
    /// </summary>
    public class ProxyElement : ConfigurationElement
    {
        /// <summary>
        /// Gets or sets the value that specifies whether to use proxy server or not.
        /// </summary>
        [ConfigurationProperty("useProxy", IsRequired = false, DefaultValue = false)]
        public bool UseProxy
        {
            get { return (bool)this["useProxy"]; }
            set { this["useProxy"] = value; }
        }

        /// <summary>
        /// Gets or sets the value that specifies whether to use default credentials for proxy server connection or not.
        /// If <c>UseProxy</c> is <c>False</c>, this property will be ignored.
        /// </summary>
        [ConfigurationProperty("useDefaultCredentials", IsRequired = false, DefaultValue = true)]
        public bool UseDefaultCredentials
        {
            get { return (bool)this["useDefaultCredentials"]; }
            set { this["useDefaultCredentials"] = value; }
        }

        /// <summary>
        /// Gets or sets the URL value.
        /// If <c>UseProxy</c> is <c>False</c>, this property will be ignored.
        /// If <c>UseDefaultCredentials</c> is <c>True</c>, this property will be also ignored.
        /// </summary>
        [ConfigurationProperty("url", IsRequired = false, DefaultValue = "")]
        public string Url
        {
            get { return (string)this["url"]; }
            set { this["url"] = value; }
        }

        /// <summary>
        /// Gets or sets the domain value.
        /// If <c>UseProxy</c> is <c>False</c>, this property will be ignored.
        /// If <c>UseDefaultCredentials</c> is <c>True</c>, this property will be also ignored.
        /// </summary>
        [ConfigurationProperty("domain", IsRequired = false, DefaultValue = "")]
        public string Domain
        {
            get { return (string)this["domain"]; }
            set { this["domain"] = value; }
        }

        /// <summary>
        /// Gets or sets the username value.
        /// If <c>UseProxy</c> is <c>False</c>, this property will be ignored.
        /// If <c>UseDefaultCredentials</c> is <c>True</c>, this property will be also ignored.
        /// </summary>
        [ConfigurationProperty("username", IsRequired = false, DefaultValue = "")]
        public string Username
        {
            get { return (string)this["username"]; }
            set { this["username"] = value; }
        }

        /// <summary>
        /// Gets or sets the password value.
        /// If <c>UseProxy</c> is <c>False</c>, this property will be ignored.
        /// If <c>UseDefaultCredentials</c> is <c>True</c>, this property will be also ignored.
        /// </summary>
        [ConfigurationProperty("password", IsRequired = false, DefaultValue = "")]
        public string Password
        {
            get { return (string)this["password"]; }
            set { this["password"] = value; }
        }
    }
}